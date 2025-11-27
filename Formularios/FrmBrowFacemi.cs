using FacturacionDAM.Modelos;
using FacturacionDAM.Utils;
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
    public partial class FrmBrowFacemi : Form
    {
        private Tabla _tablaClientes;
        private BindingSource _bsClientes;

        private Tabla _tablaFacturas;
        private BindingSource _bsFacturas;

        private YearManager _year;

        public FrmBrowFacemi()
        {
            InitializeComponent();
            _year = new YearManager(DateTime.Now.Year, 2000, DateTime.Now.Year + 1);
        }

        private void FrmBrowFacemi_Load(object sender, EventArgs e)
        {
            if (!CargarClientes())
            {
                MessageBox.Show("No se pudieron cargar los clientes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ajustamos los años disponibles en el combo
            tsCbYear.Items.Clear();
            tsCbYear.Items.AddRange(
                _year.GetYearList().Select(y => y.ToString()).ToArray()
            );

            int anho = Properties.Settings.Default.UltimoAnhoSeleccionado;
            if (anho > 0)
                _year.CurrentYear = anho;

            tsCbYear.SelectedItem = _year.CurrentYear.ToString();

            CargarFacturasClienteYAnho(_year.CurrentYear);
        }

        /// <summary>
        /// Evento del cierre del formulario para guardar el estado de la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBrowFacemi_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfiguracionVentana.Guardar(this, "BrowFacemi");
            Properties.Settings.Default.UltimoAnhoSeleccionado = _year.CurrentYear;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Evento de seleccion de un año en el combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsCbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tsCbYear.SelectedIndex == null)
                return;

            int newYear = int.Parse(tsCbYear.SelectedItem.ToString());
            _year.CurrentYear = newYear;

            // Cargamos las facturas del año y cliente
            CargarFacturasClienteYAnho(_year.CurrentYear);
        }

        /// <summary>
        /// Evento al mostrarse el formulario para restaurar el estado de la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBrowFacemi_Shown(object sender, EventArgs e)
        {
            ConfiguracionVentana.Restaurar(this, "BrowFacemi");
        }

        private void btnFirst_Click(object sender, EventArgs e) => _bsFacturas.MoveFirst();

        private void btnPrev_Click(object sender, EventArgs e) => _bsFacturas.MovePrevious();

        private void btnNext_Click(object sender, EventArgs e) => _bsFacturas.MoveNext();

        private void btnLast_Click(object sender, EventArgs e) => _bsFacturas.MoveLast();

        /************* METODOS PRIVADOS *************/

        /// <summary>
        /// Metodo para cargar los clientes en el datagrid.
        /// </summary>
        /// <returns></returns>
        private bool CargarClientes()
        {
            String sql = @"SELECT id, nifcif, nombrecomercial
                            FROM clientes ORDER BY nombrecomercial";
            _tablaClientes = new Tabla(Program.appDAM.LaConexion);
            if (_tablaClientes.InicializarDatos(sql))
            {
                try
                {
                    _bsClientes = new BindingSource { DataSource = _tablaClientes.LaTabla };
                    dgClientes.DataSource = _bsClientes;

                    dgClientes.Columns["id"].Visible = false;
                    dgClientes.Columns["nifcif"].HeaderText = "NIF/CIF";
                    dgClientes.Columns["nifcif"].Width = 100;
                    dgClientes.Columns["nombrecomercial"].HeaderText = "Nombre Comercial";
                    dgClientes.Columns["nombrecomercial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgClientes.MultiSelect = false;

                    return true;
                }
                catch (Exception ex)
                {
                    Program.appDAM.RegistrarLog("FrmBrowFacemi.CargarClientes", ex.Message);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Metodo para cargar las facturas del cliente seleccionado y el año indicado.
        /// </summary>
        /// <param name="aAnho"></param>
        private void CargarFacturasClienteYAnho(int aAnho)
        {
            if (!(_bsClientes.Current is DataRowView cli))
            {
                dgFacemi.DataSource = null;
                tsStatusLabel.Text = "Facturas: 0";
                lbHeadFacemi.Text = "FACTURAS";
                return;
            }

            int idCliente = Convert.ToInt32(cli["id"]);

            String mSql = $@"SELECT id, numero, fecha, descripcion, base, cuota, total, retencion, pagada
                            FROM facemi
                            WHERE idcliente = {idCliente}
                            AND YEAR(fecha) = {aAnho}
                            ORDER BY fecha DESC";
            _tablaFacturas = new Tabla(Program.appDAM.LaConexion);
            if (_tablaFacturas.InicializarDatos(mSql)) 
            {
                try
                {
                    _bsFacturas = new BindingSource { DataSource = _tablaFacturas.LaTabla };
                    dgFacemi.DataSource = _bsFacturas;

                    dgFacemi.Columns["id"].Visible = false;

                    String nombreCliente = cli["nombrecomercial"].ToString();

                    lbHeadFacemi.Text = $"Facturas de {nombreCliente}, en el año {_year.CurrentYear}";
                    tsStatusLabel.Text = $"Facturas: {_bsFacturas.Count}";
                }
                catch (Exception ex)
                {
                    Program.appDAM.RegistrarLog("Cargando facturas emitidas", ex.Message);
                    MessageBox.Show(
                        "No se pudieron cargar las facturas",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error );

                    tsStatusLabel.Text = "Facturas: 0";
                }
            }
        }

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
                ExportarDatos.ExportarCSV((DataTable)_bsFacturas.DataSource, saveFileDialog.FileName);
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
                ExportarDatos.ExportarXML((DataTable)_bsFacturas.DataSource, saveFileDialog.FileName, "Facturas Emitidas");
        }
    }
}
