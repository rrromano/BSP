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
            this.ventasTS = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaVentaTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosTS = new System.Windows.Forms.ToolStripMenuItem();
            this.modifArticuloTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.actPrecioArticuloTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasTS = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarModificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaTS = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarCajaTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarCajaTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoMovimientoCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarModificarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.finalizarTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresTS = new System.Windows.Forms.ToolStripMenuItem();
            this.modifProveedoresTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.rubrosTS = new System.Windows.Forms.ToolStripMenuItem();
            this.modifRubrosTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesTS = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaDiariaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarTS = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarSesiónTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.adminUsuarioTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaTS = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeWillowTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeBSPTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.salidaTS = new System.Windows.Forms.ToolStripMenuItem();
            this.salirTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripPrincipal = new System.Windows.Forms.StatusStrip();
            this.fechaTSS = new System.Windows.Forms.ToolStripStatusLabel();
            this.usuarioTSS = new System.Windows.Forms.ToolStripStatusLabel();
            this.cajaTTS = new System.Windows.Forms.ToolStripStatusLabel();
            this.vacioTSS = new System.Windows.Forms.ToolStripStatusLabel();
            this.maquinaTSS = new System.Windows.Forms.ToolStripStatusLabel();
            this.horaTSS = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.nuevaVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StripPrincipal.SuspendLayout();
            this.statusStripPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // StripPrincipal
            // 
            this.StripPrincipal.BackColor = System.Drawing.Color.White;
            this.StripPrincipal.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasTS,
            this.articulosTS,
            this.comprasTS,
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
            this.StripPrincipal.Size = new System.Drawing.Size(1274, 35);
            this.StripPrincipal.TabIndex = 0;
            this.StripPrincipal.Text = "menuStrip1";
            // 
            // ventasTS
            // 
            this.ventasTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaVentaToolStripMenuItem,
            this.nuevaVentaTSMI});
            this.ventasTS.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventasTS.Name = "ventasTS";
            this.ventasTS.Size = new System.Drawing.Size(86, 27);
            this.ventasTS.Text = "&Ventas";
            // 
            // nuevaVentaTSMI
            // 
            this.nuevaVentaTSMI.Name = "nuevaVentaTSMI";
            this.nuevaVentaTSMI.Size = new System.Drawing.Size(284, 28);
            this.nuevaVentaTSMI.Text = "Visualizar / Modificar";
            this.nuevaVentaTSMI.Click += new System.EventHandler(this.nuevaVentaTSMI_Click);
            // 
            // articulosTS
            // 
            this.articulosTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifArticuloTSMI,
            this.actPrecioArticuloTSMI});
            this.articulosTS.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.articulosTS.Name = "articulosTS";
            this.articulosTS.Size = new System.Drawing.Size(106, 27);
            this.articulosTS.Text = "&Artículos";
            this.articulosTS.Click += new System.EventHandler(this.articulosTS_Click);
            // 
            // modifArticuloTSMI
            // 
            this.modifArticuloTSMI.Name = "modifArticuloTSMI";
            this.modifArticuloTSMI.Size = new System.Drawing.Size(311, 28);
            this.modifArticuloTSMI.Text = "Agregar / Modificar";
            this.modifArticuloTSMI.Click += new System.EventHandler(this.modifArticuloTSMI_Click);
            // 
            // actPrecioArticuloTSMI
            // 
            this.actPrecioArticuloTSMI.Name = "actPrecioArticuloTSMI";
            this.actPrecioArticuloTSMI.Size = new System.Drawing.Size(311, 28);
            this.actPrecioArticuloTSMI.Text = "Actualización de Precios";
            this.actPrecioArticuloTSMI.Click += new System.EventHandler(this.actPrecioArticuloTSMI_Click);
            // 
            // comprasTS
            // 
            this.comprasTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarModificarToolStripMenuItem});
            this.comprasTS.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comprasTS.Name = "comprasTS";
            this.comprasTS.Size = new System.Drawing.Size(106, 27);
            this.comprasTS.Text = "C&ompras";
            // 
            // agregarModificarToolStripMenuItem
            // 
            this.agregarModificarToolStripMenuItem.Name = "agregarModificarToolStripMenuItem";
            this.agregarModificarToolStripMenuItem.Size = new System.Drawing.Size(266, 28);
            this.agregarModificarToolStripMenuItem.Text = "Agregar / Modificar";
            this.agregarModificarToolStripMenuItem.Click += new System.EventHandler(this.agregarModificarToolStripMenuItem_Click);
            // 
            // cajaTS
            // 
            this.cajaTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarCajaTSMI,
            this.modificarCajaTSMI,
            this.tipoMovimientoCajaToolStripMenuItem,
            this.finalizarTSMI});
            this.cajaTS.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cajaTS.Name = "cajaTS";
            this.cajaTS.Size = new System.Drawing.Size(64, 27);
            this.cajaTS.Text = "&Caja";
            // 
            // iniciarCajaTSMI
            // 
            this.iniciarCajaTSMI.Name = "iniciarCajaTSMI";
            this.iniciarCajaTSMI.Size = new System.Drawing.Size(369, 28);
            this.iniciarCajaTSMI.Text = "Iniciar";
            this.iniciarCajaTSMI.Click += new System.EventHandler(this.iniciarCajaTSMI_Click);
            // 
            // modificarCajaTSMI
            // 
            this.modificarCajaTSMI.Name = "modificarCajaTSMI";
            this.modificarCajaTSMI.Size = new System.Drawing.Size(369, 28);
            this.modificarCajaTSMI.Text = "Visualizar / Modificar ";
            this.modificarCajaTSMI.Click += new System.EventHandler(this.modificarCajaTSMI_Click);
            // 
            // tipoMovimientoCajaToolStripMenuItem
            // 
            this.tipoMovimientoCajaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarModificarToolStripMenuItem1});
            this.tipoMovimientoCajaToolStripMenuItem.Name = "tipoMovimientoCajaToolStripMenuItem";
            this.tipoMovimientoCajaToolStripMenuItem.Size = new System.Drawing.Size(369, 28);
            this.tipoMovimientoCajaToolStripMenuItem.Text = "Tipos de Movimientos de Caja";
            // 
            // agregarModificarToolStripMenuItem1
            // 
            this.agregarModificarToolStripMenuItem1.Name = "agregarModificarToolStripMenuItem1";
            this.agregarModificarToolStripMenuItem1.Size = new System.Drawing.Size(266, 28);
            this.agregarModificarToolStripMenuItem1.Text = "Agregar / Modificar";
            this.agregarModificarToolStripMenuItem1.Click += new System.EventHandler(this.agregarModificarToolStripMenuItem1_Click);
            // 
            // finalizarTSMI
            // 
            this.finalizarTSMI.Name = "finalizarTSMI";
            this.finalizarTSMI.Size = new System.Drawing.Size(369, 28);
            this.finalizarTSMI.Text = "Finalizar";
            this.finalizarTSMI.Click += new System.EventHandler(this.finalizarTSMI_Click);
            // 
            // proveedoresTS
            // 
            this.proveedoresTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifProveedoresTSMI});
            this.proveedoresTS.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proveedoresTS.Name = "proveedoresTS";
            this.proveedoresTS.Size = new System.Drawing.Size(139, 27);
            this.proveedoresTS.Text = "&Proveedores";
            // 
            // modifProveedoresTSMI
            // 
            this.modifProveedoresTSMI.Name = "modifProveedoresTSMI";
            this.modifProveedoresTSMI.Size = new System.Drawing.Size(266, 28);
            this.modifProveedoresTSMI.Text = "Agregar / Modificar";
            this.modifProveedoresTSMI.Click += new System.EventHandler(this.modifProveedoresTSMI_Click);
            // 
            // rubrosTS
            // 
            this.rubrosTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifRubrosTSMI});
            this.rubrosTS.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rubrosTS.Name = "rubrosTS";
            this.rubrosTS.Size = new System.Drawing.Size(89, 27);
            this.rubrosTS.Text = "R&ubros";
            // 
            // modifRubrosTSMI
            // 
            this.modifRubrosTSMI.Name = "modifRubrosTSMI";
            this.modifRubrosTSMI.Size = new System.Drawing.Size(266, 28);
            this.modifRubrosTSMI.Text = "Agregar / Modificar";
            this.modifRubrosTSMI.Click += new System.EventHandler(this.modifRubrosTSMI_Click);
            // 
            // reportesTS
            // 
            this.reportesTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cajaDiariaToolStripMenuItem,
            this.comprasToolStripMenuItem,
            this.ventasToolStripMenuItem});
            this.reportesTS.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportesTS.Name = "reportesTS";
            this.reportesTS.Size = new System.Drawing.Size(106, 27);
            this.reportesTS.Text = "&Reportes";
            // 
            // cajaDiariaToolStripMenuItem
            // 
            this.cajaDiariaToolStripMenuItem.Name = "cajaDiariaToolStripMenuItem";
            this.cajaDiariaToolStripMenuItem.Size = new System.Drawing.Size(186, 28);
            this.cajaDiariaToolStripMenuItem.Text = "Caja Diaria";
            this.cajaDiariaToolStripMenuItem.Click += new System.EventHandler(this.cajaDiariaToolStripMenuItem_Click);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(186, 28);
            this.comprasToolStripMenuItem.Text = "Compras";
            this.comprasToolStripMenuItem.Click += new System.EventHandler(this.comprasToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(186, 28);
            this.ventasToolStripMenuItem.Text = "Ventas";
            this.ventasToolStripMenuItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);
            // 
            // ingresarTS
            // 
            this.ingresarTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarSesiónTSMI,
            this.adminUsuarioTSMI,
            this.cerrarSesiónTSMI});
            this.ingresarTS.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ingresarTS.Name = "ingresarTS";
            this.ingresarTS.Size = new System.Drawing.Size(102, 27);
            this.ingresarTS.Text = "&Ingresar";
            // 
            // iniciarSesiónTSMI
            // 
            this.iniciarSesiónTSMI.Name = "iniciarSesiónTSMI";
            this.iniciarSesiónTSMI.Size = new System.Drawing.Size(271, 28);
            this.iniciarSesiónTSMI.Text = "Iniciar Sesión";
            this.iniciarSesiónTSMI.Click += new System.EventHandler(this.iniciarSesiónTSMI_Click);
            // 
            // adminUsuarioTSMI
            // 
            this.adminUsuarioTSMI.Name = "adminUsuarioTSMI";
            this.adminUsuarioTSMI.Size = new System.Drawing.Size(271, 28);
            this.adminUsuarioTSMI.Text = "Administrar Usuario";
            this.adminUsuarioTSMI.Click += new System.EventHandler(this.adminUsuarioTSMI_Click);
            // 
            // cerrarSesiónTSMI
            // 
            this.cerrarSesiónTSMI.Name = "cerrarSesiónTSMI";
            this.cerrarSesiónTSMI.Size = new System.Drawing.Size(271, 28);
            this.cerrarSesiónTSMI.Text = "Cerrar Sesión";
            this.cerrarSesiónTSMI.Click += new System.EventHandler(this.cerrarSesiónTSMI_Click);
            // 
            // ayudaTS
            // 
            this.ayudaTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeWillowTSMI,
            this.acercaDeBSPTSMI});
            this.ayudaTS.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ayudaTS.Name = "ayudaTS";
            this.ayudaTS.Size = new System.Drawing.Size(81, 27);
            this.ayudaTS.Text = "A&yuda";
            // 
            // acercaDeWillowTSMI
            // 
            this.acercaDeWillowTSMI.Name = "acercaDeWillowTSMI";
            this.acercaDeWillowTSMI.Size = new System.Drawing.Size(245, 28);
            this.acercaDeWillowTSMI.Text = "Acerca de Willow";
            this.acercaDeWillowTSMI.Click += new System.EventHandler(this.acercaDeWillowTSMI_Click);
            // 
            // acercaDeBSPTSMI
            // 
            this.acercaDeBSPTSMI.Name = "acercaDeBSPTSMI";
            this.acercaDeBSPTSMI.Size = new System.Drawing.Size(245, 28);
            this.acercaDeBSPTSMI.Text = "Acerca de BSP";
            this.acercaDeBSPTSMI.Click += new System.EventHandler(this.acercaDeBSPTSMI_Click);
            // 
            // salidaTS
            // 
            this.salidaTS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirTSMI});
            this.salidaTS.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salidaTS.Name = "salidaTS";
            this.salidaTS.Size = new System.Drawing.Size(81, 27);
            this.salidaTS.Text = "&Salida";
            // 
            // salirTSMI
            // 
            this.salirTSMI.Name = "salirTSMI";
            this.salirTSMI.Size = new System.Drawing.Size(124, 28);
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
            this.cajaTTS,
            this.vacioTSS,
            this.maquinaTSS,
            this.horaTSS});
            this.statusStripPrincipal.Location = new System.Drawing.Point(0, 639);
            this.statusStripPrincipal.Name = "statusStripPrincipal";
            this.statusStripPrincipal.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStripPrincipal.Size = new System.Drawing.Size(1274, 34);
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
            this.usuarioTSS.BackColor = System.Drawing.Color.White;
            this.usuarioTSS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.usuarioTSS.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioTSS.ForeColor = System.Drawing.Color.Black;
            this.usuarioTSS.Name = "usuarioTSS";
            this.usuarioTSS.Size = new System.Drawing.Size(215, 29);
            this.usuarioTSS.Text = "Usuario Desconectado";
            // 
            // cajaTTS
            // 
            this.cajaTTS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.cajaTTS.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cajaTTS.Name = "cajaTTS";
            this.cajaTTS.Size = new System.Drawing.Size(128, 29);
            this.cajaTTS.Text = "Caja Cerrada";
            // 
            // vacioTSS
            // 
            this.vacioTSS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.vacioTSS.Name = "vacioTSS";
            this.vacioTSS.Size = new System.Drawing.Size(598, 29);
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
            // nuevaVentaToolStripMenuItem
            // 
            this.nuevaVentaToolStripMenuItem.Name = "nuevaVentaToolStripMenuItem";
            this.nuevaVentaToolStripMenuItem.Size = new System.Drawing.Size(284, 28);
            this.nuevaVentaToolStripMenuItem.Text = "Nueva Venta";
            this.nuevaVentaToolStripMenuItem.Click += new System.EventHandler(this.nuevaVentaToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1274, 673);
            this.Controls.Add(this.statusStripPrincipal);
            this.Controls.Add(this.StripPrincipal);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "FrmPrincipal";
            this.Text = "Maxikosko WILLOW - BSP - Brothers Systems Programmers - ADBISYS 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem acercaDeBSPTSMI;
        private System.Windows.Forms.ToolStripStatusLabel vacioTSS;
        private System.Windows.Forms.ToolStripStatusLabel maquinaTSS;
        private System.Windows.Forms.ToolStripMenuItem ingresarTS;
        private System.Windows.Forms.ToolStripMenuItem acercaDeWillowTSMI;
        private System.Windows.Forms.ToolStripMenuItem iniciarCajaTSMI;
        private System.Windows.Forms.ToolStripMenuItem modificarCajaTSMI;
        private System.Windows.Forms.ToolStripMenuItem finalizarTSMI;
        private System.Windows.Forms.ToolStripMenuItem iniciarSesiónTSMI;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónTSMI;
        private System.Windows.Forms.ToolStripMenuItem modifArticuloTSMI;
        private System.Windows.Forms.ToolStripMenuItem actPrecioArticuloTSMI;
        private System.Windows.Forms.ToolStripMenuItem modifProveedoresTSMI;
        private System.Windows.Forms.ToolStripMenuItem modifRubrosTSMI;
        private System.Windows.Forms.ToolStripMenuItem nuevaVentaTSMI;
        private System.Windows.Forms.ToolStripMenuItem adminUsuarioTSMI;
        private System.Windows.Forms.ToolStripMenuItem comprasTS;
        private System.Windows.Forms.ToolStripMenuItem tipoMovimientoCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarModificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarModificarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel cajaTTS;
        private System.Windows.Forms.ToolStripMenuItem cajaDiariaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaVentaToolStripMenuItem;





    }
}

