using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    partial class FrmBrowEmisores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBrowEmisores));
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
            pnStatus = new Panel();
            StatusStrip = new StatusStrip();
            tsStatusLabel = new ToolStripStatusLabel();
            pnData = new Panel();
            dgTabla = new DataGridView();
            pnTools.SuspendLayout();
            tsHerramientas.SuspendLayout();
            pnStatus.SuspendLayout();
            StatusStrip.SuspendLayout();
            pnData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgTabla).BeginInit();
            SuspendLayout();
            // 
            // pnTools
            // 
            pnTools.Controls.Add(tsHerramientas);
            pnTools.Dock = DockStyle.Top;
            pnTools.Location = new Point(0, 0);
            pnTools.Name = "pnTools";
            pnTools.Size = new Size(1484, 25);
            pnTools.TabIndex = 0;
            // 
            // tsHerramientas
            // 
            tsHerramientas.AutoSize = false;
            tsHerramientas.Items.AddRange(new ToolStripItem[] { btnNew, btnEdit, tsSeparador1, btnDelete, tsSeparador2, btnFirst, btnPrev, btnNext, btnLast, toolStripSeparator1, btnExportCSV, btnExportXML });
            tsHerramientas.Location = new Point(0, 0);
            tsHerramientas.Name = "tsHerramientas";
            tsHerramientas.Size = new Size(1484, 25);
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
            btnNew.Text = "Nuevo Emisor";
            btnNew.Click += btnNew_Click;
            // 
            // btnEdit
            // 
            btnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            btnEdit.ImageTransparentColor = Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(23, 22);
            btnEdit.Text = "Editar Emisor";
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
            btnDelete.Text = "Borrar Emisor";
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
            btnFirst.Text = "Primer Emisor";
            btnFirst.Click += btnFirst_Click;
            // 
            // btnPrev
            // 
            btnPrev.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPrev.Image = (Image)resources.GetObject("btnPrev.Image");
            btnPrev.ImageTransparentColor = Color.Magenta;
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(23, 22);
            btnPrev.Text = "Emisor anterior";
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.ImageTransparentColor = Color.Magenta;
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(23, 22);
            btnNext.Text = "Emisor siguiente";
            btnNext.Click += btnNext_Click;
            // 
            // btnLast
            // 
            btnLast.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnLast.Image = (Image)resources.GetObject("btnLast.Image");
            btnLast.ImageTransparentColor = Color.Magenta;
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(23, 22);
            btnLast.Text = "Último Emisor";
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
            // pnStatus
            // 
            pnStatus.Controls.Add(StatusStrip);
            pnStatus.Dock = DockStyle.Bottom;
            pnStatus.Location = new Point(0, 839);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(1484, 22);
            pnStatus.TabIndex = 1;
            // 
            // StatusStrip
            // 
            StatusStrip.AutoSize = false;
            StatusStrip.Items.AddRange(new ToolStripItem[] { tsStatusLabel });
            StatusStrip.Location = new Point(0, 0);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(1484, 22);
            StatusStrip.TabIndex = 0;
            StatusStrip.Text = "statusStrip1";
            // 
            // tsStatusLabel
            // 
            tsStatusLabel.Name = "tsStatusLabel";
            tsStatusLabel.Size = new Size(91, 17);
            tsStatusLabel.Text = "Nº de Registros:";
            // 
            // pnData
            // 
            pnData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnData.Controls.Add(dgTabla);
            pnData.Location = new Point(0, 25);
            pnData.Name = "pnData";
            pnData.Size = new Size(1484, 814);
            pnData.TabIndex = 2;
            // 
            // dgTabla
            // 
            dgTabla.AllowUserToAddRows = false;
            dgTabla.AllowUserToDeleteRows = false;
            dgTabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgTabla.Dock = DockStyle.Fill;
            dgTabla.Location = new Point(0, 0);
            dgTabla.Name = "dgTabla";
            dgTabla.ReadOnly = true;
            dgTabla.Size = new Size(1484, 814);
            dgTabla.TabIndex = 0;
            dgTabla.CellMouseDoubleClick += dgTabla_CellMouseDoubleClick;
            // 
            // FrmBrowEmisores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1484, 861);
            Controls.Add(pnData);
            Controls.Add(pnStatus);
            Controls.Add(pnTools);
            MinimizeBox = false;
            Name = "FrmBrowEmisores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Emisores";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmBrowEmisores_FormClosing;
            Load += FrmBrowEmisores_Load;
            Shown += FrmBrowEmisores_Shown;
            pnTools.ResumeLayout(false);
            tsHerramientas.ResumeLayout(false);
            tsHerramientas.PerformLayout();
            pnStatus.ResumeLayout(false);
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            pnData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgTabla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTools;
        private Panel pnStatus;
        private StatusStrip StatusStrip;
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
        private Panel pnData;
        private DataGridView dgTabla;
        private ToolStripStatusLabel tsStatusLabel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnExportCSV;
        private ToolStripButton btnExportXML;
    }
}