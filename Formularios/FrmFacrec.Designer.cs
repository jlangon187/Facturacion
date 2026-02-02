
namespace FacturacionDAM.Formularios
{
    partial class FrmFacrec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFacrec));
            pnButtons = new Panel();
            btnCancelar = new Button();
            btnAceptar = new Button();
            tbControl = new TabControl();
            tabData = new TabPage();
            pnFacrecLin = new Panel();
            pnData = new Panel();
            dgLineasFactura = new DataGridView();
            pnStatus = new Panel();
            StatusStrip = new StatusStrip();
            tsStatusLabel = new ToolStripStatusLabel();
            pnTools = new Panel();
            tsHerramientas = new ToolStrip();
            btnNew = new ToolStripButton();
            btnEdit = new ToolStripButton();
            tsSeparador1 = new ToolStripSeparator();
            btnDelete = new ToolStripButton();
            tsSeparador2 = new ToolStripSeparator();
            btnFirst = new ToolStripButton();
            btnPrev = new ToolStripButton();
            btnNext = new ToolStripButton();
            btnLast = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnExportCSV = new ToolStripButton();
            btnExportXML = new ToolStripButton();
            pnFacrec = new Panel();
            gbTotales = new GroupBox();
            lbRetencion = new Label();
            lbTotal = new Label();
            lbCuota = new Label();
            lbBase = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            gbEmisorProveedor = new GroupBox();
            lbNombreProveedor = new Label();
            lbNombreEmisor = new Label();
            label3 = new Label();
            label4 = new Label();
            lbNIFCIFProveedor = new Label();
            lbNIFCIFEmisor = new Label();
            label2 = new Label();
            label1 = new Label();
            gbFacrec = new GroupBox();
            tipoRetencion = new NumericUpDown();
            label8 = new Label();
            chkRetencion = new CheckBox();
            chkPagada = new CheckBox();
            fechaFactura = new DateTimePicker();
            label7 = new Label();
            lbCodigoPostal = new Label();
            label6 = new Label();
            label5 = new Label();
            cbConceptFac = new ComboBox();
            txtDescripcion = new TextBox();
            txtNumero = new TextBox();
            tabNotas = new TabPage();
            txtNotas = new RichTextBox();
            pnButtons.SuspendLayout();
            tbControl.SuspendLayout();
            tabData.SuspendLayout();
            pnFacrecLin.SuspendLayout();
            pnData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgLineasFactura).BeginInit();
            pnStatus.SuspendLayout();
            StatusStrip.SuspendLayout();
            pnTools.SuspendLayout();
            tsHerramientas.SuspendLayout();
            pnFacrec.SuspendLayout();
            gbTotales.SuspendLayout();
            gbEmisorProveedor.SuspendLayout();
            gbFacrec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tipoRetencion).BeginInit();
            tabNotas.SuspendLayout();
            SuspendLayout();
            // 
            // pnButtons
            // 
            pnButtons.Controls.Add(btnCancelar);
            pnButtons.Controls.Add(btnAceptar);
            pnButtons.Dock = DockStyle.Bottom;
            pnButtons.Location = new Point(0, 745);
            pnButtons.Name = "pnButtons";
            pnButtons.Size = new Size(884, 66);
            pnButtons.TabIndex = 2;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(456, 16);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Padding = new Padding(20, 0, 0, 0);
            btnCancelar.Size = new Size(128, 32);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Image = (Image)resources.GetObject("btnAceptar.Image");
            btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAceptar.Location = new Point(264, 16);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Padding = new Padding(20, 0, 0, 0);
            btnAceptar.Size = new Size(128, 32);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // tbControl
            // 
            tbControl.Controls.Add(tabData);
            tbControl.Controls.Add(tabNotas);
            tbControl.Dock = DockStyle.Fill;
            tbControl.Location = new Point(0, 0);
            tbControl.Name = "tbControl";
            tbControl.SelectedIndex = 0;
            tbControl.Size = new Size(884, 745);
            tbControl.TabIndex = 3;
            // 
            // tabData
            // 
            tabData.Controls.Add(pnFacrecLin);
            tabData.Controls.Add(pnFacrec);
            tabData.Location = new Point(4, 24);
            tabData.Name = "tabData";
            tabData.Padding = new Padding(3);
            tabData.Size = new Size(876, 717);
            tabData.TabIndex = 0;
            tabData.Text = "Datos";
            tabData.UseVisualStyleBackColor = true;
            // 
            // pnFacrecLin
            // 
            pnFacrecLin.Controls.Add(pnData);
            pnFacrecLin.Controls.Add(pnStatus);
            pnFacrecLin.Controls.Add(pnTools);
            pnFacrecLin.Dock = DockStyle.Fill;
            pnFacrecLin.Location = new Point(3, 336);
            pnFacrecLin.Name = "pnFacrecLin";
            pnFacrecLin.Size = new Size(870, 378);
            pnFacrecLin.TabIndex = 6;
            // 
            // pnData
            // 
            pnData.Controls.Add(dgLineasFactura);
            pnData.Dock = DockStyle.Fill;
            pnData.Location = new Point(0, 25);
            pnData.Name = "pnData";
            pnData.Size = new Size(870, 331);
            pnData.TabIndex = 3;
            // 
            // dgLineasFactura
            // 
            dgLineasFactura.AllowUserToAddRows = false;
            dgLineasFactura.AllowUserToDeleteRows = false;
            dgLineasFactura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgLineasFactura.Dock = DockStyle.Fill;
            dgLineasFactura.Location = new Point(0, 0);
            dgLineasFactura.Name = "dgLineasFactura";
            dgLineasFactura.ReadOnly = true;
            dgLineasFactura.Size = new Size(870, 331);
            dgLineasFactura.TabIndex = 0;
            dgLineasFactura.DoubleClick += btnEdit_Click;
            // 
            // pnStatus
            // 
            pnStatus.Controls.Add(StatusStrip);
            pnStatus.Dock = DockStyle.Bottom;
            pnStatus.Location = new Point(0, 356);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(870, 22);
            pnStatus.TabIndex = 2;
            // 
            // StatusStrip
            // 
            StatusStrip.AutoSize = false;
            StatusStrip.Items.AddRange(new ToolStripItem[] { tsStatusLabel });
            StatusStrip.Location = new Point(0, 0);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(870, 22);
            StatusStrip.SizingGrip = false;
            StatusStrip.TabIndex = 0;
            StatusStrip.Text = "statusStrip1";
            // 
            // tsStatusLabel
            // 
            tsStatusLabel.Name = "tsStatusLabel";
            tsStatusLabel.Size = new Size(91, 17);
            tsStatusLabel.Text = "Nº de Registros:";
            // 
            // pnTools
            // 
            pnTools.Controls.Add(tsHerramientas);
            pnTools.Dock = DockStyle.Top;
            pnTools.Location = new Point(0, 0);
            pnTools.Name = "pnTools";
            pnTools.Size = new Size(870, 25);
            pnTools.TabIndex = 1;
            // 
            // tsHerramientas
            // 
            tsHerramientas.AutoSize = false;
            tsHerramientas.GripStyle = ToolStripGripStyle.Hidden;
            tsHerramientas.Items.AddRange(new ToolStripItem[] { btnNew, btnEdit, tsSeparador1, btnDelete, tsSeparador2, btnFirst, btnPrev, btnNext, btnLast, toolStripSeparator1, btnExportCSV, btnExportXML });
            tsHerramientas.Location = new Point(0, 0);
            tsHerramientas.Name = "tsHerramientas";
            tsHerramientas.Size = new Size(870, 25);
            tsHerramientas.TabIndex = 0;
            tsHerramientas.Text = "toolStrip1";
            // 
            // btnNew
            // 
            btnNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNew.Image = (Image)resources.GetObject("btnNew.Image");
            btnNew.ImageTransparentColor = Color.Magenta;
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(23, 22);
            btnNew.Text = "Nueva Línea";
            btnNew.Click += btnNew_Click;
            // 
            // btnEdit
            // 
            btnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            btnEdit.ImageTransparentColor = Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(23, 22);
            btnEdit.Text = "Editar Línea";
            btnEdit.Click += btnEdit_Click;
            // 
            // tsSeparador1
            // 
            tsSeparador1.Margin = new Padding(10, 0, 10, 0);
            tsSeparador1.Name = "tsSeparador1";
            tsSeparador1.Size = new Size(6, 25);
            // 
            // btnDelete
            // 
            btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(23, 22);
            btnDelete.Text = "Borrar Línea";
            btnDelete.Click += btnDelete_Click;
            // 
            // tsSeparador2
            // 
            tsSeparador2.Margin = new Padding(10, 0, 10, 0);
            tsSeparador2.Name = "tsSeparador2";
            tsSeparador2.Size = new Size(6, 25);
            // 
            // btnFirst
            // 
            btnFirst.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFirst.Image = (Image)resources.GetObject("btnFirst.Image");
            btnFirst.ImageTransparentColor = Color.Magenta;
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(23, 22);
            btnFirst.Text = "Primera Línea";
            btnFirst.Click += btnFirst_Click;
            // 
            // btnPrev
            // 
            btnPrev.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPrev.Image = (Image)resources.GetObject("btnPrev.Image");
            btnPrev.ImageTransparentColor = Color.Magenta;
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(23, 22);
            btnPrev.Text = "Línea anterior";
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.ImageTransparentColor = Color.Magenta;
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(23, 22);
            btnNext.Text = "Línea siguiente";
            btnNext.Click += btnNext_Click;
            // 
            // btnLast
            // 
            btnLast.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnLast.Image = (Image)resources.GetObject("btnLast.Image");
            btnLast.ImageTransparentColor = Color.Magenta;
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(23, 22);
            btnLast.Text = "Última Línea";
            btnLast.Click += btnLast_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // btnExportCSV
            // 
            btnExportCSV.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExportCSV.Image = (Image)resources.GetObject("btnExportCSV.Image");
            btnExportCSV.ImageTransparentColor = Color.Magenta;
            btnExportCSV.Name = "btnExportCSV";
            btnExportCSV.Size = new Size(23, 22);
            btnExportCSV.Text = "btnExportCSV";
            btnExportCSV.ToolTipText = "Exportar a CSV";
            btnExportCSV.Click += btnExportCSV_Click;
            // 
            // btnExportXML
            // 
            btnExportXML.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExportXML.Image = (Image)resources.GetObject("btnExportXML.Image");
            btnExportXML.ImageTransparentColor = Color.Magenta;
            btnExportXML.Name = "btnExportXML";
            btnExportXML.Size = new Size(23, 22);
            btnExportXML.Text = "btnExportXML";
            btnExportXML.ToolTipText = "Exportar a XML";
            btnExportXML.Click += btnExportXML_Click;
            // 
            // pnFacrec
            // 
            pnFacrec.Controls.Add(gbTotales);
            pnFacrec.Controls.Add(gbEmisorProveedor);
            pnFacrec.Controls.Add(gbFacrec);
            pnFacrec.Dock = DockStyle.Top;
            pnFacrec.Location = new Point(3, 3);
            pnFacrec.Name = "pnFacrec";
            pnFacrec.Size = new Size(870, 333);
            pnFacrec.TabIndex = 5;
            // 
            // gbTotales
            // 
            gbTotales.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbTotales.BackColor = Color.Gainsboro;
            gbTotales.Controls.Add(lbRetencion);
            gbTotales.Controls.Add(lbTotal);
            gbTotales.Controls.Add(lbCuota);
            gbTotales.Controls.Add(lbBase);
            gbTotales.Controls.Add(label12);
            gbTotales.Controls.Add(label11);
            gbTotales.Controls.Add(label10);
            gbTotales.Controls.Add(label9);
            gbTotales.Location = new Point(10, 256);
            gbTotales.Name = "gbTotales";
            gbTotales.Size = new Size(849, 64);
            gbTotales.TabIndex = 7;
            gbTotales.TabStop = false;
            gbTotales.Text = "Totales";
            // 
            // lbRetencion
            // 
            lbRetencion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbRetencion.AutoSize = true;
            lbRetencion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbRetencion.Location = new Point(656, 32);
            lbRetencion.Name = "lbRetencion";
            lbRetencion.Size = new Size(55, 15);
            lbRetencion.TabIndex = 7;
            lbRetencion.Text = "150,00 €";
            // 
            // lbTotal
            // 
            lbTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbTotal.AutoSize = true;
            lbTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTotal.Location = new Point(416, 32);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(62, 15);
            lbTotal.TabIndex = 6;
            lbTotal.Text = "1121,00 €";
            // 
            // lbCuota
            // 
            lbCuota.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbCuota.AutoSize = true;
            lbCuota.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbCuota.Location = new Point(232, 32);
            lbCuota.Name = "lbCuota";
            lbCuota.Size = new Size(55, 15);
            lbCuota.TabIndex = 5;
            lbCuota.Text = "121,00 €";
            // 
            // lbBase
            // 
            lbBase.AutoSize = true;
            lbBase.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbBase.Location = new Point(48, 32);
            lbBase.Name = "lbBase";
            lbBase.Size = new Size(62, 15);
            lbBase.TabIndex = 4;
            lbBase.Text = "1000,00 €";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new Point(376, 32);
            label12.Name = "label12";
            label12.Size = new Size(36, 15);
            label12.TabIndex = 3;
            label12.Text = "Total:";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new Point(592, 32);
            label11.Name = "label11";
            label11.Size = new Size(63, 15);
            label11.TabIndex = 2;
            label11.Text = "Retención:";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(192, 32);
            label10.Name = "label10";
            label10.Size = new Size(42, 15);
            label10.TabIndex = 1;
            label10.Text = "Cuota:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 32);
            label9.Name = "label9";
            label9.Size = new Size(34, 15);
            label9.TabIndex = 0;
            label9.Text = "Base:";
            // 
            // gbEmisorProveedor
            // 
            gbEmisorProveedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbEmisorProveedor.Controls.Add(lbNombreProveedor);
            gbEmisorProveedor.Controls.Add(lbNombreEmisor);
            gbEmisorProveedor.Controls.Add(label3);
            gbEmisorProveedor.Controls.Add(label4);
            gbEmisorProveedor.Controls.Add(lbNIFCIFProveedor);
            gbEmisorProveedor.Controls.Add(lbNIFCIFEmisor);
            gbEmisorProveedor.Controls.Add(label2);
            gbEmisorProveedor.Controls.Add(label1);
            gbEmisorProveedor.Location = new Point(10, 8);
            gbEmisorProveedor.Name = "gbEmisorProveedor";
            gbEmisorProveedor.Size = new Size(849, 96);
            gbEmisorProveedor.TabIndex = 6;
            gbEmisorProveedor.TabStop = false;
            gbEmisorProveedor.Text = "Emisor y Proveedor";
            // 
            // lbNombreProveedor
            // 
            lbNombreProveedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbNombreProveedor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbNombreProveedor.ForeColor = Color.DarkGoldenrod;
            lbNombreProveedor.Location = new Point(368, 64);
            lbNombreProveedor.Name = "lbNombreProveedor";
            lbNombreProveedor.Size = new Size(1049, 15);
            lbNombreProveedor.TabIndex = 8;
            lbNombreProveedor.Text = "Nombre Proveedor";
            lbNombreProveedor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbNombreEmisor
            // 
            lbNombreEmisor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbNombreEmisor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbNombreEmisor.ForeColor = Color.RoyalBlue;
            lbNombreEmisor.Location = new Point(368, 32);
            lbNombreEmisor.Name = "lbNombreEmisor";
            lbNombreEmisor.Size = new Size(1049, 15);
            lbNombreEmisor.TabIndex = 7;
            lbNombreEmisor.Text = "Nombre Emisor";
            lbNombreEmisor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(272, 64);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 6;
            label3.Text = "Nombre Proveedor:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(272, 32);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 5;
            label4.Text = "Nombre Emisor:";
            // 
            // lbNIFCIFProveedor
            // 
            lbNIFCIFProveedor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbNIFCIFProveedor.ForeColor = Color.DarkGoldenrod;
            lbNIFCIFProveedor.Location = new Point(112, 64);
            lbNIFCIFProveedor.Name = "lbNIFCIFProveedor";
            lbNIFCIFProveedor.Size = new Size(145, 15);
            lbNIFCIFProveedor.TabIndex = 4;
            lbNIFCIFProveedor.Text = "NIF/CIF Proveedor";
            lbNIFCIFProveedor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbNIFCIFEmisor
            // 
            lbNIFCIFEmisor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbNIFCIFEmisor.ForeColor = Color.RoyalBlue;
            lbNIFCIFEmisor.Location = new Point(112, 32);
            lbNIFCIFEmisor.Name = "lbNIFCIFEmisor";
            lbNIFCIFEmisor.Size = new Size(145, 15);
            lbNIFCIFEmisor.TabIndex = 3;
            lbNIFCIFEmisor.Text = "NIF/CIF Emisor";
            lbNIFCIFEmisor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 64);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 2;
            label2.Text = "NIF/CIF Proveedor:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 32);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 0;
            label1.Text = "NIF/CIF Emisor:";
            // 
            // gbFacrec
            // 
            gbFacrec.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbFacrec.Controls.Add(tipoRetencion);
            gbFacrec.Controls.Add(label8);
            gbFacrec.Controls.Add(chkRetencion);
            gbFacrec.Controls.Add(chkPagada);
            gbFacrec.Controls.Add(fechaFactura);
            gbFacrec.Controls.Add(label7);
            gbFacrec.Controls.Add(lbCodigoPostal);
            gbFacrec.Controls.Add(label6);
            gbFacrec.Controls.Add(label5);
            gbFacrec.Controls.Add(cbConceptFac);
            gbFacrec.Controls.Add(txtDescripcion);
            gbFacrec.Controls.Add(txtNumero);
            gbFacrec.Location = new Point(10, 112);
            gbFacrec.Name = "gbFacrec";
            gbFacrec.Size = new Size(849, 136);
            gbFacrec.TabIndex = 5;
            gbFacrec.TabStop = false;
            gbFacrec.Text = "Datos de la Factura";
            // 
            // tipoRetencion
            // 
            tipoRetencion.DecimalPlaces = 2;
            tipoRetencion.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            tipoRetencion.Location = new Point(472, 103);
            tipoRetencion.Name = "tipoRetencion";
            tipoRetencion.Size = new Size(64, 23);
            tipoRetencion.TabIndex = 0;
            tipoRetencion.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(360, 106);
            label8.Name = "label8";
            label8.Size = new Size(103, 15);
            label8.TabIndex = 11;
            label8.Text = "Tipo de retención:";
            // 
            // chkRetencion
            // 
            chkRetencion.AutoSize = true;
            chkRetencion.Location = new Point(192, 106);
            chkRetencion.Name = "chkRetencion";
            chkRetencion.Size = new Size(135, 19);
            chkRetencion.TabIndex = 10;
            chkRetencion.Text = "¿Se aplica retención?";
            chkRetencion.UseVisualStyleBackColor = true;
            // 
            // chkPagada
            // 
            chkPagada.AutoSize = true;
            chkPagada.Location = new Point(88, 106);
            chkPagada.Name = "chkPagada";
            chkPagada.Size = new Size(75, 19);
            chkPagada.TabIndex = 9;
            chkPagada.Text = "¿Pagada?";
            chkPagada.UseVisualStyleBackColor = true;
            // 
            // fechaFactura
            // 
            fechaFactura.Format = DateTimePickerFormat.Short;
            fechaFactura.Location = new Point(248, 36);
            fechaFactura.Name = "fechaFactura";
            fechaFactura.Size = new Size(93, 23);
            fechaFactura.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(360, 40);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 6;
            label7.Text = "Concepto:";
            // 
            // lbCodigoPostal
            // 
            lbCodigoPostal.AutoSize = true;
            lbCodigoPostal.Location = new Point(203, 40);
            lbCodigoPostal.Name = "lbCodigoPostal";
            lbCodigoPostal.Size = new Size(41, 15);
            lbCodigoPostal.TabIndex = 4;
            lbCodigoPostal.Text = "Fecha:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 72);
            label6.Name = "label6";
            label6.Size = new Size(72, 15);
            label6.TabIndex = 2;
            label6.Text = "Descripción:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 40);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 0;
            label5.Text = "Número:";
            // 
            // cbConceptFac
            // 
            cbConceptFac.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbConceptFac.FormattingEnabled = true;
            cbConceptFac.Location = new Point(424, 36);
            cbConceptFac.Name = "cbConceptFac";
            cbConceptFac.Size = new Size(417, 23);
            cbConceptFac.TabIndex = 7;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescripcion.Location = new Point(88, 68);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(753, 23);
            txtDescripcion.TabIndex = 3;
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(88, 36);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(88, 23);
            txtNumero.TabIndex = 1;
            // 
            // tabNotas
            // 
            tabNotas.Controls.Add(txtNotas);
            tabNotas.Location = new Point(4, 24);
            tabNotas.Name = "tabNotas";
            tabNotas.Padding = new Padding(3);
            tabNotas.Size = new Size(876, 717);
            tabNotas.TabIndex = 1;
            tabNotas.Text = "Notas";
            tabNotas.UseVisualStyleBackColor = true;
            // 
            // txtNotas
            // 
            txtNotas.Dock = DockStyle.Fill;
            txtNotas.Location = new Point(3, 3);
            txtNotas.Name = "txtNotas";
            txtNotas.Size = new Size(870, 711);
            txtNotas.TabIndex = 0;
            txtNotas.Text = "";
            // 
            // FrmFacrec
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 811);
            Controls.Add(tbControl);
            Controls.Add(pnButtons);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(800, 800);
            Name = "FrmFacrec";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Factura Emitida";
            FormClosing += FrmFacrec_FormClosing;
            Load += FrmFacrec_Load;
            pnButtons.ResumeLayout(false);
            tbControl.ResumeLayout(false);
            tabData.ResumeLayout(false);
            pnFacrecLin.ResumeLayout(false);
            pnData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgLineasFactura).EndInit();
            pnStatus.ResumeLayout(false);
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            pnTools.ResumeLayout(false);
            tsHerramientas.ResumeLayout(false);
            tsHerramientas.PerformLayout();
            pnFacrec.ResumeLayout(false);
            gbTotales.ResumeLayout(false);
            gbTotales.PerformLayout();
            gbEmisorProveedor.ResumeLayout(false);
            gbEmisorProveedor.PerformLayout();
            gbFacrec.ResumeLayout(false);
            gbFacrec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tipoRetencion).EndInit();
            tabNotas.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnButtons;
        private Button btnCancelar;
        private Button btnAceptar;
        private TabControl tbControl;
        private TabPage tabData;
        private TabPage tabNotas;
        private RichTextBox txtNotas;
        private Panel pnFacrecLin;
        private Panel pnFacrec;
        private GroupBox gbTotales;
        private Label lbRetencion;
        private Label lbTotal;
        private Label lbCuota;
        private Label lbBase;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private GroupBox gbEmisorProveedor;
        private Label lbNombreProveedor;
        private Label lbNombreEmisor;
        private Label label3;
        private Label label4;
        private Label lbNIFCIFProveedor;
        private Label lbNIFCIFEmisor;
        private Label label2;
        private Label label1;
        private GroupBox gbFacrec;
        private NumericUpDown tipoRetencion;
        private Label label8;
        private CheckBox chkRetencion;
        private CheckBox chkPagada;
        private DateTimePicker fechaFactura;
        private Label label7;
        private Label lbCodigoPostal;
        private Label label6;
        private Label label5;
        private ComboBox cbConceptFac;
        private TextBox txtDescripcion;
        private TextBox txtNumero;
        private Panel pnTools;
        private ToolStrip tsHerramientas;
        private ToolStripButton btnNew;
        private ToolStripButton btnEdit;
        private ToolStripSeparator tsSeparador1;
        private ToolStripButton btnDelete;
        private ToolStripSeparator tsSeparador2;
        private ToolStripButton btnFirst;
        private ToolStripButton btnPrev;
        private ToolStripButton btnNext;
        private ToolStripButton btnLast;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnExportCSV;
        private ToolStripButton btnExportXML;
        private Panel pnStatus;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel tsStatusLabel;
        private Panel pnData;
        private DataGridView dgLineasFactura;
    }
}