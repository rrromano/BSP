namespace ADBISYS
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.StripPrincipal = new System.Windows.Forms.MenuStrip();
            this.articulosTS = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasTS = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaTS = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresTS = new System.Windows.Forms.ToolStripMenuItem();
            this.rubrosTS = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesTS = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarTS = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaTS = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeWillowTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeBSPTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.salidaTS = new System.Windows.Forms.ToolStripMenuItem();
            this.salirTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripPrincipal = new System.Windows.Forms.StatusStrip();
            this.fechaTSS = new System.Windows.Forms.ToolStripStatusLabel();
            this.usuarioTSS = new System.Windows.Forms.ToolStripStatusLabel();
            this.vacioTSS = new System.Windows.Forms.ToolStripStatusLabel();
            this.maquinaTSS = new System.Windows.Forms.ToolStripStatusLabel();
            this.horaTSS = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.StripPrincipal.SuspendLayout();
            this.statusStripPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // StripPrincipal
            // 
            this.StripPrincipal.BackColor = System.Drawing.Color.White;
            this.StripPrincipal.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articulosTS,
            this.ventasTS,
            this.cajaTS,
            this.proveedoresTS,
            this.rubrosTS,
            this.reportesTS,
            this.ingresarTS,
            this.ayudaTS,
            this.salidaTS});
            this.StripPrincipal.Location = new System.Drawing.Point(0, 0);
            this.StripPrincipal.Name = "StripPrincipal";
            this.StripPrincipal.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.StripPrincipal.Size = new System.Drawing.Size(1916, 30);
            this.StripPrincipal.TabIndex = 0;
            this.StripPrincipal.Text = "menuStrip1";
            // 
            // articulosTS
            // 
            this.articulosTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.articulosTS.Name = "articulosTS";
            this.articulosTS.Size = new System.Drawing.Size(77, 22);
            this.articulosTS.Text = "&Artículos";
            this.articulosTS.Click += new System.EventHandler(this.articulosTS_Click);
            // 
            // ventasTS
            // 
            this.ventasTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventasTS.Name = "ventasTS";
            this.ventasTS.Size = new System.Drawing.Size(65, 22);
            this.ventasTS.Text = "&Ventas";
            // 
            // cajaTS
            // 
            this.cajaTS.Name = "cajaTS";
            this.cajaTS.Size = new System.Drawing.Size(54, 22);
            this.cajaTS.Text = "&Caja";
            // 
            // proveedoresTS
            // 
            this.proveedoresTS.Name = "proveedoresTS";
            this.proveedoresTS.Size = new System.Drawing.Size(114, 22);
            this.proveedoresTS.Text = "&Proveedores";
            // 
            // rubrosTS
            // 
            this.rubrosTS.Name = "rubrosTS";
            this.rubrosTS.Size = new System.Drawing.Size(72, 22);
            this.rubrosTS.Text = "R&ubros";
            // 
            // reportesTS
            // 
            this.reportesTS.Name = "reportesTS";
            this.reportesTS.Size = new System.Drawing.Size(87, 22);
            this.reportesTS.Text = "&Reportes";
            // 
            // ingresarTS
            // 
            this.ingresarTS.Name = "ingresarTS";
            this.ingresarTS.Size = new System.Drawing.Size(81, 22);
            this.ingresarTS.Text = "&Ingresar";
            // 
            // ayudaTS
            // 
            this.ayudaTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeWillowTSM,
            this.acercaDeBSPTSM});
            this.ayudaTS.Name = "ayudaTS";
            this.ayudaTS.Size = new System.Drawing.Size(66, 22);
            this.ayudaTS.Text = "A&yuda";
            // 
            // acercaDeWillowTSM
            // 
            this.acercaDeWillowTSM.Name = "acercaDeWillowTSM";
            this.acercaDeWillowTSM.Size = new System.Drawing.Size(201, 22);
            this.acercaDeWillowTSM.Text = "Acerca de Willow";
            // 
            // acercaDeBSPTSM
            // 
            this.acercaDeBSPTSM.Name = "acercaDeBSPTSM";
            this.acercaDeBSPTSM.Size = new System.Drawing.Size(201, 22);
            this.acercaDeBSPTSM.Text = "Acerca de BSP";
            // 
            // salidaTS
            // 
            this.salidaTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirTSMI});
            this.salidaTS.Name = "salidaTS";
            this.salidaTS.Size = new System.Drawing.Size(63, 22);
            this.salidaTS.Text = "&Salida";
            // 
            // salirTSMI
            // 
            this.salirTSMI.Name = "salirTSMI";
            this.salirTSMI.Size = new System.Drawing.Size(107, 22);
            this.salirTSMI.Text = "Salir";
            this.salirTSMI.Click += new System.EventHandler(this.salirTSMI_Click);
            // 
            // statusStripPrincipal
            // 
            this.statusStripPrincipal.BackColor = System.Drawing.Color.White;
            this.statusStripPrincipal.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fechaTSS,
            this.usuarioTSS,
            this.vacioTSS,
            this.maquinaTSS,
            this.horaTSS});
            this.statusStripPrincipal.Location = new System.Drawing.Point(0, 644);
            this.statusStripPrincipal.Name = "statusStripPrincipal";
            this.statusStripPrincipal.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStripPrincipal.Size = new System.Drawing.Size(1916, 29);
            this.statusStripPrincipal.TabIndex = 1;
            this.statusStripPrincipal.Text = "statusStrip1";
            // 
            // fechaTSS
            // 
            this.fechaTSS.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.fechaTSS.Name = "fechaTSS";
            this.fechaTSS.Size = new System.Drawing.Size(51, 24);
            this.fechaTSS.Text = "Fecha";
            // 
            // usuarioTSS
            // 
            this.usuarioTSS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.usuarioTSS.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioTSS.Name = "usuarioTSS";
            this.usuarioTSS.Size = new System.Drawing.Size(169, 24);
            this.usuarioTSS.Text = "Usuario Desconectado";
            // 
            // vacioTSS
            // 
            this.vacioTSS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.vacioTSS.Name = "vacioTSS";
            this.vacioTSS.Size = new System.Drawing.Size(1479, 24);
            this.vacioTSS.Spring = true;
            this.vacioTSS.Text = "Vacio";
            // 
            // maquinaTSS
            // 
            this.maquinaTSS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.maquinaTSS.Name = "maquinaTSS";
            this.maquinaTSS.Size = new System.Drawing.Size(151, 24);
            this.maquinaTSS.Text = "Nombre de Máquina";
            // 
            // horaTSS
            // 
            this.horaTSS.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.horaTSS.Name = "horaTSS";
            this.horaTSS.Size = new System.Drawing.Size(46, 24);
            this.horaTSS.Text = "Hora";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1916, 673);
            this.Controls.Add(this.statusStripPrincipal);
            this.Controls.Add(this.StripPrincipal);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "FrmPrincipal";
            this.Text = "Maxikosko WILLOW - BSP - Brother\'s System\'s Programmer\'s - ADBISYS 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.StripPrincipal.ResumeLayout(false);
            this.StripPrincipal.PerformLayout();
            this.statusStripPrincipal.ResumeLayout(false);
            this.statusStripPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip StripPrincipal;
        private System.Windows.Forms.ToolStripMenuItem articulosTS;
        private System.Windows.Forms.ToolStripMenuItem ventasTS;
        private System.Windows.Forms.ToolStripMenuItem cajaTS;
        private System.Windows.Forms.ToolStripMenuItem proveedoresTS;
        private System.Windows.Forms.ToolStripMenuItem rubrosTS;
        private System.Windows.Forms.ToolStripMenuItem reportesTS;
        private System.Windows.Forms.ToolStripMenuItem ayudaTS;
        private System.Windows.Forms.ToolStripMenuItem salidaTS;
        private System.Windows.Forms.StatusStrip statusStripPrincipal;
        private System.Windows.Forms.ToolStripStatusLabel fechaTSS;
        private System.Windows.Forms.ToolStripMenuItem salirTSMI;
        private System.Windows.Forms.ToolStripStatusLabel usuarioTSS;
        private System.Windows.Forms.ToolStripStatusLabel horaTSS;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem acercaDeBSPTSM;
        private System.Windows.Forms.ToolStripStatusLabel vacioTSS;
        private System.Windows.Forms.ToolStripStatusLabel maquinaTSS;
        private System.Windows.Forms.ToolStripMenuItem ingresarTS;
        private System.Windows.Forms.ToolStripMenuItem acercaDeWillowTSM;





    }
}

