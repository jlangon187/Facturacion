using FacturacionDAM.Modelos;
using FacturacionDAM.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmFacemi : Form
    {
        private BindingSource _bsFactura;
        private BindingSource _bsLineasFacturas;
        private Tabla _tablaFactura;
        private Tabla _tablaLineasFacturas;
        private Tabla _tablaConceptos;


        private int _idEmisor = -1;
        private int _idCliente = -1;
        private int _anhoFactura = -1;

        public int idFactura = -1;
        public bool modoEdicion = false;

        #region Constructores
        /// <summary>
        /// Constructor generico
        /// </summary>
        public FrmFacemi()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor para crear o editar una factura
        /// </summary>
        /// <param name="aBs"></param>
        /// <param name="aTabla"></param>
        /// <param name="aIdEmisor"></param>
        /// <param name="aIdCliente"></param>
        /// <param name="aYear"></param>
        /// <param name="aIdFactura"></param>
        public FrmFacemi(BindingSource aBs, Tabla aTabla, int aIdEmisor,
            int aIdCliente, int aYear, int aIdFactura = -1)
        {
            InitializeComponent();

            _idEmisor = aIdEmisor;
            _idCliente = aIdCliente;
            _anhoFactura = aYear;
            idFactura = aIdFactura;

            modoEdicion = (aIdFactura != -1);

            _bsFactura = aBs;
            _tablaFactura = aTabla;

            InitFactura();
        }

        #endregion

        #region Eventos del Formulario
        /// <summary>
        /// Evento Load del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFacemi_Load(object sender, EventArgs e)
        {
            try
            {
                if (!CargarConceptos() || !CargarDatosEmisorYCliente())
                    return;

                PrepararBindingFactura();

                if (modoEdicion)
                    CargarLineasFacturaExistente();
                else
                    CrearLineasFacturaNueva();

                PrepararBindingLineas();
                RecalcularTotales();
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Inicializar factura. Edicion: " + modoEdicion.ToString(), ex.Message);
                MessageBox.Show("Error al inicializar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento del formulario cuando se cierra.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFacemi_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Si se cierra sin aceptar (DialogResult.OK), cancelamos la edicion.
            if ((this.DialogResult != DialogResult.OK) && _bsFactura != null)
                _bsFactura.CancelEdit();
        }
        #endregion

        #region Botones
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (GuardarFactura())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            bool mCrearNuevaLinea = false;
            if (!modoEdicion)
            {
                if (MessageBox.Show(
                            "No ha guardado la nueva factura.\n" +
                            "¿Guardar la nueva factura antes crear la línea de facturación?",
                            "Confirmación", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)

                    mCrearNuevaLinea = GuardarFactura();
            }
            else
                mCrearNuevaLinea = true;

            if (mCrearNuevaLinea)
            {
                _bsLineasFacturas.AddNew();

                FrmLineaFacemi frm = new FrmLineaFacemi(_bsLineasFacturas, _tablaLineasFacturas, idFactura);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    _tablaLineasFacturas.Refrescar();
                    ActualizarEstado();
                    RecalcularTotales();
                }
                else
                    _bsLineasFacturas.CancelEdit();
            }
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (_bsLineasFacturas.Current is DataRowView)
            {
                FrmLineaFacemi frm = new FrmLineaFacemi(_bsLineasFacturas, _tablaLineasFacturas, idFactura, true);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    _tablaLineasFacturas.Refrescar();
                    ActualizarEstado();
                    RecalcularTotales();
                }
            }
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (!(_bsLineasFacturas.Current is DataRowView)) return;

            if (MessageBox.Show("¿Eliminar la línea de factura seleccionada?",
                "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            _bsLineasFacturas.RemoveCurrent();
            _tablaLineasFacturas.GuardarDatos();

            ActualizarEstado();
            RecalcularTotales();
        }


        private void btnFirst_Click(object sender, EventArgs e) => _bsLineasFacturas.MoveFirst();
        private void btnPrev_Click(object sender, EventArgs e) => _bsLineasFacturas.MovePrevious();
        private void btnNext_Click(object sender, EventArgs e) => _bsLineasFacturas.MoveNext();
        private void btnLast_Click(object sender, EventArgs e) => _bsLineasFacturas.MoveLast();

        /// <summary>
        /// Metodo para exportar los datos de las facturas a CSV.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                ExportarDatos.ExportarCSV((DataTable)_bsLineasFacturas.DataSource, saveFileDialog.FileName);
        }

        /// <summary>
        /// Metodo para exportar los datos de las facturas a XML.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                ExportarDatos.ExportarXML((DataTable)_bsLineasFacturas.DataSource, saveFileDialog.FileName, "Líneas de Facuras Emitidas");
        }

        #endregion

        #region Metodos Personales

        /// <summary>
        /// Guardar factura
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool GuardarFactura()
        {
            try
            {
                if (!ValidarDatos())
                    return false;
                else
                {
                    ForzarValoresNoNulos();
                    _bsFactura.EndEdit();
                    _tablaFactura.GuardarDatos();

                    if (!modoEdicion)
                    {
                        using (var cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", Program.appDAM.LaConexion))
                        {
                            object res = cmd.ExecuteScalar();
                            idFactura = Convert.ToInt32(res);
                        }
                        ActulizarNumeracionEmisor();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Guardar una factura", ex.Message);
                MessageBox.Show("Se ha producido un error al guardar la factura.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Actualizamos el siguiente numero de factura (nextnumfac) del emisor actual.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void ActulizarNumeracionEmisor()
        {
            string mSql = "UPDATE emisores SET nextnumfac + 1 WHERE id=@id";
            _tablaFactura.EjecutarComando(mSql, new() { { "@id", Program.appDAM.emisor.id } });
            Program.appDAM.emisor.nextNumFac++;
        }

        /// <summary>
        /// Me aseguro que no envia valores nulos a la base de datos para los siguientes campos
        /// </summary>
        private void ForzarValoresNoNulos()
        {
            if (_bsFactura.Current is DataRowView row)
            {
                // Tipo de retencion nunca puede ser nulo
                if (row["tiporet"] == DBNull.Value)
                    row["tiporet"] = tipoRetencion.Value;

                // Pagada y AplicaRet nunca puede ser nulo
                if (row["pagada"] == DBNull.Value)
                    row["pagada"] = chkPagada.Checked ? 1 : 0;

                if (row["aplicaret"] == DBNull.Value)
                    row["aplicaret"] = chkRetencion.Checked ? 1 : 0;
            }
        }

        private bool ValidarDatos()
        {
            return true;
        }

        /// <summary>
        /// Metodo para actualizar el estado del statusbar
        /// </summary>
        private void ActualizarEstado()
        {
            tsStatusLabel.Text = $"Nº de Registros: {_bsLineasFacturas.Count}";   // Actualiza la barra de estado
        }

        /// <summary>
        /// Creamos e inicializamos los objetos necesarios para la gestion de la factura.
        /// </summary>
        private void InitFactura()
        {
            // Crear objetos.
            _tablaLineasFacturas = new Tabla(Program.appDAM.LaConexion);
            _tablaConceptos = new Tabla(Program.appDAM.LaConexion);
            _bsLineasFacturas = new BindingSource();

            // Campos básicos.
            lbNIFCIFCliente.Text = "";
            lbNIFCIFEmisor.Text = "";
            lbNombreCliente.Text = "";
            lbNombreEmisor.Text = "";
            txtNumero.Text = "";
            fechaFactura.Value = DateTime.Now;
            txtDescripcion.Text = "";
            chkPagada.Checked = false;
            tipoRetencion.Value = 0;

            // Reseteamos totales
            lbBase.Text = "";
            lbCuota.Text = "";
            lbTotal.Text = "";
            lbRetencion.Text = "";
        }

        /// <summary>
        /// Carga lor conceptos de factura en el combo correspondiente
        /// </summary>
        /// <returns></returns>
        private bool CargarConceptos()
        {
            if (_tablaConceptos.InicializarDatos("SELECT id, descripcion FROM conceptosfac ORDER BY descripcion"))
            {
                cbConceptFac.DataSource = _tablaConceptos.LaTabla;
                cbConceptFac.DisplayMember = "descripcion";
                cbConceptFac.ValueMember = "id";

                return true;
            }
            else
            {
                cbConceptFac.Enabled = false;
                return false;
            }
        }

        /// <summary>
        /// Carga los datos del emisor y del cliente en la factura
        /// </summary>
        /// <returns>Retorna true si se han cargado correctamente los datos</returns>
        private bool CargarDatosEmisorYCliente()
        {
            // Datos del emisor
            lbNIFCIFEmisor.Text = Program.appDAM.emisor.nifcif;
            lbNombreEmisor.Text = Program.appDAM.emisor.nombreComercial;

            // Cargar cliente
            Tabla tCli = new Tabla(Program.appDAM.LaConexion);
            if (tCli.InicializarDatos($"SELECT id, nifcif, nombrecomercial FROM clientes WHERE id ={_idCliente}"))
            {
                lbNIFCIFCliente.Text = tCli.LaTabla.Rows[0]["nifcif"].ToString();
                lbNombreCliente.Text = tCli.LaTabla.Rows[0]["nombrecomercial"].ToString();

                if (modoEdicion)
                    return true;
                else if (_bsFactura.Current is DataRowView row)
                {
                    row["idemisor"] = Program.appDAM.emisor.id;
                    row["idcliente"] = _idCliente;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Prepara los bindings de la factura
        /// </summary>
        private void PrepararBindingFactura()
        {
            if (_bsFactura.Current is DataRowView row)
            {
                if (row["fecha"] == DBNull.Value)
                    row["fecha"] = new DateTime(_anhoFactura, DateTime.Today.Month, DateTime.Today.Day);

                if (!modoEdicion)
                {
                    row["numero"] = Program.appDAM.emisor.nextNumFac;
                }
            }

            // Aplicar bindings
            txtNumero.DataBindings.Add("Text", _bsFactura, "numero");
            fechaFactura.DataBindings.Add("Value", _bsFactura, "fecha");
            cbConceptFac.DataBindings.Add("SelectedValue", _bsFactura, "idconceptofac");
            txtDescripcion.DataBindings.Add("Text", _bsFactura, "descripcion");
            chkPagada.DataBindings.Add("Checked", _bsFactura, "pagada", true, DataSourceUpdateMode.OnPropertyChanged);
            chkRetencion.DataBindings.Add("Checked", _bsFactura, "retencion", true, DataSourceUpdateMode.OnPropertyChanged);
            tipoRetencion.DataBindings.Add("Value", _bsFactura, "tiporet", true, DataSourceUpdateMode.OnPropertyChanged, 0.0);
            txtNotas.DataBindings.Add("Text", _bsFactura, "notas");
            lbBase.DataBindings.Add("Text", _bsFactura, "base", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
            lbCuota.DataBindings.Add("Text", _bsFactura, "cuota", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
            lbTotal.DataBindings.Add("Text", _bsFactura, "total", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
            lbRetencion.DataBindings.Add("Text", _bsFactura, "retencion", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
        }

        /// <summary>
        /// Metodo para crear las lineas de una factura nueva
        /// </summary>
        private void CrearLineasFacturaNueva()
        {
            string eSql = $"SELECT * FROM facemilin WHERE id = -1";
            if (_tablaLineasFacturas.InicializarDatos(eSql))
                _bsLineasFacturas.DataSource = _tablaLineasFacturas.LaTabla;
        }

        /// <summary>
        /// Metodo para cargar las lineas de una factura existente
        /// </summary>
        private void CargarLineasFacturaExistente()
        {
            string eSql = $"SELECT * FROM facemilin WHERE idfacemi = {idFactura}";
            if (_tablaLineasFacturas.InicializarDatos(eSql))
                _bsLineasFacturas.DataSource = _tablaLineasFacturas.LaTabla;
        }

        /// <summary>
        /// Metodo para preparar los bindings de las lineas de factura
        /// </summary>
        private void PrepararBindingLineas()
        {
            dgLineasFactura.DataSource = _bsLineasFacturas;
            dgLineasFactura.Columns["id"].Visible = false;
            dgLineasFactura.Columns["idfacemi"].Visible = false;

            dgLineasFactura.Columns["descripcion"].HeaderText = "Descripción";
            dgLineasFactura.Columns["cantidad"].HeaderText = "Cantidad";
            dgLineasFactura.Columns["precio"].HeaderText = "Precio";
            dgLineasFactura.Columns["base"].HeaderText = "Base";
            dgLineasFactura.Columns["tipoiva"].HeaderText = "IVA %";
            dgLineasFactura.Columns["cuota"].HeaderText = "Cuota IVA";
        }

        /// <summary>
        /// Metodo para recalcular los totales de la factura
        /// </summary>
        private void RecalcularTotales()
        {
            decimal baseSum = 0;
            decimal cuotaSum = 0;
            foreach (DataRow fila in _tablaLineasFacturas.LaTabla.Rows)
            {
                baseSum += fila.Field<decimal>("base");
                cuotaSum += fila.Field<decimal>("cuota");
            }

            decimal total = baseSum + cuotaSum;
            decimal tiporet = chkRetencion.Checked ? tipoRetencion.Value : 0;
            decimal retencion = Math.Round(baseSum * (tiporet / 100), 2);

            DataRowView row = (DataRowView)_bsFactura.Current;
            row["base"] = baseSum;
            row["cuota"] = cuotaSum;
            row["total"] = total - retencion;
            row["retencion"] = retencion;

        }

        #endregion
    }
}
