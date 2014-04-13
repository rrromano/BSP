namespace ADBISYS.Formularios.Caja
{
    partial class frmVisualizarCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizarCaja));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdMovsCaja = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIngresos = new System.Windows.Forms.TextBox();
            this.txtTotalVentas = new System.Windows.Forms.TextBox();
            this.txtCajaActual = new System.Windows.Forms.TextBox();
            this.txtRetiros = new System.Windows.Forms.TextBox();
            this.txtGastos = new System.Windows.Forms.TextBox();
            this.txtTotalCompras = new System.Windows.Forms.TextBox();
            this.txtCajaInicial = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMovsCaja)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdMovsCaja);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(849, 280);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movimientos de la Caja";
            // 
            // grdMovsCaja
            // 
            this.grdMovsCaja.AllowUserToAddRows = false;
            this.grdMovsCaja.AllowUserToDeleteRows = false;
            this.grdMovsCaja.AllowUserToOrderColumns = true;
            this.grdMovsCaja.AllowUserToResizeRows = false;
            this.grdMovsCaja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdMovsCaja.BackgroundColor = System.Drawing.Color.White;
            this.grdMovsCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMovsCaja.Location = new System.Drawing.Point(32, 44);
            this.grdMovsCaja.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grdMovsCaja.Name = "grdMovsCaja";
            this.grdMovsCaja.RowTemplate.Height = 24;
            this.grdMovsCaja.Size = new System.Drawing.Size(779, 202);
            this.grdMovsCaja.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Verdana", 10.8F);
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSalir.Location = new System.Drawing.Point(711, 556);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(153, 46);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtIngresos);
            this.groupBox2.Controls.Add(this.txtTotalVentas);
            this.groupBox2.Controls.Add(this.txtCajaActual);
            this.groupBox2.Controls.Add(this.txtRetiros);
            this.groupBox2.Controls.Add(this.txtGastos);
            this.groupBox2.Controls.Add(this.txtTotalCompras);
            this.groupBox2.Controls.Add(this.txtCajaInicial);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(15, 307);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(849, 237);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Totales";
            // 
            // txtIngresos
            // 
            this.txtIngresos.Enabled = false;
            this.txtIngresos.Font = new System.Drawing.Font("Verdana", 10.8F);
            this.txtIngresos.Location = new System.Drawing.Point(604, 131);
            this.txtIngresos.Margin = new System.Windows.Forms.Padding(6);
            this.txtIngresos.Name = "txtIngresos";
            this.txtIngresos.Size = new System.Drawing.Size(224, 29);
            this.txtIngresos.TabIndex = 13;
            // 
            // txtTotalVentas
            // 
            this.txtTotalVentas.Enabled = false;
            this.txtTotalVentas.Font = new System.Drawing.Font("Verdana", 10.8F);
            this.txtTotalVentas.Location = new System.Drawing.Point(604, 90);
            this.txtTotalVentas.Margin = new System.Windows.Forms.Padding(6);
            this.txtTotalVentas.Name = "txtTotalVentas";
            this.txtTotalVentas.Size = new System.Drawing.Size(224, 29);
            this.txtTotalVentas.TabIndex = 12;
            // 
            // txtCajaActual
            // 
            this.txtCajaActual.Enabled = false;
            this.txtCajaActual.Font = new System.Drawing.Font("Verdana", 10.8F);
            this.txtCajaActual.Location = new System.Drawing.Point(604, 49);
            this.txtCajaActual.Margin = new System.Windows.Forms.Padding(6);
            this.txtCajaActual.Name = "txtCajaActual";
            this.txtCajaActual.Size = new System.Drawing.Size(224, 29);
            this.txtCajaActual.TabIndex = 11;
            // 
            // txtRetiros
            // 
            this.txtRetiros.Enabled = false;
            this.txtRetiros.Font = new System.Drawing.Font("Verdana", 10.8F);
            this.txtRetiros.Location = new System.Drawing.Point(187, 172);
            this.txtRetiros.Margin = new System.Windows.Forms.Padding(6);
            this.txtRetiros.Name = "txtRetiros";
            this.txtRetiros.Size = new System.Drawing.Size(224, 29);
            this.txtRetiros.TabIndex = 10;
            // 
            // txtGastos
            // 
            this.txtGastos.Enabled = false;
            this.txtGastos.Font = new System.Drawing.Font("Verdana", 10.8F);
            this.txtGastos.Location = new System.Drawing.Point(187, 131);
            this.txtGastos.Margin = new System.Windows.Forms.Padding(6);
            this.txtGastos.Name = "txtGastos";
            this.txtGastos.Size = new System.Drawing.Size(224, 29);
            this.txtGastos.TabIndex = 9;
            // 
            // txtTotalCompras
            // 
            this.txtTotalCompras.Enabled = false;
            this.txtTotalCompras.Font = new System.Drawing.Font("Verdana", 10.8F);
            this.txtTotalCompras.Location = new System.Drawing.Point(187, 90);
            this.txtTotalCompras.Margin = new System.Windows.Forms.Padding(6);
            this.txtTotalCompras.Name = "txtTotalCompras";
            this.txtTotalCompras.Size = new System.Drawing.Size(224, 29);
            this.txtTotalCompras.TabIndex = 8;
            // 
            // txtCajaInicial
            // 
            this.txtCajaInicial.Enabled = false;
            this.txtCajaInicial.Font = new System.Drawing.Font("Verdana", 10.8F);
            this.txtCajaInicial.Location = new System.Drawing.Point(187, 49);
            this.txtCajaInicial.Margin = new System.Windows.Forms.Padding(6);
            this.txtCajaInicial.Name = "txtCajaInicial";
            this.txtCajaInicial.Size = new System.Drawing.Size(224, 29);
            this.txtCajaInicial.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 10.8F);
            this.label7.Location = new System.Drawing.Point(38, 175);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Retiros";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10.8F);
            this.label6.Location = new System.Drawing.Point(440, 132);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Otros Ingresos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 10.8F);
            this.label5.Location = new System.Drawing.Point(38, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Otros Gastos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10.8F);
            this.label4.Location = new System.Drawing.Point(440, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ventas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.8F);
            this.label3.Location = new System.Drawing.Point(440, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Caja Actual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.8F);
            this.label2.Location = new System.Drawing.Point(38, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Compras";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Caja Inicial";
            // 
            // frmVisualizarCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 618);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmVisualizarCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caja";
            this.Activated += new System.EventHandler(this.frmVisualizarCaja_Activated);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMovsCaja)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdMovsCaja;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtIngresos;
        private System.Windows.Forms.TextBox txtTotalVentas;
        private System.Windows.Forms.TextBox txtCajaActual;
        private System.Windows.Forms.TextBox txtRetiros;
        private System.Windows.Forms.TextBox txtGastos;
        private System.Windows.Forms.TextBox txtTotalCompras;
        private System.Windows.Forms.TextBox txtCajaInicial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}