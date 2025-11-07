namespace FacturacionDAM.Formularios
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            pnMenu = new Panel();
            menuMain = new MenuStrip();
            tsMenuArchivo = new ToolStripMenuItem();
            seleccionarEmisorToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            ventanasToolStripMenuItem = new ToolStripMenuItem();
            cascadaToolStripMenuItem = new ToolStripMenuItem();
            mosaicohorizontalToolStripMenuItem = new ToolStripMenuItem();
            mosaicoverticalToolStripMenuItem = new ToolStripMenuItem();
            cerrarTodasLasVentanasToolStripMenuItem = new ToolStripMenuItem();
            tsMenuAyuda = new ToolStripMenuItem();
            tsMenuConsola = new ToolStripMenuItem();
            pnTools = new Panel();
            tsToolMain = new ToolStrip();
            tsBtnVentas = new ToolStripButton();
            tsBtnCompras = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsBtnClientes = new ToolStripButton();
            tsBtnProveedores = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsBtnEmisores = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            tsBtnConfig = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            tsBtnSalir = new ToolStripButton();
            pnStatus = new Panel();
            statusBar = new StatusStrip();
            tsLbEmisorTitle = new ToolStripStatusLabel();
            tsLbEmisor = new ToolStripStatusLabel();
            tbLbEstadoTitle = new ToolStripStatusLabel();
            tsLbEstado = new ToolStripStatusLabel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pnMenu.SuspendLayout();
            menuMain.SuspendLayout();
            pnTools.SuspendLayout();
            tsToolMain.SuspendLayout();
            pnStatus.SuspendLayout();
            statusBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnMenu
            // 
            pnMenu.Controls.Add(menuMain);
            pnMenu.Dock = DockStyle.Top;
            pnMenu.Location = new Point(0, 0);
            pnMenu.Name = "pnMenu";
            pnMenu.Size = new Size(936, 31);
            pnMenu.TabIndex = 3;
            // 
            // menuMain
            // 
            menuMain.BackColor = SystemColors.Control;
            menuMain.Items.AddRange(new ToolStripItem[] { tsMenuArchivo, ventanasToolStripMenuItem, tsMenuAyuda });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(936, 24);
            menuMain.TabIndex = 0;
            menuMain.Text = "menuStrip1";
            // 
            // tsMenuArchivo
            // 
            tsMenuArchivo.DropDownItems.AddRange(new ToolStripItem[] { seleccionarEmisorToolStripMenuItem, salirToolStripMenuItem });
            tsMenuArchivo.Name = "tsMenuArchivo";
            tsMenuArchivo.Size = new Size(60, 20);
            tsMenuArchivo.Text = "&Archivo";
            // 
            // seleccionarEmisorToolStripMenuItem
            // 
            seleccionarEmisorToolStripMenuItem.Image = (Image)resources.GetObject("seleccionarEmisorToolStripMenuItem.Image");
            seleccionarEmisorToolStripMenuItem.Name = "seleccionarEmisorToolStripMenuItem";
            seleccionarEmisorToolStripMenuItem.Size = new Size(182, 22);
            seleccionarEmisorToolStripMenuItem.Text = "&Seleccionar emisor...";
            seleccionarEmisorToolStripMenuItem.Click += seleccionarEmisorToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Image = (Image)resources.GetObject("salirToolStripMenuItem.Image");
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(182, 22);
            salirToolStripMenuItem.Text = "&Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // ventanasToolStripMenuItem
            // 
            ventanasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cascadaToolStripMenuItem, mosaicohorizontalToolStripMenuItem, mosaicoverticalToolStripMenuItem, cerrarTodasLasVentanasToolStripMenuItem });
            ventanasToolStripMenuItem.Name = "ventanasToolStripMenuItem";
            ventanasToolStripMenuItem.Size = new Size(66, 20);
            ventanasToolStripMenuItem.Text = "&Ventanas";
            // 
            // cascadaToolStripMenuItem
            // 
            cascadaToolStripMenuItem.Name = "cascadaToolStripMenuItem";
            cascadaToolStripMenuItem.Size = new Size(205, 22);
            cascadaToolStripMenuItem.Text = "&Cascada";
            cascadaToolStripMenuItem.Click += cascadaToolStripMenuItem_Click;
            // 
            // mosaicohorizontalToolStripMenuItem
            // 
            mosaicohorizontalToolStripMenuItem.Name = "mosaicohorizontalToolStripMenuItem";
            mosaicohorizontalToolStripMenuItem.Size = new Size(205, 22);
            mosaicohorizontalToolStripMenuItem.Text = "Mosaico &horizontal";
            mosaicohorizontalToolStripMenuItem.Click += mosaicohorizontalToolStripMenuItem_Click;
            // 
            // mosaicoverticalToolStripMenuItem
            // 
            mosaicoverticalToolStripMenuItem.Name = "mosaicoverticalToolStripMenuItem";
            mosaicoverticalToolStripMenuItem.Size = new Size(205, 22);
            mosaicoverticalToolStripMenuItem.Text = "Mosaico &vertical";
            mosaicoverticalToolStripMenuItem.Click += mosaicoverticalToolStripMenuItem_Click;
            // 
            // cerrarTodasLasVentanasToolStripMenuItem
            // 
            cerrarTodasLasVentanasToolStripMenuItem.Name = "cerrarTodasLasVentanasToolStripMenuItem";
            cerrarTodasLasVentanasToolStripMenuItem.Size = new Size(205, 22);
            cerrarTodasLasVentanasToolStripMenuItem.Text = "Cerra&r todas las ventanas";
            cerrarTodasLasVentanasToolStripMenuItem.Click += cerrarTodasLasVentanasToolStripMenuItem_Click;
            // 
            // tsMenuAyuda
            // 
            tsMenuAyuda.DropDownItems.AddRange(new ToolStripItem[] { tsMenuConsola });
            tsMenuAyuda.Name = "tsMenuAyuda";
            tsMenuAyuda.Size = new Size(53, 20);
            tsMenuAyuda.Text = "A&yuda";
            // 
            // tsMenuConsola
            // 
            tsMenuConsola.Image = (Image)resources.GetObject("tsMenuConsola.Image");
            tsMenuConsola.Name = "tsMenuConsola";
            tsMenuConsola.Size = new Size(196, 22);
            tsMenuConsola.Text = "C&onsola de depuración";
            tsMenuConsola.Click += tsMenuConsola_Click;
            // 
            // pnTools
            // 
            pnTools.BackColor = SystemColors.Control;
            pnTools.Controls.Add(tsToolMain);
            pnTools.Dock = DockStyle.Left;
            pnTools.Location = new Point(0, 31);
            pnTools.Name = "pnTools";
            pnTools.Padding = new Padding(8);
            pnTools.Size = new Size(100, 637);
            pnTools.TabIndex = 4;
            // 
            // tsToolMain
            // 
            tsToolMain.AutoSize = false;
            tsToolMain.BackColor = SystemColors.Control;
            tsToolMain.Dock = DockStyle.Fill;
            tsToolMain.GripStyle = ToolStripGripStyle.Hidden;
            tsToolMain.ImageScalingSize = new Size(64, 64);
            tsToolMain.Items.AddRange(new ToolStripItem[] { tsBtnVentas, tsBtnCompras, toolStripSeparator1, tsBtnClientes, tsBtnProveedores, toolStripSeparator2, tsBtnEmisores, toolStripSeparator3, tsBtnConfig, toolStripSeparator4, tsBtnSalir });
            tsToolMain.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            tsToolMain.Location = new Point(8, 8);
            tsToolMain.Name = "tsToolMain";
            tsToolMain.Padding = new Padding(0);
            tsToolMain.Size = new Size(84, 621);
            tsToolMain.TabIndex = 3;
            tsToolMain.Text = "toolStrip1";
            // 
            // tsBtnVentas
            // 
            tsBtnVentas.Image = (Image)resources.GetObject("tsBtnVentas.Image");
            tsBtnVentas.ImageScaling = ToolStripItemImageScaling.None;
            tsBtnVentas.ImageTransparentColor = Color.Magenta;
            tsBtnVentas.Name = "tsBtnVentas";
            tsBtnVentas.Size = new Size(83, 51);
            tsBtnVentas.Text = "Ventas";
            tsBtnVentas.TextAlign = ContentAlignment.BottomCenter;
            tsBtnVentas.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // tsBtnCompras
            // 
            tsBtnCompras.Image = (Image)resources.GetObject("tsBtnCompras.Image");
            tsBtnCompras.ImageScaling = ToolStripItemImageScaling.None;
            tsBtnCompras.ImageTransparentColor = Color.Magenta;
            tsBtnCompras.Name = "tsBtnCompras";
            tsBtnCompras.Size = new Size(83, 51);
            tsBtnCompras.Text = "Compras";
            tsBtnCompras.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Margin = new Padding(5);
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(73, 6);
            // 
            // tsBtnClientes
            // 
            tsBtnClientes.Image = (Image)resources.GetObject("tsBtnClientes.Image");
            tsBtnClientes.ImageScaling = ToolStripItemImageScaling.None;
            tsBtnClientes.ImageTransparentColor = Color.Magenta;
            tsBtnClientes.Name = "tsBtnClientes";
            tsBtnClientes.Size = new Size(83, 51);
            tsBtnClientes.Text = "Clientes";
            tsBtnClientes.TextImageRelation = TextImageRelation.ImageAboveText;
            tsBtnClientes.Click += tsBtnClientes_Click;
            // 
            // tsBtnProveedores
            // 
            tsBtnProveedores.Image = (Image)resources.GetObject("tsBtnProveedores.Image");
            tsBtnProveedores.ImageScaling = ToolStripItemImageScaling.None;
            tsBtnProveedores.ImageTransparentColor = Color.Magenta;
            tsBtnProveedores.Name = "tsBtnProveedores";
            tsBtnProveedores.Size = new Size(83, 51);
            tsBtnProveedores.Text = "Proveedores";
            tsBtnProveedores.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Margin = new Padding(5);
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(73, 6);
            // 
            // tsBtnEmisores
            // 
            tsBtnEmisores.Image = (Image)resources.GetObject("tsBtnEmisores.Image");
            tsBtnEmisores.ImageScaling = ToolStripItemImageScaling.None;
            tsBtnEmisores.ImageTransparentColor = Color.Magenta;
            tsBtnEmisores.Name = "tsBtnEmisores";
            tsBtnEmisores.Size = new Size(83, 51);
            tsBtnEmisores.Text = "Emisores";
            tsBtnEmisores.TextImageRelation = TextImageRelation.ImageAboveText;
            tsBtnEmisores.Click += tsBtnEmisores_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Margin = new Padding(5);
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(73, 6);
            // 
            // tsBtnConfig
            // 
            tsBtnConfig.Image = (Image)resources.GetObject("tsBtnConfig.Image");
            tsBtnConfig.ImageScaling = ToolStripItemImageScaling.None;
            tsBtnConfig.ImageTransparentColor = Color.Magenta;
            tsBtnConfig.Name = "tsBtnConfig";
            tsBtnConfig.Size = new Size(83, 51);
            tsBtnConfig.Text = "Configuración";
            tsBtnConfig.TextImageRelation = TextImageRelation.ImageAboveText;
            tsBtnConfig.Click += tsBtnConfig_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Margin = new Padding(5);
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(73, 6);
            // 
            // tsBtnSalir
            // 
            tsBtnSalir.Image = (Image)resources.GetObject("tsBtnSalir.Image");
            tsBtnSalir.ImageScaling = ToolStripItemImageScaling.None;
            tsBtnSalir.ImageTransparentColor = Color.Magenta;
            tsBtnSalir.Name = "tsBtnSalir";
            tsBtnSalir.Size = new Size(83, 51);
            tsBtnSalir.Text = "Salir";
            tsBtnSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            tsBtnSalir.Click += tsBtnSalir_Click;
            // 
            // pnStatus
            // 
            pnStatus.Controls.Add(statusBar);
            pnStatus.Dock = DockStyle.Bottom;
            pnStatus.Location = new Point(100, 641);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(836, 27);
            pnStatus.TabIndex = 5;
            // 
            // statusBar
            // 
            statusBar.Items.AddRange(new ToolStripItem[] { tsLbEmisorTitle, tsLbEmisor, tbLbEstadoTitle, tsLbEstado });
            statusBar.Location = new Point(0, 0);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(836, 27);
            statusBar.TabIndex = 0;
            statusBar.Text = "statusStrip1";
            // 
            // tsLbEmisorTitle
            // 
            tsLbEmisorTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tsLbEmisorTitle.Name = "tsLbEmisorTitle";
            tsLbEmisorTitle.Size = new Size(47, 22);
            tsLbEmisorTitle.Text = "Emisor:";
            tsLbEmisorTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tsLbEmisor
            // 
            tsLbEmisor.AutoSize = false;
            tsLbEmisor.Name = "tsLbEmisor";
            tsLbEmisor.Size = new Size(200, 22);
            tsLbEmisor.Text = "Aquí la info del emisor";
            tsLbEmisor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbLbEstadoTitle
            // 
            tbLbEstadoTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tbLbEstadoTitle.Name = "tbLbEstadoTitle";
            tbLbEstadoTitle.Size = new Size(46, 22);
            tbLbEstadoTitle.Text = "Estado:";
            tbLbEstadoTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tsLbEstado
            // 
            tsLbEstado.Name = "tsLbEstado";
            tsLbEstado.Size = new Size(125, 22);
            tsLbEstado.Text = "Aquí la info del estado";
            tsLbEstado.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 668);
            Controls.Add(pnStatus);
            Controls.Add(pnTools);
            Controls.Add(pnMenu);
            IsMdiContainer = true;
            Name = "FrmMain";
            Text = "Factura DAM";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            pnMenu.ResumeLayout(false);
            pnMenu.PerformLayout();
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            pnTools.ResumeLayout(false);
            tsToolMain.ResumeLayout(false);
            tsToolMain.PerformLayout();
            pnStatus.ResumeLayout(false);
            pnStatus.PerformLayout();
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnMenu;
        private MenuStrip menuMain;
        private Panel pnTools;
        private Panel pnStatus;
        private StatusStrip statusBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStrip tsToolMain;
        private ToolStripButton tsBtnVentas;
        private ToolStripButton tsBtnCompras;
        private ToolStripButton tsBtnClientes;
        private ToolStripButton tsBtnProveedores;
        private ToolStripButton tsBtnEmisores;
        private ToolStripButton tsBtnConfig;
        private ToolStripButton tsBtnSalir;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripStatusLabel tsLbEmisorTitle;
        private ToolStripStatusLabel tsLbEmisor;
        private ToolStripStatusLabel tbLbEstadoTitle;
        private ToolStripStatusLabel tsLbEstado;
        private ToolStripMenuItem tsMenuAyuda;
        private ToolStripMenuItem tsMenuConsola;
        private ToolStripMenuItem tsMenuArchivo;
        private ToolStripMenuItem seleccionarEmisorToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem ventanasToolStripMenuItem;
        private ToolStripMenuItem cascadaToolStripMenuItem;
        private ToolStripMenuItem mosaicohorizontalToolStripMenuItem;
        private ToolStripMenuItem mosaicoverticalToolStripMenuItem;
        private ToolStripMenuItem cerrarTodasLasVentanasToolStripMenuItem;
    }
}
