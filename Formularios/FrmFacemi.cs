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

            ConfigurarDisenoResponsivo();

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
                ConfigurarEventosCambio();
                RecalcularTotales();
                ActualizarEstado();
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
            if (this.DialogResult == DialogResult.OK ||
                this.DialogResult == DialogResult.Cancel)
                return;

            DialogResult res = MessageBox.Show(
            "Hay cambios sin guardar.\n¿Desea salir sin guardar?",
            "Confirmación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (res == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
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
        private void btnNew_Click(object sender, EventArgs e)
        {
            bool mCrearNuevaLinea = false;

            if (!modoEdicion)
            {
                if (MessageBox.Show("No ha guardado la nueva factura.\n¿Guardar antes crear la línea?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (GuardarFactura())
                    {
                        // Al guardar, ya tenemos ID real. Actualizamos la consulta de líneas.
                        string nuevaSql = $"SELECT * FROM facemilin WHERE idfacemi = {idFactura}";
                        _tablaLineasFacturas.InicializarDatos(nuevaSql);
                        _bsLineasFacturas.DataSource = _tablaLineasFacturas.LaTabla;

                        modoEdicion = true;
                        mCrearNuevaLinea = true;
                    }
                }
            }
            else
            {
                mCrearNuevaLinea = true;
            }

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
                {
                    _bsLineasFacturas.CancelEdit();
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
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
        private void btnDelete_Click(object sender, EventArgs e)
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

                    if (_bsFactura.Current is DataRowView row)
                    {
                        row.BeginEdit();
                        row["id"] = idFactura;
                        row.EndEdit();

                        _tablaFactura.LaTabla.AcceptChanges();
                    }

                    ActulizarNumeracionEmisor();
                }
                return true;
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Guardar una factura", ex.Message);
                MessageBox.Show("Se ha producido un error al guardar la factura: " + ex.Message,
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Actualizamos el siguiente numero de factura (nextnumfac) del emisor actual.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void ActulizarNumeracionEmisor()
        {
            string mSql = "UPDATE emisores SET nextnumfac = nextnumfac + 1 WHERE id=@id";
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

        /// <summary>
        /// Metodo para validar los datos de la factura antes de guardarla
        /// </summary>
        /// <returns></returns>
        private bool ValidarDatos()
        {
            _bsFactura.EndEdit();

            if (_bsFactura.Current is DataRowView row)
            {

                if (row["fecha"] == DBNull.Value)
                {
                    MessageBox.Show("La fecha de la factura no es válida o está vacía.",
                                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fechaFactura.Focus();
                    return false;
                }

                if (row["numero"] == DBNull.Value ||
                    !int.TryParse(row["numero"].ToString(), out int numFactura) ||
                    numFactura <= 0)
                {
                    MessageBox.Show("El número de factura es obligatorio y debe ser mayor que 0.",
                                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNumero.Focus();
                    return false;
                }

                if (row["idconceptofac"] == DBNull.Value)
                {
                    MessageBox.Show("Debe seleccionar un Concepto de facturación.",
                                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbConceptFac.Focus();
                    return false;
                }

                string desc = row["descripcion"] != DBNull.Value ? row["descripcion"].ToString() : "";
                if (string.IsNullOrWhiteSpace(desc))
                {
                    MessageBox.Show("La descripción es obligatoria y no puede estar vacía.",
                                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescripcion.Focus();
                    return false;
                }

                DateTime fecha = Convert.ToDateTime(row["fecha"]);
                if (fecha.Year < 2000)
                {
                    MessageBox.Show("La fecha de la factura no puede ser anterior al año 2000.",
                                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fechaFactura.Focus();
                    return false;
                }
            }

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
                    if (row["numero"] == DBNull.Value || Convert.ToInt32(row["numero"]) == 0)
                    {
                        using (var cmd = new MySqlCommand("SELECT nextnumfac FROM emisores WHERE id = @id", Program.appDAM.LaConexion))
                        {
                            cmd.Parameters.AddWithValue("@id", _idEmisor);
                            object result = cmd.ExecuteScalar();
                            row["numero"] = result != null ? Convert.ToInt32(result) : 1;
                        }
                    }
                }
            }

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

            if (dgLineasFactura.Columns["id"] != null) dgLineasFactura.Columns["id"].Visible = false;
            if (dgLineasFactura.Columns["idfacemi"] != null) dgLineasFactura.Columns["idfacemi"].Visible = false;
            if (dgLineasFactura.Columns["idproducto"] != null) dgLineasFactura.Columns["idproducto"].Visible = false;

            if (dgLineasFactura.Columns["descripcion"] != null) dgLineasFactura.Columns["descripcion"].HeaderText = "Descripción";
            if (dgLineasFactura.Columns["cantidad"] != null) dgLineasFactura.Columns["cantidad"].HeaderText = "Cantidad";
            if (dgLineasFactura.Columns["precio"] != null) dgLineasFactura.Columns["precio"].HeaderText = "Precio Unidad";
            if (dgLineasFactura.Columns["base"] != null) dgLineasFactura.Columns["base"].HeaderText = "Base";
            if (dgLineasFactura.Columns["tipoiva"] != null) dgLineasFactura.Columns["tipoiva"].HeaderText = "IVA %";
            if (dgLineasFactura.Columns["cuota"] != null) dgLineasFactura.Columns["cuota"].HeaderText = "Cuota IVA";

            // Mostrar columnas ordenadas
            dgLineasFactura.Columns["descripcion"].DisplayIndex = 0;
            dgLineasFactura.Columns["cantidad"].DisplayIndex = 1;
            dgLineasFactura.Columns["precio"].DisplayIndex = 2;
            dgLineasFactura.Columns["tipoiva"].DisplayIndex = 3;
            dgLineasFactura.Columns["cuota"].DisplayIndex = 4;
            dgLineasFactura.Columns["base"].DisplayIndex = 5;

            dgLineasFactura.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgLineasFactura.Columns["cantidad"].Width = 80;
            dgLineasFactura.Columns["precio"].Width = 110;
            dgLineasFactura.Columns["tipoiva"].Width = 80;
            dgLineasFactura.Columns["cuota"].Width = 100;
            dgLineasFactura.Columns["base"].Width = 100;

            dgLineasFactura.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgLineasFactura.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(185, 218, 247);
            dgLineasFactura.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(185, 218, 247);
            dgLineasFactura.ColumnHeadersDefaultCellStyle.ForeColor = dgLineasFactura.ColumnHeadersDefaultCellStyle.ForeColor;
            dgLineasFactura.EnableHeadersVisualStyles = false;

            dgLineasFactura.ColumnHeadersDefaultCellStyle.Font = new Font(dgLineasFactura.Font.FontFamily, 10, FontStyle.Bold);

            dgLineasFactura.ColumnHeadersHeight = 30;
            dgLineasFactura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgLineasFactura.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgLineasFactura.RowHeadersVisible = false;
            dgLineasFactura.AllowUserToResizeRows = false;
        }

        /// <summary>
        /// Metodo para recalcular los totales de la factura
        /// </summary>
        private void RecalcularTotales()
        {
            decimal baseSum = 0;
            decimal cuotaSum = 0;

            if (_tablaLineasFacturas != null && _tablaLineasFacturas.LaTabla != null)
            {
                foreach (DataRow fila in _tablaLineasFacturas.LaTabla.Rows)
                {
                    if (fila.RowState == DataRowState.Deleted) continue;
                    if (fila.RowState == DataRowState.Detached) continue;

                    decimal b = fila["base"] != DBNull.Value ? Convert.ToDecimal(fila["base"]) : 0;
                    decimal c = fila["cuota"] != DBNull.Value ? Convert.ToDecimal(fila["cuota"]) : 0;

                    baseSum += b;
                    cuotaSum += c;
                }
            }

            decimal total = baseSum + cuotaSum;
            decimal tiporet = chkRetencion.Checked ? tipoRetencion.Value : 0;
            decimal retencion = Math.Round(baseSum * (tiporet / 100), 2);
            decimal totalFinal = total - retencion;

            if (_bsFactura.Current is DataRowView row)
            {
                row.BeginEdit();
                row["base"] = baseSum;
                row["cuota"] = cuotaSum;
                row["total"] = totalFinal;
                row["retencion"] = retencion;
                row.EndEdit();
            }

            lbBase.Text = baseSum.ToString("N2");
            lbCuota.Text = cuotaSum.ToString("N2");
            lbTotal.Text = totalFinal.ToString("N2");
            lbRetencion.Text = retencion.ToString("N2");
        }

        private void ConfigurarEventosCambio()
        {
            // Cuando cambies el % de retención, recalcula
            tipoRetencion.ValueChanged += (s, e) => RecalcularTotales();

            // Cuando marques/desmarques "Aplica Retención", recalcula
            chkRetencion.CheckedChanged += (s, e) => RecalcularTotales();
        }

        private void ConfigurarDisenoResponsivo()
        {
            // =========================================================================
            // 1. EMISOR Y CLIENTE (gbEmisorCliente)
            // =========================================================================
            TableLayoutPanel tlpEmisor = new TableLayoutPanel();
            tlpEmisor.Dock = DockStyle.Fill;
            // Añadimos Padding al layout para que no toque los bordes del GroupBox
            tlpEmisor.Padding = new Padding(10);
            tlpEmisor.RowCount = 2;
            tlpEmisor.ColumnCount = 4;

            // AJUSTE DE COLUMNAS:
            // Etiquetas fijas, NIFs al 20%, Nombres al 80% (más espacio para nombres)
            tlpEmisor.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpEmisor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
            tlpEmisor.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpEmisor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80f));

            gbEmisorCliente.Controls.Clear();

            // Fila 0
            tlpEmisor.Controls.Add(label1, 0, 0);         // "NIF Emisor:"
            tlpEmisor.Controls.Add(lbNIFCIFEmisor, 1, 0);
            tlpEmisor.Controls.Add(label4, 2, 0);         // "Nombre Emisor:"
            tlpEmisor.Controls.Add(lbNombreEmisor, 3, 0);

            // Fila 1
            tlpEmisor.Controls.Add(label2, 0, 1);         // "NIF Cliente:"
            tlpEmisor.Controls.Add(lbNIFCIFCliente, 1, 1);
            tlpEmisor.Controls.Add(label3, 2, 1);         // "Nombre Cliente:"
            tlpEmisor.Controls.Add(lbNombreCliente, 3, 1);

            // Alineación vertical y márgenes
            foreach (Control c in tlpEmisor.Controls)
            {
                c.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                c.Margin = new Padding(3, 5, 15, 5); // Margen derecho extra para separar columnas
                if (c is Label) ((Label)c).TextAlign = ContentAlignment.MiddleLeft;
            }
            gbEmisorCliente.Controls.Add(tlpEmisor);


            // =========================================================================
            // 2. DATOS FACTURA (gbFacemi)
            // =========================================================================
            TableLayoutPanel tlpDatos = new TableLayoutPanel();
            tlpDatos.Dock = DockStyle.Fill;
            tlpDatos.Padding = new Padding(15, 15, 15, 25); // Padding inferior para dejar hueco
            tlpDatos.RowCount = 3;
            tlpDatos.ColumnCount = 6;

            // DEFINICIÓN DE FILAS (Alto automático)
            tlpDatos.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpDatos.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpDatos.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // COLUMNAS PRINCIPALES (Alineadas con la fila 1: Numero, Fecha, Concepto)
            tlpDatos.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));        // Lbl Num
            tlpDatos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));   // Txt Num
            tlpDatos.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));        // Lbl Fecha
            tlpDatos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110f));  // DatePicker
            tlpDatos.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));        // Lbl Concepto
            tlpDatos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));   // Combo (el resto)

            gbFacemi.Controls.Clear();

            // --- FILA 0: CABECERA ---
            tlpDatos.Controls.Add(label5, 0, 0);         // "Número:"
            tlpDatos.Controls.Add(txtNumero, 1, 0);
            tlpDatos.Controls.Add(lbCodigoPostal, 2, 0); // "Fecha:"
            tlpDatos.Controls.Add(fechaFactura, 3, 0);
            tlpDatos.Controls.Add(label7, 4, 0);         // "Concepto:"
            tlpDatos.Controls.Add(cbConceptFac, 5, 0);

            // Ajustes visuales Fila 0
            txtNumero.Dock = DockStyle.Fill;
            fechaFactura.Dock = DockStyle.Fill;
            cbConceptFac.Dock = DockStyle.Fill;

            // --- FILA 1: DESCRIPCIÓN ---
            tlpDatos.Controls.Add(label6, 0, 1);         // "Descripción:"
            tlpDatos.Controls.Add(txtDescripcion, 1, 1);
            tlpDatos.SetColumnSpan(txtDescripcion, 5);   // Ocupa todo el ancho
            txtDescripcion.Dock = DockStyle.Fill;

            // --- FILA 2: SUB-TABLA PARA CHECKS Y RETENCIÓN ---
            // Creamos una tabla interna solo para esta fila. 
            // Así controlamos el tamaño y alineación sin depender de las columnas de arriba.
            TableLayoutPanel tlpFilaInferior = new TableLayoutPanel();
            tlpFilaInferior.AutoSize = true;
            tlpFilaInferior.Dock = DockStyle.Fill;
            tlpFilaInferior.Margin = new Padding(0);
            tlpFilaInferior.RowCount = 1;
            tlpFilaInferior.ColumnCount = 5;

            // Columnas de la fila inferior:
            // [Check1] [Check2] [Hueco] [Lbl Retención] [Num Retención Pequeño]
            tlpFilaInferior.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // Pagada
            tlpFilaInferior.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // Aplica Ret
            tlpFilaInferior.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30f)); // Espacio separador
            tlpFilaInferior.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // Label Tipo
            tlpFilaInferior.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70f)); // Caja pequeña (FIX)

            // Añadimos controles a la sub-tabla
            tlpFilaInferior.Controls.Add(chkPagada, 0, 0);
            tlpFilaInferior.Controls.Add(chkRetencion, 1, 0);
            // (Columna 2 es hueco vacío)
            tlpFilaInferior.Controls.Add(label8, 3, 0);
            tlpFilaInferior.Controls.Add(tipoRetencion, 4, 0);

            // Ajustes finos de alineación en la fila inferior
            chkPagada.Anchor = AnchorStyles.Left;
            chkPagada.Margin = new Padding(0, 3, 15, 3); // Separación derecha

            chkRetencion.Anchor = AnchorStyles.Left;
            chkRetencion.Margin = new Padding(0, 3, 0, 3);

            label8.Anchor = AnchorStyles.Right;          // Pegado a la caja numérica
            label8.TextAlign = ContentAlignment.MiddleRight;

            tipoRetencion.Anchor = AnchorStyles.Left;    // Alineado a la izquierda de su celda
            tipoRetencion.Width = 65;                    // Ancho fijo pequeño y elegante
            tipoRetencion.Margin = new Padding(3, 3, 0, 3);

            // Añadimos la sub-tabla a la tabla principal (en columna 1, ocupando el resto)
            tlpDatos.Controls.Add(tlpFilaInferior, 1, 2);
            tlpDatos.SetColumnSpan(tlpFilaInferior, 5);


            // ALINEACIÓN GENERAL DE ETIQUETAS PRINCIPALES
            foreach (Control c in tlpDatos.Controls)
            {
                // Solo tocamos los Labels directos de tlpDatos (no los de dentro de la subtabla)
                if (c is Label)
                {
                    c.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    ((Label)c).TextAlign = ContentAlignment.MiddleRight;
                }
                // Margen vertical general para que no esté todo pegado
                if (!(c is TableLayoutPanel)) c.Margin = new Padding(3, 6, 3, 6);
            }

            gbFacemi.Controls.Add(tlpDatos);


            // =========================================================================
            // 3. TOTALES (gbTotales)
            // =========================================================================
            TableLayoutPanel tlpTotales = new TableLayoutPanel();
            tlpTotales.Dock = DockStyle.Fill;
            tlpTotales.Padding = new Padding(20, 5, 20, 5); // Margen lateral fuerte
            tlpTotales.RowCount = 1;
            tlpTotales.ColumnCount = 8;

            // Distribución equitativa y espaciosa
            for (int i = 0; i < 4; i++)
            {
                tlpTotales.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));        // Label
                tlpTotales.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));    // Valor
            }

            gbTotales.Controls.Clear();
            // Añadimos en orden: Label, Valor, Label, Valor...
            tlpTotales.Controls.Add(label9, 0, 0);     // Base:
            tlpTotales.Controls.Add(lbBase, 1, 0);
            tlpTotales.Controls.Add(label10, 2, 0);    // Cuota:
            tlpTotales.Controls.Add(lbCuota, 3, 0);
            tlpTotales.Controls.Add(label12, 4, 0);    // Total:
            tlpTotales.Controls.Add(lbTotal, 5, 0);
            tlpTotales.Controls.Add(label11, 6, 0);    // Retención:
            tlpTotales.Controls.Add(lbRetencion, 7, 0);

            foreach (Control c in tlpTotales.Controls)
            {
                c.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                if (c is Label)
                {
                    // Las etiquetas (Base:, Cuota:) alineadas a la DERECHA pegadas al valor
                    if (c.Name.StartsWith("label")) ((Label)c).TextAlign = ContentAlignment.MiddleRight;
                    // Los valores (100€) alineados a la IZQUIERDA
                    else ((Label)c).TextAlign = ContentAlignment.MiddleLeft;
                }
            }

            gbTotales.Controls.Add(tlpTotales);
        }

        #endregion
    }
}
