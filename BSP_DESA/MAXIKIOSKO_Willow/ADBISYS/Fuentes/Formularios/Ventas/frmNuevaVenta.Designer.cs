namespace ADBISYS.Formularios.Ventas
{
    partial class frmNuevaVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaVenta));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdItemsVenta = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBuscarArticulo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalVenta = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnConfirmarVenta = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnEliminarArticulo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsVenta)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodigoArticulo);
            this.groupBox1.Location = new System.Drawing.Point(134, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 90);
            this.groupBox1.TabIndex = 1;
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
            this.txtCodigoArticulo.TabIndex = 1;
            this.txtCodigoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoArticulo_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdItemsVenta);
            this.groupBox3.Location = new System.Drawing.Point(16, 105);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(918, 378);
            this.groupBox3.TabIndex = 4;
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
            this.grdItemsVenta.Size = new System.Drawing.Size(887, 334);
            this.grdItemsVenta.TabIndex = 1;
            this.grdItemsVenta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdItemsVenta_CellClick);
            this.grdItemsVenta.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdItemsVenta_CellValueChanged);
            this.grdItemsVenta.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdItemsVenta_CurrentCellDirtyStateChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBuscarArticulo);
            this.groupBox4.Location = new System.Drawing.Point(675, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(107, 90);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // btnBuscarArticulo
            // 
            this.btnBuscarArticulo.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarArticulo.Image")));
            this.btnBuscarArticulo.Location = new System.Drawing.Point(18, 21);
            this.btnBuscarArticulo.Name = "btnBuscarArticulo";
            this.btnBuscarArticulo.Size = new System.Drawing.Size(73, 58);
            this.btnBuscarArticulo.TabIndex = 1;
            this.btnBuscarArticulo.UseVisualStyleBackColor = true;
            this.btnBuscarArticulo.Click += new System.EventHandler(this.btnBuscarArticulo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalVenta);
            this.groupBox2.Location = new System.Drawing.Point(717, 485);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 108);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total";
            // 
            // lblTotalVenta
            // 
            this.lblTotalVenta.AutoSize = true;
            this.lblTotalVenta.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVenta.Location = new System.Drawing.Point(55, 43);
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Size = new System.Drawing.Size(113, 36);
            this.lblTotalVenta.TabIndex = 0;
            this.lblTotalVenta.Text = "TOTAL";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnConfirmarVenta);
            this.groupBox5.Controls.Add(this.btnSalir);
            this.groupBox5.Location = new System.Drawing.Point(16, 485);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(335, 108);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.TabIndexChanged += new System.EventHandler(this.groupBox5_TabIndexChanged);
            // 
            // btnConfirmarVenta
            // 
            this.btnConfirmarVenta.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarVenta.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmarVenta.Image")));
            this.btnConfirmarVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmarVenta.Location = new System.Drawing.Point(174, 24);
            this.btnConfirmarVenta.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirmarVenta.Name = "btnConfirmarVenta";
            this.btnConfirmarVenta.Size = new System.Drawing.Size(146, 69);
            this.btnConfirmarVenta.TabIndex = 1;
            this.btnConfirmarVenta.Text = "&Confirmar";
            this.btnConfirmarVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmarVenta.UseVisualStyleBackColor = true;
            this.btnConfirmarVenta.TabIndexChanged += new System.EventHandler(this.btnConfirmarVenta_TabIndexChanged);
            this.btnConfirmarVenta.Click += new System.EventHandler(this.btnConfirmarVenta_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(15, 24);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(146, 69);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.TabIndexChanged += new System.EventHandler(this.btnSalir_TabIndexChanged);
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtCantidad);
            this.groupBox6.Location = new System.Drawing.Point(18, 9);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(110, 90);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Cantidad";
            this.groupBox6.TabIndexChanged += new System.EventHandler(this.groupBox6_TabIndexChanged);
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
            this.txtCantidad.TabIndexChanged += new System.EventHandler(this.txtCantidad_TabIndexChanged);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnEliminarArticulo);
            this.groupBox7.Location = new System.Drawing.Point(788, 9);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(146, 90);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            // 
            // btnEliminarArticulo
            // 
            this.btnEliminarArticulo.Enabled = false;
            this.btnEliminarArticulo.Location = new System.Drawing.Point(18, 21);
            this.btnEliminarArticulo.Name = "btnEliminarArticulo";
            this.btnEliminarArticulo.Size = new System.Drawing.Size(112, 58);
            this.btnEliminarArticulo.TabIndex = 1;
            this.btnEliminarArticulo.Text = "Eliminar";
            this.btnEliminarArticulo.UseVisualStyleBackColor = true;
            this.btnEliminarArticulo.Click += new System.EventHandler(this.btnEliminarArticulo_Click);
            // 
            // frmNuevaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 605);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNuevaVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Venta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNuevaVenta_FormClosing);
            this.Load += new System.EventHandler(this.frmNuevaVenta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsVenta)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grdItemsVenta;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBuscarArticulo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalVenta;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnConfirmarVenta;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnEliminarArticulo;
    }
}