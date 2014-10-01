namespace ADBISYS.Formularios.Reportes
{
    partial class frmReporteCajaDiaria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteCajaDiaria));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnItemsEliminados = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdMovimientosCaja = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtpFechaCaja = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMovimientosCaja)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(17, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 646);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnItemsEliminados);
            this.groupBox5.Location = new System.Drawing.Point(545, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(233, 115);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            // 
            // btnItemsEliminados
            // 
            this.btnItemsEliminados.Enabled = false;
            this.btnItemsEliminados.Image = ((System.Drawing.Image)(resources.GetObject("btnItemsEliminados.Image")));
            this.btnItemsEliminados.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnItemsEliminados.Location = new System.Drawing.Point(21, 28);
            this.btnItemsEliminados.Name = "btnItemsEliminados";
            this.btnItemsEliminados.Size = new System.Drawing.Size(191, 69);
            this.btnItemsEliminados.TabIndex = 1;
            this.btnItemsEliminados.Text = "&Items Eliminados";
            this.btnItemsEliminados.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnItemsEliminados.UseVisualStyleBackColor = true;
            this.btnItemsEliminados.Click += new System.EventHandler(this.btnItemsEliminados_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSalir);
            this.groupBox4.Controls.Add(this.btnGenerarReporte);
            this.groupBox4.Location = new System.Drawing.Point(340, 516);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(438, 112);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(20, 28);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(191, 67);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Enabled = false;
            this.btnGenerarReporte.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerarReporte.Image")));
            this.btnGenerarReporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGenerarReporte.Location = new System.Drawing.Point(227, 28);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(191, 67);
            this.btnGenerarReporte.TabIndex = 1;
            this.btnGenerarReporte.Text = "&Generar Reporte";
            this.btnGenerarReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdMovimientosCaja);
            this.groupBox3.Location = new System.Drawing.Point(19, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(759, 371);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Movimientos de Caja";
            // 
            // grdMovimientosCaja
            // 
            this.grdMovimientosCaja.BackgroundColor = System.Drawing.Color.White;
            this.grdMovimientosCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMovimientosCaja.Location = new System.Drawing.Point(19, 29);
            this.grdMovimientosCaja.Name = "grdMovimientosCaja";
            this.grdMovimientosCaja.RowTemplate.Height = 24;
            this.grdMovimientosCaja.Size = new System.Drawing.Size(720, 321);
            this.grdMovimientosCaja.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.dtpFechaCaja);
            this.groupBox2.Location = new System.Drawing.Point(19, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 115);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccione una Fecha:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(251, 38);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(60, 49);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtpFechaCaja
            // 
            this.dtpFechaCaja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCaja.Location = new System.Drawing.Point(19, 49);
            this.dtpFechaCaja.Name = "dtpFechaCaja";
            this.dtpFechaCaja.Size = new System.Drawing.Size(215, 29);
            this.dtpFechaCaja.TabIndex = 1;
            this.dtpFechaCaja.ValueChanged += new System.EventHandler(this.dtpFechaCaja_ValueChanged);
            // 
            // frmReporteCajaDiaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 670);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 10.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReporteCajaDiaria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Caja Diaria";
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMovimientosCaja)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpFechaCaja;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grdMovimientosCaja;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnItemsEliminados;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}