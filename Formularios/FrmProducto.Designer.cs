namespace FacturacionDAM.Formularios
{
    partial class FrmProducto
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProducto));
            pnButtons = new Panel();
            btnCancelar = new Button();
            btnAceptar = new Button();
            pnContenido = new Panel();
            gbDatos = new GroupBox();
            txtPrecio = new TextBox();
            lblEuro = new Label();
            lbCodigo = new Label();
            txtCodigo = new TextBox();
            lbDescripcion = new Label();
            txtDescripcion = new TextBox();
            lbPrecio = new Label();
            lbIVA = new Label();
            cbIVA = new ComboBox();
            lbActivo = new Label();
            cBActivo = new CheckBox();
            pnButtons.SuspendLayout();
            pnContenido.SuspendLayout();
            gbDatos.SuspendLayout();
            SuspendLayout();
            // 
            // pnButtons
            // 
            pnButtons.Controls.Add(btnCancelar);
            pnButtons.Controls.Add(btnAceptar);
            pnButtons.Dock = DockStyle.Bottom;
            pnButtons.Location = new Point(0, 284);
            pnButtons.Name = "pnButtons";
            pnButtons.Size = new Size(497, 60);
            pnButtons.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(282, 14);
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
            btnAceptar.Location = new Point(97, 14);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Padding = new Padding(20, 0, 0, 0);
            btnAceptar.Size = new Size(128, 32);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // pnContenido
            // 
            pnContenido.Controls.Add(gbDatos);
            pnContenido.Dock = DockStyle.Fill;
            pnContenido.Location = new Point(0, 0);
            pnContenido.Name = "pnContenido";
            pnContenido.Size = new Size(497, 284);
            pnContenido.TabIndex = 0;
            // 
            // gbDatos
            // 
            gbDatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbDatos.Controls.Add(txtPrecio);
            gbDatos.Controls.Add(lblEuro);
            gbDatos.Controls.Add(lbCodigo);
            gbDatos.Controls.Add(txtCodigo);
            gbDatos.Controls.Add(lbDescripcion);
            gbDatos.Controls.Add(txtDescripcion);
            gbDatos.Controls.Add(lbPrecio);
            gbDatos.Controls.Add(lbIVA);
            gbDatos.Controls.Add(cbIVA);
            gbDatos.Controls.Add(lbActivo);
            gbDatos.Controls.Add(cBActivo);
            gbDatos.Location = new Point(12, 12);
            gbDatos.Name = "gbDatos";
            gbDatos.Size = new Size(468, 256);
            gbDatos.TabIndex = 0;
            gbDatos.TabStop = false;
            gbDatos.Text = "Datos del producto";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(120, 107);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 5;
            txtPrecio.TextAlign = HorizontalAlignment.Right;
            // 
            // lblEuro
            // 
            lblEuro.Font = new Font("Segoe UI", 11F);
            lblEuro.Location = new Point(220, 108);
            lblEuro.Name = "lblEuro";
            lblEuro.Size = new Size(22, 20);
            lblEuro.TabIndex = 6;
            lblEuro.Text = "€";
            // 
            // lbCodigo
            // 
            lbCodigo.Location = new Point(58, 30);
            lbCodigo.Name = "lbCodigo";
            lbCodigo.Size = new Size(53, 23);
            lbCodigo.TabIndex = 0;
            lbCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(120, 25);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(329, 23);
            txtCodigo.TabIndex = 1;
            // 
            // lbDescripcion
            // 
            lbDescripcion.Location = new Point(37, 70);
            lbDescripcion.Name = "lbDescripcion";
            lbDescripcion.Size = new Size(80, 23);
            lbDescripcion.TabIndex = 2;
            lbDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(120, 65);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(329, 23);
            txtDescripcion.TabIndex = 3;
            // 
            // lbPrecio
            // 
            lbPrecio.Location = new Point(28, 110);
            lbPrecio.Name = "lbPrecio";
            lbPrecio.Size = new Size(94, 23);
            lbPrecio.TabIndex = 4;
            lbPrecio.Text = "Precio unidad:";
            // 
            // lbIVA
            // 
            lbIVA.Location = new Point(57, 150);
            lbIVA.Name = "lbIVA";
            lbIVA.Size = new Size(63, 23);
            lbIVA.TabIndex = 7;
            lbIVA.Text = "Tipo IVA:";
            // 
            // cbIVA
            // 
            cbIVA.Location = new Point(120, 147);
            cbIVA.Name = "cbIVA";
            cbIVA.Size = new Size(180, 23);
            cbIVA.TabIndex = 8;
            // 
            // lbActivo
            // 
            lbActivo.Location = new Point(65, 190);
            lbActivo.Name = "lbActivo";
            lbActivo.Size = new Size(50, 23);
            lbActivo.TabIndex = 9;
            lbActivo.Text = "Activo:";
            // 
            // cBActivo
            // 
            cBActivo.Location = new Point(120, 186);
            cBActivo.Name = "cBActivo";
            cBActivo.Size = new Size(104, 24);
            cBActivo.TabIndex = 10;
            // 
            // FrmProducto
            // 
            ClientSize = new Size(497, 344);
            Controls.Add(pnContenido);
            Controls.Add(pnButtons);
            MaximumSize = new Size(513, 383);
            MinimumSize = new Size(513, 383);
            Name = "FrmProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Producto";
            FormClosing += FrmProducto_FormClosing;
            Load += FrmProducto_Load;
            pnButtons.ResumeLayout(false);
            pnContenido.ResumeLayout(false);
            gbDatos.ResumeLayout(false);
            gbDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnButtons;
        private Panel pnContenido;
        private GroupBox gbDatos;
        private Label lbCodigo;
        private TextBox txtCodigo;
        private Label lbDescripcion;
        private TextBox txtDescripcion;
        private Label lbPrecio;
        private Label lbIVA;
        private ComboBox cbIVA;
        private Label lbActivo;
        private CheckBox cBActivo;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label lblEuro;
        private TextBox txtPrecio;
    }
}
