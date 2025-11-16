namespace FacturacionDAM.Formularios
{
    partial class FrmConceptosFac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConceptosFac));
            pnButtons = new Panel();
            btnCancelar = new Button();
            btnAceptar = new Button();
            pnConceptoFac = new Panel();
            gbDatos = new GroupBox();
            lbDescripcion = new Label();
            lbCodigo = new Label();
            txtDescripcion = new TextBox();
            txtCodigo = new TextBox();
            pnButtons.SuspendLayout();
            pnConceptoFac.SuspendLayout();
            gbDatos.SuspendLayout();
            SuspendLayout();
            // 
            // pnButtons
            // 
            pnButtons.Controls.Add(btnCancelar);
            pnButtons.Controls.Add(btnAceptar);
            pnButtons.Dock = DockStyle.Bottom;
            pnButtons.Location = new Point(0, 227);
            pnButtons.Name = "pnButtons";
            pnButtons.Size = new Size(393, 66);
            pnButtons.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(219, 18);
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
            btnAceptar.Location = new Point(52, 18);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Padding = new Padding(20, 0, 0, 0);
            btnAceptar.Size = new Size(128, 32);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // pnConceptoFac
            // 
            pnConceptoFac.Controls.Add(gbDatos);
            pnConceptoFac.Dock = DockStyle.Fill;
            pnConceptoFac.Location = new Point(0, 0);
            pnConceptoFac.Name = "pnConceptoFac";
            pnConceptoFac.Size = new Size(393, 227);
            pnConceptoFac.TabIndex = 0;
            // 
            // gbDatos
            // 
            gbDatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbDatos.Controls.Add(lbDescripcion);
            gbDatos.Controls.Add(lbCodigo);
            gbDatos.Controls.Add(txtDescripcion);
            gbDatos.Controls.Add(txtCodigo);
            gbDatos.Location = new Point(16, 16);
            gbDatos.Name = "gbDatos";
            gbDatos.Size = new Size(357, 192);
            gbDatos.TabIndex = 0;
            gbDatos.TabStop = false;
            gbDatos.Text = "Datos";
            // 
            // lbDescripcion
            // 
            lbDescripcion.AutoSize = true;
            lbDescripcion.Location = new Point(40, 116);
            lbDescripcion.Name = "lbDescripcion";
            lbDescripcion.Size = new Size(72, 15);
            lbDescripcion.TabIndex = 2;
            lbDescripcion.Text = "Descripción:";
            // 
            // lbCodigo
            // 
            lbCodigo.AutoSize = true;
            lbCodigo.Location = new Point(40, 60);
            lbCodigo.Name = "lbCodigo";
            lbCodigo.Size = new Size(49, 15);
            lbCodigo.TabIndex = 0;
            lbCodigo.Text = "Código:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(128, 108);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(203, 23);
            txtDescripcion.TabIndex = 3;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(128, 52);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(203, 23);
            txtCodigo.TabIndex = 1;
            // 
            // FrmConceptosFac
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(393, 293);
            Controls.Add(pnConceptoFac);
            Controls.Add(pnButtons);
            MaximizeBox = false;
            MaximumSize = new Size(409, 332);
            MinimizeBox = false;
            MinimumSize = new Size(409, 332);
            Name = "FrmConceptosFac";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Concepto de Facturación";
            FormClosing += FrmConceptosFac_FormClosing;
            Load += FrmConceptosFac_Load;
            pnButtons.ResumeLayout(false);
            pnConceptoFac.ResumeLayout(false);
            gbDatos.ResumeLayout(false);
            gbDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnButtons;
        private Button btnCancelar;
        private Button btnAceptar;
        private Panel pnConceptoFac;
        private GroupBox gbDatos;
        private Label lbApellidos;
        private Label lbPorcentaje;
        private Label lbCodigo;
        private TextBox txtCodigo;
        private Label lbDescripcion;
        private TextBox txtDescripcion;
        private CheckBox cBActivo;
        private NumericUpDown nUDPorcentaje;
        private Label lbActivo;
        private Label lbPorcentaje2;
    }
}