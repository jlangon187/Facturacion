namespace FacturacionDAM.Formularios
{
    partial class FrmEmisor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmisor));
            pnButtons = new Panel();
            btnCancelar = new Button();
            btnAceptar = new Button();
            tbControl = new TabControl();
            tbDatos = new TabPage();
            gbFacturacion = new GroupBox();
            lbPrefijo = new Label();
            lbSeguienteNumero = new Label();
            txtPrefijo = new TextBox();
            txtSiguientenumero = new TextBox();
            gbContacto = new GroupBox();
            lbEmail = new Label();
            lbTelefono2 = new Label();
            lbTelefono1 = new Label();
            txtEmail = new TextBox();
            txtTelefono2 = new TextBox();
            txtTelefono1 = new TextBox();
            gbDomicilio = new GroupBox();
            lbProvincia = new Label();
            lbCodigoPostal = new Label();
            lbPoblacion = new Label();
            lbDomicilio = new Label();
            cbProvincia = new ComboBox();
            txtCodigoPostal = new TextBox();
            txtPoblacion = new TextBox();
            txtDomicilio = new TextBox();
            gbIdentidad = new GroupBox();
            lbApellidos = new Label();
            lbNombre = new Label();
            lbRazonSocial = new Label();
            lbNifCif = new Label();
            txtApellidos = new TextBox();
            txtNombre = new TextBox();
            txtRazonSocial = new TextBox();
            txtNifCif = new TextBox();
            tbDetalles = new TabPage();
            rTBoxDescripcion = new RichTextBox();
            pnButtons.SuspendLayout();
            tbControl.SuspendLayout();
            tbDatos.SuspendLayout();
            gbFacturacion.SuspendLayout();
            gbContacto.SuspendLayout();
            gbDomicilio.SuspendLayout();
            gbIdentidad.SuspendLayout();
            tbDetalles.SuspendLayout();
            SuspendLayout();
            // 
            // pnButtons
            // 
            pnButtons.Controls.Add(btnCancelar);
            pnButtons.Controls.Add(btnAceptar);
            pnButtons.Dock = DockStyle.Bottom;
            pnButtons.Location = new Point(0, 555);
            pnButtons.Name = "pnButtons";
            pnButtons.Size = new Size(844, 66);
            pnButtons.TabIndex = 1;
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
            tbControl.Controls.Add(tbDatos);
            tbControl.Controls.Add(tbDetalles);
            tbControl.Dock = DockStyle.Fill;
            tbControl.Location = new Point(0, 0);
            tbControl.Name = "tbControl";
            tbControl.SelectedIndex = 0;
            tbControl.Size = new Size(844, 555);
            tbControl.TabIndex = 0;
            // 
            // tbDatos
            // 
            tbDatos.Controls.Add(gbFacturacion);
            tbDatos.Controls.Add(gbContacto);
            tbDatos.Controls.Add(gbDomicilio);
            tbDatos.Controls.Add(gbIdentidad);
            tbDatos.Location = new Point(4, 24);
            tbDatos.Name = "tbDatos";
            tbDatos.Padding = new Padding(3);
            tbDatos.Size = new Size(836, 527);
            tbDatos.TabIndex = 0;
            tbDatos.Text = "Datos";
            tbDatos.UseVisualStyleBackColor = true;
            // 
            // gbFacturacion
            // 
            gbFacturacion.Controls.Add(lbPrefijo);
            gbFacturacion.Controls.Add(lbSeguienteNumero);
            gbFacturacion.Controls.Add(txtPrefijo);
            gbFacturacion.Controls.Add(txtSiguientenumero);
            gbFacturacion.Location = new Point(16, 424);
            gbFacturacion.Name = "gbFacturacion";
            gbFacturacion.Size = new Size(808, 80);
            gbFacturacion.TabIndex = 3;
            gbFacturacion.TabStop = false;
            gbFacturacion.Text = "Facturación";
            // 
            // lbPrefijo
            // 
            lbPrefijo.AutoSize = true;
            lbPrefijo.Location = new Point(280, 40);
            lbPrefijo.Name = "lbPrefijo";
            lbPrefijo.Size = new Size(44, 15);
            lbPrefijo.TabIndex = 2;
            lbPrefijo.Text = "Prefijo:";
            // 
            // lbSeguienteNumero
            // 
            lbSeguienteNumero.AutoSize = true;
            lbSeguienteNumero.Location = new Point(24, 40);
            lbSeguienteNumero.Name = "lbSeguienteNumero";
            lbSeguienteNumero.Size = new Size(74, 15);
            lbSeguienteNumero.TabIndex = 0;
            lbSeguienteNumero.Text = "Siguiente nº:";
            // 
            // txtPrefijo
            // 
            txtPrefijo.Location = new Point(328, 32);
            txtPrefijo.Name = "txtPrefijo";
            txtPrefijo.Size = new Size(100, 23);
            txtPrefijo.TabIndex = 3;
            // 
            // txtSiguientenumero
            // 
            txtSiguientenumero.Location = new Point(104, 32);
            txtSiguientenumero.Name = "txtSiguientenumero";
            txtSiguientenumero.Size = new Size(100, 23);
            txtSiguientenumero.TabIndex = 1;
            // 
            // gbContacto
            // 
            gbContacto.Controls.Add(lbEmail);
            gbContacto.Controls.Add(lbTelefono2);
            gbContacto.Controls.Add(lbTelefono1);
            gbContacto.Controls.Add(txtEmail);
            gbContacto.Controls.Add(txtTelefono2);
            gbContacto.Controls.Add(txtTelefono1);
            gbContacto.Location = new Point(16, 288);
            gbContacto.Name = "gbContacto";
            gbContacto.Size = new Size(808, 120);
            gbContacto.TabIndex = 2;
            gbContacto.TabStop = false;
            gbContacto.Text = "Contacto";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(56, 88);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(39, 15);
            lbEmail.TabIndex = 2;
            lbEmail.Text = "Email:";
            // 
            // lbTelefono2
            // 
            lbTelefono2.AutoSize = true;
            lbTelefono2.Location = new Point(360, 40);
            lbTelefono2.Name = "lbTelefono2";
            lbTelefono2.Size = new Size(65, 15);
            lbTelefono2.TabIndex = 4;
            lbTelefono2.Text = "Teléfono 2:";
            // 
            // lbTelefono1
            // 
            lbTelefono1.AutoSize = true;
            lbTelefono1.Location = new Point(32, 40);
            lbTelefono1.Name = "lbTelefono1";
            lbTelefono1.Size = new Size(65, 15);
            lbTelefono1.TabIndex = 0;
            lbTelefono1.Text = "Teléfono 1:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(104, 80);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(512, 23);
            txtEmail.TabIndex = 3;
            // 
            // txtTelefono2
            // 
            txtTelefono2.Location = new Point(432, 32);
            txtTelefono2.Name = "txtTelefono2";
            txtTelefono2.Size = new Size(180, 23);
            txtTelefono2.TabIndex = 5;
            // 
            // txtTelefono1
            // 
            txtTelefono1.Location = new Point(104, 32);
            txtTelefono1.Name = "txtTelefono1";
            txtTelefono1.Size = new Size(180, 23);
            txtTelefono1.TabIndex = 1;
            // 
            // gbDomicilio
            // 
            gbDomicilio.Controls.Add(lbProvincia);
            gbDomicilio.Controls.Add(lbCodigoPostal);
            gbDomicilio.Controls.Add(lbPoblacion);
            gbDomicilio.Controls.Add(lbDomicilio);
            gbDomicilio.Controls.Add(cbProvincia);
            gbDomicilio.Controls.Add(txtCodigoPostal);
            gbDomicilio.Controls.Add(txtPoblacion);
            gbDomicilio.Controls.Add(txtDomicilio);
            gbDomicilio.Location = new Point(16, 152);
            gbDomicilio.Name = "gbDomicilio";
            gbDomicilio.Size = new Size(808, 120);
            gbDomicilio.TabIndex = 1;
            gbDomicilio.TabStop = false;
            gbDomicilio.Text = "Domicilio";
            // 
            // lbProvincia
            // 
            lbProvincia.AutoSize = true;
            lbProvincia.Location = new Point(520, 88);
            lbProvincia.Name = "lbProvincia";
            lbProvincia.Size = new Size(59, 15);
            lbProvincia.TabIndex = 6;
            lbProvincia.Text = "Provincia:";
            // 
            // lbCodigoPostal
            // 
            lbCodigoPostal.AutoSize = true;
            lbCodigoPostal.Location = new Point(608, 40);
            lbCodigoPostal.Name = "lbCodigoPostal";
            lbCodigoPostal.Size = new Size(84, 15);
            lbCodigoPostal.TabIndex = 4;
            lbCodigoPostal.Text = "Código Postal:";
            // 
            // lbPoblacion
            // 
            lbPoblacion.AutoSize = true;
            lbPoblacion.Location = new Point(40, 88);
            lbPoblacion.Name = "lbPoblacion";
            lbPoblacion.Size = new Size(63, 15);
            lbPoblacion.TabIndex = 2;
            lbPoblacion.Text = "Población:";
            // 
            // lbDomicilio
            // 
            lbDomicilio.AutoSize = true;
            lbDomicilio.Location = new Point(40, 40);
            lbDomicilio.Name = "lbDomicilio";
            lbDomicilio.Size = new Size(61, 15);
            lbDomicilio.TabIndex = 0;
            lbDomicilio.Text = "Domicilio:";
            // 
            // cbProvincia
            // 
            cbProvincia.FormattingEnabled = true;
            cbProvincia.Location = new Point(584, 80);
            cbProvincia.Name = "cbProvincia";
            cbProvincia.Size = new Size(208, 23);
            cbProvincia.TabIndex = 7;
            // 
            // txtCodigoPostal
            // 
            txtCodigoPostal.Location = new Point(696, 32);
            txtCodigoPostal.Name = "txtCodigoPostal";
            txtCodigoPostal.Size = new Size(100, 23);
            txtCodigoPostal.TabIndex = 5;
            // 
            // txtPoblacion
            // 
            txtPoblacion.Location = new Point(104, 80);
            txtPoblacion.Name = "txtPoblacion";
            txtPoblacion.Size = new Size(392, 23);
            txtPoblacion.TabIndex = 3;
            // 
            // txtDomicilio
            // 
            txtDomicilio.Location = new Point(104, 32);
            txtDomicilio.Name = "txtDomicilio";
            txtDomicilio.PlaceholderText = "Calle, número, planta....";
            txtDomicilio.Size = new Size(488, 23);
            txtDomicilio.TabIndex = 1;
            // 
            // gbIdentidad
            // 
            gbIdentidad.Controls.Add(lbApellidos);
            gbIdentidad.Controls.Add(lbNombre);
            gbIdentidad.Controls.Add(lbRazonSocial);
            gbIdentidad.Controls.Add(lbNifCif);
            gbIdentidad.Controls.Add(txtApellidos);
            gbIdentidad.Controls.Add(txtNombre);
            gbIdentidad.Controls.Add(txtRazonSocial);
            gbIdentidad.Controls.Add(txtNifCif);
            gbIdentidad.Location = new Point(16, 16);
            gbIdentidad.Name = "gbIdentidad";
            gbIdentidad.Size = new Size(808, 120);
            gbIdentidad.TabIndex = 0;
            gbIdentidad.TabStop = false;
            gbIdentidad.Text = "Identidad";
            // 
            // lbApellidos
            // 
            lbApellidos.AutoSize = true;
            lbApellidos.Location = new Point(392, 88);
            lbApellidos.Name = "lbApellidos";
            lbApellidos.Size = new Size(59, 15);
            lbApellidos.TabIndex = 6;
            lbApellidos.Text = "Apellidos:";
            // 
            // lbNombre
            // 
            lbNombre.AutoSize = true;
            lbNombre.Location = new Point(392, 40);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(54, 15);
            lbNombre.TabIndex = 4;
            lbNombre.Text = "Nombre:";
            // 
            // lbRazonSocial
            // 
            lbRazonSocial.AutoSize = true;
            lbRazonSocial.Location = new Point(24, 88);
            lbRazonSocial.Name = "lbRazonSocial";
            lbRazonSocial.Size = new Size(76, 15);
            lbRazonSocial.TabIndex = 2;
            lbRazonSocial.Text = "Razón Social:";
            // 
            // lbNifCif
            // 
            lbNifCif.AutoSize = true;
            lbNifCif.Location = new Point(48, 40);
            lbNifCif.Name = "lbNifCif";
            lbNifCif.Size = new Size(50, 15);
            lbNifCif.TabIndex = 0;
            lbNifCif.Text = "NIF/CIF:";
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(456, 80);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(328, 23);
            txtApellidos.TabIndex = 7;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(456, 32);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(224, 23);
            txtNombre.TabIndex = 5;
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Location = new Point(104, 80);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(264, 23);
            txtRazonSocial.TabIndex = 3;
            // 
            // txtNifCif
            // 
            txtNifCif.Location = new Point(104, 32);
            txtNifCif.Name = "txtNifCif";
            txtNifCif.Size = new Size(152, 23);
            txtNifCif.TabIndex = 1;
            // 
            // tbDetalles
            // 
            tbDetalles.Controls.Add(rTBoxDescripcion);
            tbDetalles.Location = new Point(4, 24);
            tbDetalles.Name = "tbDetalles";
            tbDetalles.Padding = new Padding(3);
            tbDetalles.Size = new Size(836, 527);
            tbDetalles.TabIndex = 1;
            tbDetalles.Text = "Otros detalles";
            tbDetalles.UseVisualStyleBackColor = true;
            // 
            // rTBoxDescripcion
            // 
            rTBoxDescripcion.Dock = DockStyle.Fill;
            rTBoxDescripcion.Location = new Point(3, 3);
            rTBoxDescripcion.Name = "rTBoxDescripcion";
            rTBoxDescripcion.Size = new Size(830, 521);
            rTBoxDescripcion.TabIndex = 0;
            rTBoxDescripcion.Text = "";
            // 
            // FrmEmisor
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(844, 621);
            Controls.Add(tbControl);
            Controls.Add(pnButtons);
            MaximizeBox = false;
            MaximumSize = new Size(860, 660);
            MinimizeBox = false;
            MinimumSize = new Size(860, 660);
            Name = "FrmEmisor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Datos del Emisor";
            FormClosing += FrmEmisor_FormClosing;
            Load += FrmEmisor_Load;
            pnButtons.ResumeLayout(false);
            tbControl.ResumeLayout(false);
            tbDatos.ResumeLayout(false);
            gbFacturacion.ResumeLayout(false);
            gbFacturacion.PerformLayout();
            gbContacto.ResumeLayout(false);
            gbContacto.PerformLayout();
            gbDomicilio.ResumeLayout(false);
            gbDomicilio.PerformLayout();
            gbIdentidad.ResumeLayout(false);
            gbIdentidad.PerformLayout();
            tbDetalles.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnButtons;
        private Button btnCancelar;
        private Button btnAceptar;
        private TabControl tbControl;
        private TabPage tbDatos;
        private GroupBox gbDomicilio;
        private GroupBox gbIdentidad;
        private TabPage tbDetalles;
        private GroupBox gbFacturacion;
        private GroupBox gbContacto;
        private RichTextBox rTBoxDescripcion;
        private Label lbEmail;
        private Label lbTelefono2;
        private Label lbTelefono1;
        private TextBox txtEmail;
        private TextBox txtTelefono2;
        private TextBox txtTelefono1;
        private Label lbProvincia;
        private Label lbCodigoPostal;
        private Label lbPoblacion;
        private Label lbDomicilio;
        private ComboBox cbProvincia;
        private TextBox txtCodigoPostal;
        private TextBox txtPoblacion;
        private TextBox txtDomicilio;
        private Label lbApellidos;
        private Label lbNombre;
        private Label lbRazonSocial;
        private Label lbNifCif;
        private TextBox txtApellidos;
        private TextBox txtNombre;
        private TextBox txtRazonSocial;
        private TextBox txtNifCif;
        private Label lbSeguienteNumero;
        private TextBox txtPrefijo;
        private TextBox txtSiguientenumero;
        private Label lbPrefijo;
    }
}