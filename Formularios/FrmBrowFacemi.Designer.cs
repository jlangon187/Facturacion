namespace FacturacionDAM.Formularios
{
    partial class FrmBrowFacemi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBrowFacemi));
            splitContainer1 = new SplitContainer();
            dgClientes = new DataGridView();
            pngHeadClientes = new Panel();
            label1 = new Label();
            pnGridClientes = new Panel();
            dgFacemi = new DataGridView();
            pnHeadFacemi = new Panel();
            lbHeadFacemi = new Label();
            pnStatus = new Panel();
            StatusStrip = new StatusStrip();
            tsStatusLabel = new ToolStripStatusLabel();
            tsLbBaseTotal = new ToolStripStatusLabel();
            tsLbTotalIVA = new ToolStripStatusLabel();
            tsLbTotalFacturas = new ToolStripStatusLabel();
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
            toolStripSeparator2 = new ToolStripSeparator();
            tsLbYear = new ToolStripLabel();
            tsCbYear = new ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgClientes).BeginInit();
            pngHeadClientes.SuspendLayout();
            pnGridClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgFacemi).BeginInit();
            pnHeadFacemi.SuspendLayout();
            pnStatus.SuspendLayout();
            StatusStrip.SuspendLayout();
            pnTools.SuspendLayout();
            tsHerramientas.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgClientes);
            splitContainer1.Panel1.Controls.Add(pngHeadClientes);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pnGridClientes);
            splitContainer1.Size = new Size(1325, 668);
            splitContainer1.SplitterDistance = 411;
            splitContainer1.TabIndex = 0;
            // 
            // dgClientes
            // 
            dgClientes.AllowUserToAddRows = false;
            dgClientes.AllowUserToDeleteRows = false;
            dgClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgClientes.Dock = DockStyle.Fill;
            dgClientes.Location = new Point(0, 35);
            dgClientes.Name = "dgClientes";
            dgClientes.ReadOnly = true;
            dgClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgClientes.Size = new Size(411, 633);
            dgClientes.TabIndex = 1;
            dgClientes.SelectionChanged += dgClientes_SelectionChanged;
            // 
            // pngHeadClientes
            // 
            pngHeadClientes.Controls.Add(label1);
            pngHeadClientes.Dock = DockStyle.Top;
            pngHeadClientes.Location = new Point(0, 0);
            pngHeadClientes.Name = "pngHeadClientes";
            pngHeadClientes.Size = new Size(411, 35);
            pngHeadClientes.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.LightGray;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(411, 35);
            label1.TabIndex = 0;
            label1.Text = "CLIENTES";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnGridClientes
            // 
            pnGridClientes.Controls.Add(dgFacemi);
            pnGridClientes.Controls.Add(pnHeadFacemi);
            pnGridClientes.Controls.Add(pnStatus);
            pnGridClientes.Controls.Add(pnTools);
            pnGridClientes.Dock = DockStyle.Fill;
            pnGridClientes.Location = new Point(0, 0);
            pnGridClientes.Name = "pnGridClientes";
            pnGridClientes.Size = new Size(910, 668);
            pnGridClientes.TabIndex = 0;
            // 
            // dgFacemi
            // 
            dgFacemi.AllowUserToAddRows = false;
            dgFacemi.AllowUserToDeleteRows = false;
            dgFacemi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgFacemi.Dock = DockStyle.Fill;
            dgFacemi.Location = new Point(0, 72);
            dgFacemi.Name = "dgFacemi";
            dgFacemi.ReadOnly = true;
            dgFacemi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgFacemi.Size = new Size(910, 574);
            dgFacemi.TabIndex = 4;
            dgFacemi.DoubleClick += btnEdit_Click;
            // 
            // pnHeadFacemi
            // 
            pnHeadFacemi.Controls.Add(lbHeadFacemi);
            pnHeadFacemi.Dock = DockStyle.Top;
            pnHeadFacemi.Location = new Point(0, 25);
            pnHeadFacemi.Name = "pnHeadFacemi";
            pnHeadFacemi.Size = new Size(910, 47);
            pnHeadFacemi.TabIndex = 3;
            // 
            // lbHeadFacemi
            // 
            lbHeadFacemi.BackColor = Color.LightGray;
            lbHeadFacemi.Dock = DockStyle.Fill;
            lbHeadFacemi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbHeadFacemi.Location = new Point(0, 0);
            lbHeadFacemi.Name = "lbHeadFacemi";
            lbHeadFacemi.Size = new Size(910, 47);
            lbHeadFacemi.TabIndex = 0;
            lbHeadFacemi.Text = "Facturas Emitidas del cliente, año 2025";
            lbHeadFacemi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnStatus
            // 
            pnStatus.Controls.Add(StatusStrip);
            pnStatus.Dock = DockStyle.Bottom;
            pnStatus.Location = new Point(0, 646);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(910, 22);
            pnStatus.TabIndex = 2;
            // 
            // StatusStrip
            // 
            StatusStrip.AutoSize = false;
            StatusStrip.Items.AddRange(new ToolStripItem[] { tsStatusLabel, tsLbBaseTotal, tsLbTotalIVA, tsLbTotalFacturas });
            StatusStrip.Location = new Point(0, 0);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(910, 22);
            StatusStrip.TabIndex = 0;
            StatusStrip.Text = "statusStrip1";
            // 
            // tsStatusLabel
            // 
            tsStatusLabel.Margin = new Padding(0, 3, 30, 2);
            tsStatusLabel.Name = "tsStatusLabel";
            tsStatusLabel.Size = new Size(91, 17);
            tsStatusLabel.Text = "Nº de Registros:";
            // 
            // tsLbBaseTotal
            // 
            tsLbBaseTotal.AutoSize = false;
            tsLbBaseTotal.Margin = new Padding(0, 3, 20, 2);
            tsLbBaseTotal.Name = "tsLbBaseTotal";
            tsLbBaseTotal.Size = new Size(622, 17);
            tsLbBaseTotal.Spring = true;
            tsLbBaseTotal.Text = "Total base:";
            tsLbBaseTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tsLbTotalIVA
            // 
            tsLbTotalIVA.Margin = new Padding(0, 3, 20, 2);
            tsLbTotalIVA.Name = "tsLbTotalIVA";
            tsLbTotalIVA.Size = new Size(56, 17);
            tsLbTotalIVA.Text = "Total IVA:";
            // 
            // tsLbTotalFacturas
            // 
            tsLbTotalFacturas.Margin = new Padding(0, 3, 20, 2);
            tsLbTotalFacturas.Name = "tsLbTotalFacturas";
            tsLbTotalFacturas.Size = new Size(36, 17);
            tsLbTotalFacturas.Text = "Total:";
            // 
            // pnTools
            // 
            pnTools.Controls.Add(tsHerramientas);
            pnTools.Dock = DockStyle.Top;
            pnTools.Location = new Point(0, 0);
            pnTools.Name = "pnTools";
            pnTools.Size = new Size(910, 25);
            pnTools.TabIndex = 1;
            // 
            // tsHerramientas
            // 
            tsHerramientas.AutoSize = false;
            tsHerramientas.GripStyle = ToolStripGripStyle.Hidden;
            tsHerramientas.Items.AddRange(new ToolStripItem[] { btnNew, btnEdit, tsSeparador1, btnDelete, tsSeparador2, btnFirst, btnPrev, btnNext, btnLast, toolStripSeparator1, btnExportCSV, btnExportXML, toolStripSeparator2, tsLbYear, tsCbYear });
            tsHerramientas.Location = new Point(0, 0);
            tsHerramientas.Name = "tsHerramientas";
            tsHerramientas.Size = new Size(910, 25);
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
            btnNew.Text = "Nueva Factura";
            btnNew.Click += btnNew_Click;
            // 
            // btnEdit
            // 
            btnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            btnEdit.ImageTransparentColor = Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(23, 22);
            btnEdit.Text = "Editar Factura";
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
            btnDelete.Text = "Borrar Factura";
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
            btnFirst.Text = "Primera Factura";
            btnFirst.Click += btnFirst_Click;
            // 
            // btnPrev
            // 
            btnPrev.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPrev.Image = (Image)resources.GetObject("btnPrev.Image");
            btnPrev.ImageTransparentColor = Color.Magenta;
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(23, 22);
            btnPrev.Text = "Factura anterior";
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.ImageTransparentColor = Color.Magenta;
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(23, 22);
            btnNext.Text = "Siguiente Factura";
            btnNext.Click += btnNext_Click;
            // 
            // btnLast
            // 
            btnLast.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnLast.Image = (Image)resources.GetObject("btnLast.Image");
            btnLast.ImageTransparentColor = Color.Magenta;
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(23, 22);
            btnLast.Text = "Última Factura";
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
            // toolStripSeparator2
            // 
            toolStripSeparator2.Margin = new Padding(10, 0, 20, 0);
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // tsLbYear
            // 
            tsLbYear.Name = "tsLbYear";
            tsLbYear.Size = new Size(32, 22);
            tsLbYear.Text = "Año:";
            // 
            // tsCbYear
            // 
            tsCbYear.BackColor = Color.AntiqueWhite;
            tsCbYear.Name = "tsCbYear";
            tsCbYear.Size = new Size(75, 25);
            tsCbYear.SelectedIndexChanged += tsCbYear_SelectedIndexChanged;
            // 
            // FrmBrowFacemi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1325, 668);
            Controls.Add(splitContainer1);
            Name = "FrmBrowFacemi";
            Text = "Gestión de Facturas Emitidas";
            FormClosing += FrmBrowFacemi_FormClosing;
            Load += FrmBrowFacemi_Load;
            Shown += FrmBrowFacemi_Shown;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgClientes).EndInit();
            pngHeadClientes.ResumeLayout(false);
            pnGridClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgFacemi).EndInit();
            pnHeadFacemi.ResumeLayout(false);
            pnStatus.ResumeLayout(false);
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            pnTools.ResumeLayout(false);
            tsHerramientas.ResumeLayout(false);
            tsHerramientas.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel pngHeadClientes;
        private DataGridView dgClientes;
        private Label label1;
        private Panel pnGridClientes;
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
        private Panel pnHeadFacemi;
        private Panel pnStatus;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel tsStatusLabel;
        private Label lbHeadFacemi;
        private DataGridView dgFacemi;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel tsLbYear;
        private ToolStripComboBox tsCbYear;
        private ToolStripStatusLabel tsLbBaseTotal;
        private ToolStripStatusLabel tsLbTotalIVA;
        private ToolStripStatusLabel tsLbTotalFacturas;
    }
}