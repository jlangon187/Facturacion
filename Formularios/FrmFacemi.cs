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
    public partial class FrmFacemi : Form
    {
        private BindingSource _bsFactura;
        private BindingSource _bsLineasFacturas;
        private Tabla _tablaFactura;
        private Tabla _tablaLineasFacturas;
        private Tabla _tablaConceptos;

        private int _idFactura = -1;
        private int _idEmisor = -1;
        private int _idCliente = -1;
        private int _anhoFactura = -1;

        public bool modoEdicion = false;

        /// <summary>
        /// Constructor generico
        /// </summary>
        public FrmFacemi()
        {
            InitializeComponent();
        }

        public FrmFacemi(BindingSource aBs, Tabla aTabla, int aIdEmisor,
            int aIdCliente, int aYear, int aIdFactura = -1)
        {
            InitializeComponent();

            _idEmisor = aIdEmisor;
            _idCliente = aIdCliente;
            _anhoFactura = aYear;
            _idFactura = aIdFactura;

            modoEdicion = (aIdFactura != -1);

            _bsFactura = aBs;
            _tablaFactura = aTabla;

            InitFactura();
        }

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
                return true;
            }
            return false;
        }

        private void PrepararBindingFactura()
        {
            if(_bsFactura.Current is DataRowView row)
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
            cbConceptFac.DataBindings.Add("SelectedValue", _bsFactura, "idconceptfac");
            txtDescripcion.DataBindings.Add("Text", _bsFactura, "descripcion");
        }

        private void RecalcularTotales()
        {
        }

        private void PrepararBindingLineas()
        {
        }

        private void CrearLineasFacturaNueva()
        {
        }

        private void CargarLineasFacturaExistente()
        {
        }

        #region Metodos Privados

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


        #endregion

    }
}
