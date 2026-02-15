using FacturacionDAM.Modelos;
using FacturacionDAM.Utils;
using Mysqlx.Resultset;
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
    public partial class FrmBrowFacrec : Form
    {
        private Tabla _tablaProveedores;                   // Tabla de proveedors
        private BindingSource _bsProveedores;              // BindingSource de proveedors
        private Tabla _tablaFacturas;                   // Tabla de facturas recibidas
        private BindingSource _bsFacturas;              // BindingSource de facturas recibidas
        private YearManager _year;                      // Gestor de años
        private int _idProveedorSeleccionado = -1;        // Id del proveedor seleccionado

        #region Constructores
        /// <summary>
        /// Constructor generico
        /// </summary>
        public FrmBrowFacrec()
        {
            InitializeComponent();
            _year = new YearManager(DateTime.Now.Year, 2000, DateTime.Now.Year + 1);
        }
        #endregion

        #region Eventos del Formulario

        /// <summary>
        /// Metodo Load del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBrowFacrec_Load(object sender, EventArgs e)
        {
            if (!CargarProveedores())
            {
                MessageBox.Show("No se pudieron cargar los proveedores.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CargarAnhosDisponibles();

            int anhoGuardado = Properties.Settings.Default.UltimoAnhoSeleccionado;
            if (anhoGuardado > 0 && tsCbYear.Items.Contains(anhoGuardado.ToString()))
            {
                tsCbYear.SelectedItem = anhoGuardado.ToString();
                _year.CurrentYear = anhoGuardado;
            }

            CargarFacturasProveedorYAnho(_year.CurrentYear);
        }

        /// <summary>
        /// Evento del cierre del formulario para guardar el estado de la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBrowFacrec_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfiguracionVentana.Guardar(this, "BrowFacrec");
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

            // Cargamos las facturas del año y proveedor
            CargarFacturasProveedorYAnho(_year.CurrentYear);
        }

        /// <summary>
        /// Evento al mostrarse el formulario para restaurar el estado de la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBrowFacrec_Shown(object sender, EventArgs e)
        {
            ConfiguracionVentana.Restaurar(this, "BrowFacrec");
        }

        /// <summary>
        /// Evento al cambiar la seleccion del proveedor en el datagrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgProveedores_SelectionChanged(object sender, EventArgs e)
        {
            CargarFacturasProveedorYAnho(_year.CurrentYear);
        }

        #endregion

        #region Botones y Controles

        /// <summary>
        /// Evento click del boton de nueva factura.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_bsFacturas == null) return;
            _bsFacturas.AddNew();

            int nuevoIdFactura = -1;

            FrmFacrec frm = new FrmFacrec(_bsFacturas, _tablaFacturas, Program.appDAM.emisor.id,
                _idProveedorSeleccionado, _year.CurrentYear);

            frm.Text = "Nueva Factura Recibida";

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                nuevoIdFactura = frm.idFactura;
                _tablaFacturas.Refrescar();
                CargarAnhosDisponibles();
            }

            CargarFacturasProveedorYAnho(_year.CurrentYear);

            if (nuevoIdFactura != -1)
            {
                int idx = _bsFacturas.Find("id", nuevoIdFactura);
                if (idx >= 0)
                    _bsFacturas.Position = idx;
            }
        }

        /// <summary>
        /// Evento click del boton de editar factura.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!(_bsFacturas.Current is DataRowView)) return;
            {
                DataRowView row = (DataRowView)_bsFacturas.Current;
                int idFactura = Convert.ToInt32(row["id"]);

                FrmFacrec frm = new FrmFacrec(_bsFacturas, _tablaFacturas, Program.appDAM.emisor.id,
                    _idProveedorSeleccionado, _year.CurrentYear, idFactura);

                frm.Text = "Editar Factura Recibida";

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    _tablaFacturas.Refrescar();
                    CargarAnhosDisponibles();
                }

                CargarFacturasProveedorYAnho(_year.CurrentYear);

                int idx = _bsFacturas.Find("id", idFactura);
                if (idx >= 0)
                    _bsFacturas.Position = idx;
            }
        }

        /// <summary>
        /// Evento click del boton de borrar factura.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!(_bsFacturas.Current is DataRowView row)) return;

            if (MessageBox.Show("¿Eliminar la factura seleccionada?\nSe eliminarán también las líneas de factura",
                    "Confirmar Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                int idFactura = Convert.ToInt32(row["id"]);

                Tabla tFac = new Tabla(Program.appDAM.LaConexion);

                tFac.EjecutarComando("DELETE FROM facrec WHERE id = @id", new() { { "@id", idFactura } });

                CargarFacturasProveedorYAnho(_year.CurrentYear);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar: " + ex.Message);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e) => _bsFacturas.MoveFirst();

        private void btnPrev_Click(object sender, EventArgs e) => _bsFacturas.MovePrevious();

        private void btnNext_Click(object sender, EventArgs e) => _bsFacturas.MoveNext();

        private void btnLast_Click(object sender, EventArgs e) => _bsFacturas.MoveLast();

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
                ExportarDatos.ExportarXML((DataTable)_bsFacturas.DataSource, saveFileDialog.FileName, "Facturas Recibidas");
        }

        #endregion

        #region Metodos Personales

        /// <summary>
        /// Metodo para cargar los proveedors en el datagrid.
        /// </summary>
        /// <returns></returns>
        private bool CargarProveedores()
        {
            String sql = @"SELECT id, nifcif, nombrecomercial
                            FROM proveedores ORDER BY nombrecomercial";
            _tablaProveedores = new Tabla(Program.appDAM.LaConexion);
            if (_tablaProveedores.InicializarDatos(sql))
            {
                try
                {
                    _bsProveedores = new BindingSource { DataSource = _tablaProveedores.LaTabla };
                    dgProveedores.DataSource = _bsProveedores;

                    dgProveedores.Columns["id"].Visible = false;
                    dgProveedores.Columns["nifcif"].HeaderText = "NIF/CIF";
                    dgProveedores.Columns["nifcif"].Width = 100;
                    dgProveedores.Columns["nombrecomercial"].HeaderText = "Nombre Comercial";
                    dgProveedores.Columns["nombrecomercial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgProveedores.MultiSelect = false;

                    dgProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgProveedores.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                    dgProveedores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(185, 218, 247);
                    dgProveedores.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(185, 218, 247);
                    dgProveedores.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgProveedores.ColumnHeadersDefaultCellStyle.ForeColor;
                    dgProveedores.EnableHeadersVisualStyles = false;

                    dgProveedores.ColumnHeadersDefaultCellStyle.Font = new Font(dgProveedores.Font.FontFamily, 10, FontStyle.Bold);

                    dgProveedores.ColumnHeadersHeight = 40;
                    dgProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                    dgProveedores.RowHeadersVisible = false;
                    dgProveedores.AllowUserToResizeRows = false;

                    return true;
                }
                catch (Exception ex)
                {
                    Program.appDAM.RegistrarLog("FrmBrowFacrec.CargarProveedores", ex.Message);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Metodo para cargar las facturas del proveedor seleccionado y el año indicado.
        /// </summary>
        /// <param name="aAnho"></param>
        private void CargarFacturasProveedorYAnho(int aAnho)
        {
            if (!(_bsProveedores.Current is DataRowView cli))
            {
                dgFacrec.DataSource = null;
                tsStatusLabel.Text = "Facturas: 0";
                tsLbBaseTotal.Text = "Base Total: 0.00 €";
                tsLbTotalIVA.Text = "Total IVA: 0.00 €";
                tsLbTotalFacturas.Text = "Total Facturas: 0.00 €";
                lbHeadFacrec.Text = "FACTURAS";
                return;
            }

            _idProveedorSeleccionado = Convert.ToInt32(cli["id"]);

            String mSql = $@"SELECT id, idemisor, idproveedor, idconceptofac, numero, fecha,
                                    descripcion, base, cuota, total, retencion, pagada, tiporet,
                                    aplicaret, notas
                            FROM facrec
                            WHERE idproveedor = {_idProveedorSeleccionado}
                            AND idemisor = {Program.appDAM.emisor.id}
                            AND YEAR(fecha) = {aAnho}
                            ORDER BY fecha DESC, id DESC";
            _tablaFacturas = new Tabla(Program.appDAM.LaConexion);
            if (_tablaFacturas.InicializarDatos(mSql))
            {
                try
                {
                    _bsFacturas = new BindingSource { DataSource = _tablaFacturas.LaTabla };
                    dgFacrec.DataSource = _bsFacturas;

                    dgFacrec.Columns["id"].Visible = false;
                    dgFacrec.Columns["idemisor"].Visible = false;
                    dgFacrec.Columns["idproveedor"].Visible = false;
                    dgFacrec.Columns["idconceptofac"].Visible = false;
                    dgFacrec.Columns["notas"].Visible = false;
                    dgFacrec.Columns["tiporet"].Visible = false;
                    dgFacrec.Columns["aplicaret"].Visible = false;

                    dgFacrec.Columns["numero"].HeaderText = "Nº";
                    dgFacrec.Columns["numero"].Width = 70;
                    dgFacrec.Columns["numero"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgFacrec.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgFacrec.Columns["fecha"].HeaderText = "Fecha";
                    dgFacrec.Columns["fecha"].Width = 110;
                    dgFacrec.Columns["fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgFacrec.Columns["fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgFacrec.Columns["descripcion"].HeaderText = "Descripción";
                    dgFacrec.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgFacrec.Columns["base"].HeaderText = "Base";
                    dgFacrec.Columns["base"].Width = 100;
                    dgFacrec.Columns["base"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgFacrec.Columns["base"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgFacrec.Columns["base"].DefaultCellStyle.Padding = new Padding(0, 0, 10, 0);
                    dgFacrec.Columns["cuota"].HeaderText = "Cuota";
                    dgFacrec.Columns["cuota"].Width = 100;
                    dgFacrec.Columns["cuota"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgFacrec.Columns["cuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgFacrec.Columns["cuota"].DefaultCellStyle.Padding = new Padding(0, 0, 10, 0);
                    dgFacrec.Columns["total"].HeaderText = "Total";
                    dgFacrec.Columns["total"].Width = 100;
                    dgFacrec.Columns["total"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgFacrec.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgFacrec.Columns["total"].DefaultCellStyle.Padding = new Padding(0, 0, 10, 0);
                    dgFacrec.Columns["retencion"].HeaderText = "Retención";
                    dgFacrec.Columns["retencion"].Width = 100;
                    dgFacrec.Columns["retencion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgFacrec.Columns["retencion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgFacrec.Columns["retencion"].DefaultCellStyle.Padding = new Padding(0, 0, 10, 0);
                    dgFacrec.Columns["pagada"].HeaderText = "Pagada";
                    dgFacrec.Columns["pagada"].Width = 100;
                    dgFacrec.Columns["pagada"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgFacrec.Columns["pagada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgFacrec.Columns["pagada"].ReadOnly = true;

                    dgFacrec.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgFacrec.MultiSelect = false;

                    dgFacrec.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                    dgFacrec.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(185, 218, 247);
                    dgFacrec.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(185, 218, 247);
                    dgFacrec.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgFacrec.ColumnHeadersDefaultCellStyle.ForeColor;
                    dgFacrec.EnableHeadersVisualStyles = false;
                    dgFacrec.ColumnHeadersDefaultCellStyle.Font = new Font(dgFacrec.Font.FontFamily, 10, FontStyle.Bold);
                    dgFacrec.ColumnHeadersHeight = 40;
                    dgFacrec.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                    dgFacrec.RowHeadersVisible = false;
                    dgFacrec.AllowUserToResizeRows = false;

                    String nombreProveedor = cli["nombrecomercial"].ToString();

                    lbHeadFacrec.Text = $"Facturas de {nombreProveedor}, en el año {_year.CurrentYear}";
                    tsStatusLabel.Text = $"Facturas: {_bsFacturas.Count}";
                    // Cálculo de totales
                    decimal baseTotal = 0;
                    decimal totalIVA = 0;
                    decimal totalFacturas = 0;
                    foreach (DataRow fila in _tablaFacturas.LaTabla.Rows)
                    {
                        baseTotal += Convert.ToDecimal(fila["base"]);
                        totalIVA += Convert.ToDecimal(fila["cuota"]);
                        totalFacturas += Convert.ToDecimal(fila["total"]);
                    }
                    tsLbBaseTotal.Text = $"Base Total: {baseTotal:N2} €";
                    tsLbTotalIVA.Text = $"Total IVA: {totalIVA:N2} €";
                    tsLbTotalFacturas.Text = $"Total Facturas: {totalFacturas:N2} €";
                }
                catch (Exception ex)
                {
                    Program.appDAM.RegistrarLog("Cargando facturas recibidas", ex.Message);
                    MessageBox.Show(
                        "No se pudieron cargar las facturas",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    tsStatusLabel.Text = "Facturas: 0";
                }
            }
        }

        /// <summary>
        /// Recarga el ComboBox de años buscando en la base de datos.
        /// Mantiene la selección actual si es posible.
        /// </summary>
        private void CargarAnhosDisponibles()
        {
            // 1. Guardamos la selección actual para intentar restaurarla luego
            string seleccionPrevia = tsCbYear.SelectedItem != null ? tsCbYear.SelectedItem.ToString() : null;

            tsCbYear.Items.Clear();

            // 2. Consulta a la base de datos
            string sqlYears = $@"SELECT DISTINCT YEAR(fecha) as anho 
                         FROM facrec 
                         WHERE idemisor = {Program.appDAM.emisor.id} 
                         ORDER BY anho DESC";

            Tabla tYears = new Tabla(Program.appDAM.LaConexion);

            if (tYears.InicializarDatos(sqlYears) && tYears.LaTabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tYears.LaTabla.Rows)
                {
                    tsCbYear.Items.Add(fila["anho"].ToString());
                }
            }
            else
            {
                // Si no hay facturas, ponemos el año actual
                tsCbYear.Items.Add(DateTime.Now.Year.ToString());
            }

            // 3. Restaurar la selección
            if (seleccionPrevia != null && tsCbYear.Items.Contains(seleccionPrevia))
            {
                tsCbYear.SelectedItem = seleccionPrevia;
            }
            else if (tsCbYear.Items.Count > 0)
            {
                // Si la selección previa ya no existe o es nula, seleccionamos el primero
                tsCbYear.SelectedIndex = 0;
                _year.CurrentYear = int.Parse(tsCbYear.SelectedItem.ToString());
            }
        }

        #endregion

    }
}
