namespace FacturacionDAM.Formularios
{
    partial class FrmSeleccionarEmisor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeleccionarEmisor));
            lbTitulo = new Label();
            lbInfo = new Label();
            btnSelection = new Button();
            btnCancelar = new Button();
            cbEmisor = new ComboBox();
            gbSelection = new GroupBox();
            gbSelection.SuspendLayout();
            SuspendLayout();
            // 
            // lbTitulo
            // 
            lbTitulo.AutoSize = true;
            lbTitulo.Font = new Font("Segoe UI", 11F);
            lbTitulo.Location = new Point(42, 41);
            lbTitulo.Name = "lbTitulo";
            lbTitulo.Size = new Size(393, 20);
            lbTitulo.TabIndex = 0;
            lbTitulo.Text = "Selecciona el emisor del cual desea gestionar sus facturas:";
            // 
            // lbInfo
            // 
            lbInfo.Location = new Point(57, 200);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new Size(243, 50);
            lbInfo.TabIndex = 2;
            lbInfo.Text = "Puede cancelar ahora y acceder a la selección del emisor después en el menú \"Archivo\"";
            // 
            // btnSelection
            // 
            btnSelection.Image = (Image)resources.GetObject("btnSelection.Image");
            btnSelection.ImageAlign = ContentAlignment.MiddleLeft;
            btnSelection.Location = new Point(293, 40);
            btnSelection.Name = "btnSelection";
            btnSelection.Padding = new Padding(10, 0, 10, 0);
            btnSelection.Size = new Size(143, 36);
            btnSelection.TabIndex = 1;
            btnSelection.TabStop = false;
            btnSelection.Text = "Seleccionar";
            btnSelection.TextAlign = ContentAlignment.MiddleRight;
            btnSelection.UseVisualStyleBackColor = true;
            btnSelection.Click += btnSelection_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(337, 204);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Padding = new Padding(15, 0, 10, 0);
            btnCancelar.Size = new Size(143, 36);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleRight;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cbEmisor
            // 
            cbEmisor.FormattingEnabled = true;
            cbEmisor.Location = new Point(43, 48);
            cbEmisor.Name = "cbEmisor";
            cbEmisor.Size = new Size(223, 23);
            cbEmisor.TabIndex = 0;
            // 
            // gbSelection
            // 
            gbSelection.Controls.Add(cbEmisor);
            gbSelection.Controls.Add(btnSelection);
            gbSelection.Location = new Point(44, 79);
            gbSelection.Name = "gbSelection";
            gbSelection.Size = new Size(473, 107);
            gbSelection.TabIndex = 1;
            gbSelection.TabStop = false;
            gbSelection.Text = "Seleccione un emisor:";
            // 
            // FrmSeleccionarEmisor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 286);
            Controls.Add(gbSelection);
            Controls.Add(btnCancelar);
            Controls.Add(lbInfo);
            Controls.Add(lbTitulo);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSeleccionarEmisor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Selección de Emisores";
            Load += FrmSeleccionarEmisor_Load;
            gbSelection.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitulo;
        private Label lbInfo;
        private Button btnSelection;
        private Button btnCancelar;
        private ComboBox cbEmisor;
        private GroupBox gbSelection;
    }
}