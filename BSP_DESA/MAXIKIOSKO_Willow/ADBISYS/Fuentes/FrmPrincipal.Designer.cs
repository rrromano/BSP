﻿namespace ADBISYS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.StripPrincipal = new System.Windows.Forms.MenuStrip();
            this.artículosTS = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasTS = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaTS = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresTS = new System.Windows.Forms.ToolStripMenuItem();
            this.rubrosTS = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesTS = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaTS = new System.Windows.Forms.ToolStripMenuItem();
            this.salidaTS = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripPrincipal = new System.Windows.Forms.StatusStrip();
            this.fechaTSS = new System.Windows.Forms.ToolStripStatusLabel();
            this.salirTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioTSS = new System.Windows.Forms.ToolStripStatusLabel();
            this.horaTSS = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripPrincipal.SuspendLayout();
            this.statusStripPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // StripPrincipal
            // 
            this.StripPrincipal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.StripPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.StripPrincipal.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.StripPrincipal.Size = new System.Drawing.Size(1444, 30);
            this.StripPrincipal.TabIndex = 0;
            this.StripPrincipal.Text = "menuStrip1";
            // 
            // artículosTS
            // 
            this.artículosTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artículosTS.Name = "artículosTS";
            this.artículosTS.Size = new System.Drawing.Size(87, 24);
            this.artículosTS.Text = "Artículos";
            // 
            // ventasTS
            // 
            this.ventasTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventasTS.Name = "ventasTS";
            this.ventasTS.Size = new System.Drawing.Size(73, 24);
            this.ventasTS.Text = "Ventas";
            // 
            // cajaTS
            // 
            this.cajaTS.Name = "cajaTS";
            this.cajaTS.Size = new System.Drawing.Size(55, 24);
            this.cajaTS.Text = "Caja";
            // 
            // proveedoresTS
            // 
            this.proveedoresTS.Name = "proveedoresTS";
            this.proveedoresTS.Size = new System.Drawing.Size(115, 24);
            this.proveedoresTS.Text = "Proveedores";
            // 
            // rubrosTS
            // 
            this.rubrosTS.Name = "rubrosTS";
            this.rubrosTS.Size = new System.Drawing.Size(75, 24);
            this.rubrosTS.Text = "Rubros";
            // 
            // reportesTS
            // 
            this.reportesTS.Name = "reportesTS";
            this.reportesTS.Size = new System.Drawing.Size(89, 24);
            this.reportesTS.Text = "Reportes";
            // 
            // ayudaTS
            // 
            this.ayudaTS.Name = "ayudaTS";
            this.ayudaTS.Size = new System.Drawing.Size(67, 24);
            this.ayudaTS.Text = "Ayuda";
            // 
            // salidaTS
            // 
            this.salidaTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirTSMI});
            this.salidaTS.Name = "salidaTS";
            this.salidaTS.Size = new System.Drawing.Size(67, 24);
            this.salidaTS.Text = "Salida";
            // 
            // statusStripPrincipal
            // 
            this.statusStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fechaTSS,
            this.usuarioTSS,
            this.horaTSS});
            this.statusStripPrincipal.Location = new System.Drawing.Point(0, 569);
            this.statusStripPrincipal.Name = "statusStripPrincipal";
            this.statusStripPrincipal.Size = new System.Drawing.Size(1444, 29);
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
            // salirTSMI
            // 
            this.salirTSMI.Name = "salirTSMI";
            this.salirTSMI.Size = new System.Drawing.Size(152, 24);
            this.salirTSMI.Text = "Salir";
            this.salirTSMI.Click += new System.EventHandler(this.salirTSMI_Click);
            // 
            // usuarioTSS
            // 
            this.usuarioTSS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.usuarioTSS.Name = "usuarioTSS";
            this.usuarioTSS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.usuarioTSS.Size = new System.Drawing.Size(63, 24);
            this.usuarioTSS.Text = "Usuario";
            this.usuarioTSS.Visible = false;
            // 
            // horaTSS
            // 
            this.horaTSS.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.horaTSS.Name = "horaTSS";
            this.horaTSS.Size = new System.Drawing.Size(46, 24);
            this.horaTSS.Text = "Hora";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 598);
            this.Controls.Add(this.statusStripPrincipal);
            this.Controls.Add(this.StripPrincipal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maxikosko WILLOW - BSP - Brother\'s System\'s Programmer\'s - ADBISYS 1.0";
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





    }
}

