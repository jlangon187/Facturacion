using FacturacionDAM.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmLineaFacemi : Form
    {
        private Tabla _tabla;
        private BindingSource _bs;
        private Tabla _tablaProductos;
        private BindingSource _bsProductos;

        private int _idFactura = -1;
        private bool _modoEdicion = false;

        public FrmLineaFacemi()
        {
            InitializeComponent();
        }

        #region Constructores
        public FrmLineaFacemi(BindingSource aBs, Tabla aTabla, int aIdFactura, bool aModoEdicion = false)
        {
            InitializeComponent();
            _tabla = aTabla;
            _bs = aBs;
            _idFactura = aIdFactura;
            _modoEdicion = aModoEdicion;
        }

        private void FrmLineaFacemi_Load(object sender, EventArgs e)
        {
            CargarProductos();
            PrepararBindings();

            SeleccionarProductoSinEdicion();
            IniLineaFactura();
            RecalcularLinea();
        }
        #endregion

        #region Eventos y botones
        private void BtnProducto_Click(object sender, EventArgs e)
        {
            TrasladarDatosProducto();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ForzarNoNulosLinea();
            RecalcularLinea();

            if (!ValidarLinea())
                return;

            _bs.EndEdit();
            _tabla.GuardarDatos();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _bs.CancelEdit();
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region Métodos propios

        /// <summary>
        /// Metodo para inicializar la línea de factura para que tenga valores por defecto
        /// </summary>
        private void IniLineaFactura()
        {
            if (!(_bs.Current is DataRowView row))
                return;

            // Limpiamos las etiquetas de totales
            lbBase.Text = "";
            lbCuota.Text = "";
            lbTotal.Text = "";

            // Nos aseguramos de que los campos tengan valores por defecto
            if (row["idfactura"] != DBNull.Value) row["idfactura"] = _idFactura;
            if (row["cantidad"] == DBNull.Value) row["cantidad"] = 1.00m;
            if (row["precio"] == DBNull.Value) row["precio"] = 0.00m;
            if (row["base"] == DBNull.Value) row["base"] = 0.00m;
            if (row["cuota"] == DBNull.Value) row["cuota"] = 0.00m;
            if (row["descripcion"] == DBNull.Value) row["descripcion"] = "";
            if (row["tipoiva"] == DBNull.Value) row["tipoiva"] = 0.00m;
        }

        /// <summary>
        /// Si estamos en modo edición, selecciona el producto correspondiente en el combo
        /// </summary>
        private void SeleccionarProductoSinEdicion()
        {
            if (!_modoEdicion)
                return;
            if (!(_bs.Current is DataRowView row))
                return;
            if (row["idproducto"] == DBNull.Value)
                return;

            int idProducto = Convert.ToInt32(row["idproducto"]);
            cbProducto.SelectedIndex = idProducto;
        }

        /// <summary>
        /// Asocia controles con las fuentes de datos
        /// </summary>
        private void PrepararBindings()
        {
            if (!(_bs.Current is DataRowView row))
            {
                MessageBox.Show("No hay una línea activa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            // Relación con la factura
            row["idfacemi"] = _idFactura;

            // Bindings principales
            cbProducto.DataBindings.Add("SelectedValue", _bs, "idproducto", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);
            txtDescripcion.DataBindings.Add("Text", _bs, "descripcion", true, DataSourceUpdateMode.OnPropertyChanged, "");
            numPrecio.DataBindings.Add("Value", _bs, "precio", true, DataSourceUpdateMode.OnPropertyChanged, 0m);
            numTipoIva.DataBindings.Add("Value", _bs, "tipoiva", true, DataSourceUpdateMode.OnPropertyChanged, 0m);
            numCantidad.DataBindings.Add("Value", _bs, "cantidad", true, DataSourceUpdateMode.OnPropertyChanged, 0m);
        }

        /// <summary>
        /// Calcula base, cuota y totales, en función de los datos del formulario.
        /// </summary>
        private void RecalcularLinea()
        {
            if (!(_bs.Current is DataRowView row))
                return;
            decimal unidades = numCantidad.Value;
            decimal precio = numPrecio.Value;
            decimal tipoIva = numTipoIva.Value;

            decimal baseLinea = Math.Round(unidades * precio, 2);
            decimal cuotaLinea = Math.Round(baseLinea * tipoIva / 100, 2);
            decimal totalLinea = baseLinea + cuotaLinea;

            row["base"] = baseLinea;
            row["cuota"] = cuotaLinea;

            lbBase.Text = $"{baseLinea:N2} €";
            lbCuota.Text = $"{cuotaLinea:N2} €";
            lbTotal.Text = $"{totalLinea:N2} €";
        }

        /// <summary>
        /// Carga los productos en el formulario de productos.
        /// </summary>
        private void CargarProductos()
        {
            _tablaProductos = new Tabla(Program.appDAM.LaConexion);
            // Sentencia SQL para obtener los productos
            string mSql = @"SELECT p.id, p.descripcion, p.preciounidad, p.activo as producto_activo,
                            t.porcentaje as iva_porcentaje, t.activo as iva_activo from productos p
                            LEFT JOIN tiposiva t ON t.id = p.idtipoiva ORDER BY p.descripcion";

            if (!_tablaProductos.InicializarDatos(mSql))
            {
                MessageBox.Show("No se han podido cargar los productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            _bsProductos = new BindingSource { DataSource = _tablaProductos.LaTabla };

            cbProducto.DataSource = _bsProductos;
            cbProducto.DisplayMember = "descripcion";
            cbProducto.ValueMember = "id";
            cbProducto.SelectedIndex = -1;
        }

        /// <summary>
        /// Traslada los datos del producto seleccionado a la línea de factura.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void TrasladarDatosProducto()
        {
            if (!(_bsProductos.Current is DataRowView row))
                return;

            // Precio
            numPrecio.Value = Convert.ToDecimal(row["preciounidad"]);
            // Tipo IVA
            numTipoIva.Value = Convert.ToDecimal(row["iva_porcentaje"]);
            // Descripción
            txtDescripcion.Text = row["descripcion"].ToString();
        }

        /// <summary>
        /// Validar la línea de factura antes de guardarla
        /// </summary>
        /// <returns>Retorna true si es válida, false en caso contrario</returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool ValidarLinea()
        {
            if (!(_bs.Current is DataRowView row))
                return false;

            if (row["idproducto"] == DBNull.Value)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Metodo para forzar que ciertos campos no queden nulos en la línea de factura
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void ForzarNoNulosLinea()
        {
            if (!(_bs.Current is DataRowView row))
            return;

            if (row["cantidad"] == DBNull.Value) row["cantidad"] = numCantidad.Value;
            if (row["precio"] == DBNull.Value) row["precio"] = numPrecio.Value;
            if (row["tipoiva"] == DBNull.Value) row["tipoiva"] = numTipoIva.Value;
        }

        #endregion
    }
}
