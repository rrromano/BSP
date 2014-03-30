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
            this.artículosTS = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasTS = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaTS = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresTS = new System.Windows.Forms.ToolStripMenuItem();
            this.rubrosTS = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesTS = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaTS = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeBSPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.StripPrincipal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.StripPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.artículosTS,
            this.ventasTS,
            this.cajaTS,
            this.proveedoresTS,
            this.rubrosTS,
            this.reportesTS,
            this.ayudaTS,
            this.salidaTS});
            this.StripPrincipal.Location = new System.Drawing.Point(0, 0);
            this.StripPrincipal.Name = "StripPrincipal";
            this.StripPrincipal.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            this.StripPrincipal.Size = new System.Drawing.Size(1733, 36);
            this.StripPrincipal.TabIndex = 0;
            this.StripPrincipal.Text = "menuStrip1";
            // 
            // artículosTS
            // 
            this.artículosTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artículosTS.Name = "artículosTS";
            this.artículosTS.Size = new System.Drawing.Size(94, 28);
            this.artículosTS.Text = "&Artículos";
            // 
            // ventasTS
            // 
            this.ventasTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventasTS.Name = "ventasTS";
            this.ventasTS.Size = new System.Drawing.Size(80, 28);
            this.ventasTS.Text = "&Ventas";
            // 
            // cajaTS
            // 
            this.cajaTS.Name = "cajaTS";
            this.cajaTS.Size = new System.Drawing.Size(59, 28);
            this.cajaTS.Text = "&Caja";
            // 
            // proveedoresTS
            // 
            this.proveedoresTS.Name = "proveedoresTS";
            this.proveedoresTS.Size = new System.Drawing.Size(130, 28);
            this.proveedoresTS.Text = "&Proveedores";
            // 
            // rubrosTS
            // 
            this.rubrosTS.Name = "rubrosTS";
            this.rubrosTS.Size = new System.Drawing.Size(83, 28);
            this.rubrosTS.Text = "R&ubros";
            // 
            // reportesTS
            // 
            this.reportesTS.Name = "reportesTS";
            this.reportesTS.Size = new System.Drawing.Size(98, 28);
            this.reportesTS.Text = "&Reportes";
            // 
            // ayudaTS
            // 
            this.ayudaTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeBSPToolStripMenuItem});
            this.ayudaTS.Name = "ayudaTS";
            this.ayudaTS.Size = new System.Drawing.Size(76, 28);
            this.ayudaTS.Text = "A&yuda";
            // 
            // acercaDeBSPToolStripMenuItem
            // 
            this.acercaDeBSPToolStripMenuItem.Name = "acercaDeBSPToolStripMenuItem";
            this.acercaDeBSPToolStripMenuItem.Size = new System.Drawing.Size(208, 28);
            this.acercaDeBSPToolStripMenuItem.Text = "Acerca de BSP";
            // 
            // salidaTS
            // 
            this.salidaTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirTSMI});
            this.salidaTS.Name = "salidaTS";
            this.salidaTS.Size = new System.Drawing.Size(73, 28);
            this.salidaTS.Text = "&Salida";
            // 
            // salirTSMI
            // 
            this.salirTSMI.Name = "salirTSMI";
            this.salirTSMI.Size = new System.Drawing.Size(116, 28);
            this.salirTSMI.Text = "Salir";
            this.salirTSMI.Click += new System.EventHandler(this.salirTSMI_Click);
            // 
            // statusStripPrincipal
            // 
            this.statusStripPrincipal.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fechaTSS,
            this.usuarioTSS,
            this.vacioTSS,
            this.maquinaTSS,
            this.horaTSS});
            this.statusStripPrincipal.Location = new System.Drawing.Point(0, 714);
            this.statusStripPrincipal.Name = "statusStripPrincipal";
            this.statusStripPrincipal.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
            this.statusStripPrincipal.Size = new System.Drawing.Size(1733, 34);
            this.statusStripPrincipal.TabIndex = 1;
            this.statusStripPrincipal.Text = "statusStrip1";
            // 
            // fechaTSS
            // 
            this.fechaTSS.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.fechaTSS.Name = "fechaTSS";
            this.fechaTSS.Size = new System.Drawing.Size(65, 29);
            this.fechaTSS.Text = "Fecha";
            // 
            // usuarioTSS
            // 
            this.usuarioTSS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.usuarioTSS.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioTSS.Name = "usuarioTSS";
            this.usuarioTSS.Size = new System.Drawing.Size(215, 29);
            this.usuarioTSS.Text = "Usuario Desconectado";
            // 
            // vacioTSS
            // 
            this.vacioTSS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.vacioTSS.Name = "vacioTSS";
            this.vacioTSS.Size = new System.Drawing.Size(1187, 29);
            this.vacioTSS.Spring = true;
            this.vacioTSS.Text = "Vacio";
            // 
            // maquinaTSS
            // 
            this.maquinaTSS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.maquinaTSS.Name = "maquinaTSS";
            this.maquinaTSS.Size = new System.Drawing.Size(191, 29);
            this.maquinaTSS.Text = "Nombre de Máquina";
            // 
            // horaTSS
            // 
            this.horaTSS.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.horaTSS.Name = "horaTSS";
            this.horaTSS.Size = new System.Drawing.Size(57, 29);
            this.horaTSS.Text = "Hora";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1733, 748);
            this.Controls.Add(this.statusStripPrincipal);
            this.Controls.Add(this.StripPrincipal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
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
        private System.Windows.Forms.ToolStripMenuItem artículosTS;
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
        private System.Windows.Forms.ToolStripMenuItem acercaDeBSPToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel vacioTSS;
        private System.Windows.Forms.ToolStripStatusLabel maquinaTSS;





    }
}

