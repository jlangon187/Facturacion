namespace FacturacionDAM.Formularios
{
    partial class FrmTiposDeIVA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTiposDeIVA));
            pnButtons = new Panel();
            btnCancelar = new Button();
            btnAceptar = new Button();
            pnTipoIVA = new Panel();
            gbIdentidad = new GroupBox();
            lbPorcentaje2 = new Label();
            cBActivo = new CheckBox();
            nUDPorcentaje = new NumericUpDown();
            lbActivo = new Label();
            lbPorcentaje = new Label();
            lbDescripcion = new Label();
            txtDescripcion = new TextBox();
            pnButtons.SuspendLayout();
            pnTipoIVA.SuspendLayout();
            gbIdentidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nUDPorcentaje).BeginInit();
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
            // pnTipoIVA
            // 
            pnTipoIVA.Controls.Add(gbIdentidad);
            pnTipoIVA.Dock = DockStyle.Fill;
            pnTipoIVA.Location = new Point(0, 0);
            pnTipoIVA.Name = "pnTipoIVA";
            pnTipoIVA.Size = new Size(393, 227);
            pnTipoIVA.TabIndex = 0;
            // 
            // gbIdentidad
            // 
            gbIdentidad.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbIdentidad.Controls.Add(lbPorcentaje2);
            gbIdentidad.Controls.Add(cBActivo);
            gbIdentidad.Controls.Add(nUDPorcentaje);
            gbIdentidad.Controls.Add(lbActivo);
            gbIdentidad.Controls.Add(lbPorcentaje);
            gbIdentidad.Controls.Add(lbDescripcion);
            gbIdentidad.Controls.Add(txtDescripcion);
            gbIdentidad.Location = new Point(16, 16);
            gbIdentidad.Name = "gbIdentidad";
            gbIdentidad.Size = new Size(357, 192);
            gbIdentidad.TabIndex = 0;
            gbIdentidad.TabStop = false;
            gbIdentidad.Text = "Datos";
            // 
            // lbPorcentaje2
            // 
            lbPorcentaje2.AutoSize = true;
            lbPorcentaje2.Font = new Font("Segoe UI", 11F);
            lbPorcentaje2.Location = new Point(192, 96);
            lbPorcentaje2.Name = "lbPorcentaje2";
            lbPorcentaje2.Size = new Size(21, 20);
            lbPorcentaje2.TabIndex = 4;
            lbPorcentaje2.Text = "%";
            // 
            // cBActivo
            // 
            cBActivo.AutoSize = true;
            cBActivo.Location = new Point(128, 152);
            cBActivo.Name = "cBActivo";
            cBActivo.Size = new Size(15, 14);
            cBActivo.TabIndex = 6;
            cBActivo.UseVisualStyleBackColor = true;
            // 
            // nUDPorcentaje
            // 
            nUDPorcentaje.DecimalPlaces = 2;
            nUDPorcentaje.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nUDPorcentaje.Location = new Point(128, 96);
            nUDPorcentaje.Maximum = new decimal(new int[] { 9999, 0, 0, 131072 });
            nUDPorcentaje.Name = "nUDPorcentaje";
            nUDPorcentaje.Size = new Size(56, 23);
            nUDPorcentaje.TabIndex = 3;
            nUDPorcentaje.TextAlign = HorizontalAlignment.Right;
            // 
            // lbActivo
            // 
            lbActivo.AutoSize = true;
            lbActivo.Location = new Point(72, 152);
            lbActivo.Name = "lbActivo";
            lbActivo.Size = new Size(44, 15);
            lbActivo.TabIndex = 5;
            lbActivo.Text = "Activo:";
            // 
            // lbPorcentaje
            // 
            lbPorcentaje.AutoSize = true;
            lbPorcentaje.Location = new Point(48, 104);
            lbPorcentaje.Name = "lbPorcentaje";
            lbPorcentaje.Size = new Size(66, 15);
            lbPorcentaje.TabIndex = 2;
            lbPorcentaje.Text = "Porcentaje:";
            // 
            // lbDescripcion
            // 
            lbDescripcion.AutoSize = true;
            lbDescripcion.Location = new Point(40, 48);
            lbDescripcion.Name = "lbDescripcion";
            lbDescripcion.Size = new Size(72, 15);
            lbDescripcion.TabIndex = 0;
            lbDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(128, 40);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(203, 23);
            txtDescripcion.TabIndex = 1;
            // 
            // FrmTiposDeIVA
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(393, 293);
            Controls.Add(pnTipoIVA);
            Controls.Add(pnButtons);
            MaximizeBox = false;
            MaximumSize = new Size(409, 332);
            MinimizeBox = false;
            MinimumSize = new Size(409, 332);
            Name = "FrmTiposDeIVA";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tipos de IVA";
            FormClosing += FrmTiposDeIVA_FormClosing;
            Load += FrmTiposDeIVA_Load;
            pnButtons.ResumeLayout(false);
            pnTipoIVA.ResumeLayout(false);
            gbIdentidad.ResumeLayout(false);
            gbIdentidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nUDPorcentaje).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnButtons;
        private Button btnCancelar;
        private Button btnAceptar;
        private Panel pnTipoIVA;
        private GroupBox gbIdentidad;
        private Label lbApellidos;
        private Label lbPorcentaje;
        private Label lbDescripcion;
        private TextBox txtDescripcion;
        private CheckBox cBActivo;
        private NumericUpDown nUDPorcentaje;
        private Label lbActivo;
        private Label lbPorcentaje2;
    }
}