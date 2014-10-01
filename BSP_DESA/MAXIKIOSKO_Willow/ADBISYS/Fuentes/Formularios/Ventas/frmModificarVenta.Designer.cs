namespace ADBISYS.Formularios.Ventas
{
    partial class frmModificarVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificarVenta));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdItemsVenta = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnConfirmarModificacionVenta = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalVenta = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnEliminarArticulo = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBuscarArticulo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsVenta)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdItemsVenta);
            this.groupBox3.Location = new System.Drawing.Point(12, 105);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(918, 374);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Items Compra";
            // 
            // grdItemsVenta
            // 
            this.grdItemsVenta.BackgroundColor = System.Drawing.Color.White;
            this.grdItemsVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItemsVenta.Location = new System.Drawing.Point(15, 28);
            this.grdItemsVenta.Name = "grdItemsVenta";
            this.grdItemsVenta.RowTemplate.Height = 24;
            this.grdItemsVenta.Size = new System.Drawing.Size(887, 330);
            this.grdItemsVenta.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnConfirmarModificacionVenta);
            this.groupBox5.Controls.Add(this.btnSalir);
            this.groupBox5.Location = new System.Drawing.Point(12, 485);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(383, 108);
            this.groupBox5.TabIndex = 52;
            this.groupBox5.TabStop = false;
            // 
            // btnConfirmarModificacionVenta
            // 
            this.btnConfirmarModificacionVenta.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarModificacionVenta.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmarModificacionVenta.Image")));
            this.btnConfirmarModificacionVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmarModificacionVenta.Location = new System.Drawing.Point(206, 28);
            this.btnConfirmarModificacionVenta.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirmarModificacionVenta.Name = "btnConfirmarModificacionVenta";
            this.btnConfirmarModificacionVenta.Size = new System.Drawing.Size(146, 69);
            this.btnConfirmarModificacionVenta.TabIndex = 0;
            this.btnConfirmarModificacionVenta.Text = "&Confirmar";
            this.btnConfirmarModificacionVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmarModificacionVenta.UseVisualStyleBackColor = true;
            this.btnConfirmarModificacionVenta.Click += new System.EventHandler(this.btnConfirmarModificacionVenta_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(31, 28);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(146, 69);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalVenta);
            this.groupBox2.Location = new System.Drawing.Point(715, 485);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 108);
            this.groupBox2.TabIndex = 82;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total";
            // 
            // lblTotalVenta
            // 
            this.lblTotalVenta.AutoSize = true;
            this.lblTotalVenta.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVenta.Location = new System.Drawing.Point(52, 43);
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Size = new System.Drawing.Size(113, 36);
            this.lblTotalVenta.TabIndex = 0;
            this.lblTotalVenta.Text = "TOTAL";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnEliminarArticulo);
            this.groupBox7.Location = new System.Drawing.Point(782, 9);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(146, 90);
            this.groupBox7.TabIndex = 86;
            this.groupBox7.TabStop = false;
            // 
            // btnEliminarArticulo
            // 
            this.btnEliminarArticulo.Enabled = false;
            this.btnEliminarArticulo.Location = new System.Drawing.Point(18, 22);
            this.btnEliminarArticulo.Name = "btnEliminarArticulo";
            this.btnEliminarArticulo.Size = new System.Drawing.Size(112, 58);
            this.btnEliminarArticulo.TabIndex = 0;
            this.btnEliminarArticulo.Text = "Eliminar";
            this.btnEliminarArticulo.UseVisualStyleBackColor = true;
            this.btnEliminarArticulo.Click += new System.EventHandler(this.btnEliminarArticulo_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtCantidad);
            this.groupBox6.Location = new System.Drawing.Point(12, 9);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(110, 90);
            this.groupBox6.TabIndex = 85;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(27, 35);
            this.txtCantidad.MaxLength = 3;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(55, 35);
            this.txtCantidad.TabIndex = 0;
            this.txtCantidad.Text = "1";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBuscarArticulo);
            this.groupBox4.Location = new System.Drawing.Point(669, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(107, 90);
            this.groupBox4.TabIndex = 84;
            this.groupBox4.TabStop = false;
            // 
            // btnBuscarArticulo
            // 
            this.btnBuscarArticulo.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarArticulo.Image")));
            this.btnBuscarArticulo.Location = new System.Drawing.Point(18, 22);
            this.btnBuscarArticulo.Name = "btnBuscarArticulo";
            this.btnBuscarArticulo.Size = new System.Drawing.Size(73, 58);
            this.btnBuscarArticulo.TabIndex = 0;
            this.btnBuscarArticulo.UseVisualStyleBackColor = true;
            this.btnBuscarArticulo.Click += new System.EventHandler(this.btnBuscarArticulo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodigoArticulo);
            this.groupBox1.Location = new System.Drawing.Point(128, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 90);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Código de Artículo";
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoArticulo.Location = new System.Drawing.Point(21, 35);
            this.txtCodigoArticulo.MaxLength = 20;
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(493, 35);
            this.txtCodigoArticulo.TabIndex = 0;
            // 
            // frmModificarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 605);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmModificarVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Venta";
            this.Load += new System.EventHandler(this.frmModificarVenta_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsVenta)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grdItemsVenta;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnConfirmarModificacionVenta;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalVenta;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnEliminarArticulo;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBuscarArticulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
    }
}