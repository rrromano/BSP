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
            this.GroupBoxBotonEliminar = new System.Windows.Forms.GroupBox();
            this.btnEliminarArticulo = new System.Windows.Forms.Button();
            this.groupBoxCantidadAlta = new System.Windows.Forms.GroupBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.GroupBoxBotonBusqueda = new System.Windows.Forms.GroupBox();
            this.btnBuscarArticulo = new System.Windows.Forms.Button();
            this.GroupBoxCodArticulo = new System.Windows.Forms.GroupBox();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.chkAgregarItem = new System.Windows.Forms.CheckBox();
            this.groupBoxDesc = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.groupBoxCant = new System.Windows.Forms.GroupBox();
            this.txtCantidadModif = new System.Windows.Forms.TextBox();
            this.groupBoxAceptar = new System.Windows.Forms.GroupBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLeyendaModifVenta = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsVenta)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.GroupBoxBotonEliminar.SuspendLayout();
            this.groupBoxCantidadAlta.SuspendLayout();
            this.GroupBoxBotonBusqueda.SuspendLayout();
            this.GroupBoxCodArticulo.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBoxDesc.SuspendLayout();
            this.groupBoxCant.SuspendLayout();
            this.groupBoxAceptar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdItemsVenta);
            this.groupBox3.Location = new System.Drawing.Point(12, 219);
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
            this.grdItemsVenta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdItemsVenta_CellClick);
            this.grdItemsVenta.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdItemsVenta_CellValueChanged);
            this.grdItemsVenta.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdItemsVenta_CurrentCellDirtyStateChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnConfirmarModificacionVenta);
            this.groupBox5.Controls.Add(this.btnSalir);
            this.groupBox5.Location = new System.Drawing.Point(12, 699);
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
            this.groupBox2.Location = new System.Drawing.Point(715, 699);
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
            // GroupBoxBotonEliminar
            // 
            this.GroupBoxBotonEliminar.Controls.Add(this.btnEliminarArticulo);
            this.GroupBoxBotonEliminar.Location = new System.Drawing.Point(782, 74);
            this.GroupBoxBotonEliminar.Name = "GroupBoxBotonEliminar";
            this.GroupBoxBotonEliminar.Size = new System.Drawing.Size(146, 90);
            this.GroupBoxBotonEliminar.TabIndex = 86;
            this.GroupBoxBotonEliminar.TabStop = false;
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
            // groupBoxCantidadAlta
            // 
            this.groupBoxCantidadAlta.Controls.Add(this.txtCantidad);
            this.groupBoxCantidadAlta.Location = new System.Drawing.Point(12, 74);
            this.groupBoxCantidadAlta.Name = "groupBoxCantidadAlta";
            this.groupBoxCantidadAlta.Size = new System.Drawing.Size(110, 90);
            this.groupBoxCantidadAlta.TabIndex = 85;
            this.groupBoxCantidadAlta.TabStop = false;
            this.groupBoxCantidadAlta.Text = "Cantidad";
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
            // GroupBoxBotonBusqueda
            // 
            this.GroupBoxBotonBusqueda.Controls.Add(this.btnBuscarArticulo);
            this.GroupBoxBotonBusqueda.Location = new System.Drawing.Point(669, 74);
            this.GroupBoxBotonBusqueda.Name = "GroupBoxBotonBusqueda";
            this.GroupBoxBotonBusqueda.Size = new System.Drawing.Size(107, 90);
            this.GroupBoxBotonBusqueda.TabIndex = 84;
            this.GroupBoxBotonBusqueda.TabStop = false;
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
            // GroupBoxCodArticulo
            // 
            this.GroupBoxCodArticulo.Controls.Add(this.txtCodigoArticulo);
            this.GroupBoxCodArticulo.Location = new System.Drawing.Point(128, 74);
            this.GroupBoxCodArticulo.Name = "GroupBoxCodArticulo";
            this.GroupBoxCodArticulo.Size = new System.Drawing.Size(535, 90);
            this.GroupBoxCodArticulo.TabIndex = 83;
            this.GroupBoxCodArticulo.TabStop = false;
            this.GroupBoxCodArticulo.Text = "Código de Artículo";
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoArticulo.Location = new System.Drawing.Point(21, 35);
            this.txtCodigoArticulo.MaxLength = 20;
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(493, 35);
            this.txtCodigoArticulo.TabIndex = 0;
            this.txtCodigoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoArticulo_KeyPress);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.chkAgregarItem);
            this.groupBox8.Location = new System.Drawing.Point(12, 163);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(340, 49);
            this.groupBox8.TabIndex = 87;
            this.groupBox8.TabStop = false;
            // 
            // chkAgregarItem
            // 
            this.chkAgregarItem.AutoSize = true;
            this.chkAgregarItem.Location = new System.Drawing.Point(12, 16);
            this.chkAgregarItem.Name = "chkAgregarItem";
            this.chkAgregarItem.Size = new System.Drawing.Size(322, 27);
            this.chkAgregarItem.TabIndex = 0;
            this.chkAgregarItem.Text = "Agregar nuevo item a la venta";
            this.chkAgregarItem.UseVisualStyleBackColor = true;
            this.chkAgregarItem.CheckedChanged += new System.EventHandler(this.chkAgregarItem_CheckedChanged);
            // 
            // groupBoxDesc
            // 
            this.groupBoxDesc.Controls.Add(this.txtDescripcion);
            this.groupBoxDesc.Location = new System.Drawing.Point(12, 599);
            this.groupBoxDesc.Name = "groupBoxDesc";
            this.groupBoxDesc.Size = new System.Drawing.Size(648, 97);
            this.groupBoxDesc.TabIndex = 88;
            this.groupBoxDesc.TabStop = false;
            this.groupBoxDesc.Text = "Descripción Item";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(15, 38);
            this.txtDescripcion.MaxLength = 3;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(615, 35);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.Text = "1";
            this.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxCant
            // 
            this.groupBoxCant.Controls.Add(this.txtCantidadModif);
            this.groupBoxCant.Location = new System.Drawing.Point(666, 599);
            this.groupBoxCant.Name = "groupBoxCant";
            this.groupBoxCant.Size = new System.Drawing.Size(110, 97);
            this.groupBoxCant.TabIndex = 89;
            this.groupBoxCant.TabStop = false;
            this.groupBoxCant.Text = "Cantidad";
            // 
            // txtCantidadModif
            // 
            this.txtCantidadModif.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadModif.Location = new System.Drawing.Point(27, 35);
            this.txtCantidadModif.MaxLength = 3;
            this.txtCantidadModif.Name = "txtCantidadModif";
            this.txtCantidadModif.Size = new System.Drawing.Size(55, 35);
            this.txtCantidadModif.TabIndex = 0;
            this.txtCantidadModif.Text = "1";
            this.txtCantidadModif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxAceptar
            // 
            this.groupBoxAceptar.Controls.Add(this.btnAceptar);
            this.groupBoxAceptar.Location = new System.Drawing.Point(782, 599);
            this.groupBoxAceptar.Name = "groupBoxAceptar";
            this.groupBoxAceptar.Size = new System.Drawing.Size(150, 97);
            this.groupBoxAceptar.TabIndex = 90;
            this.groupBoxAceptar.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(16, 28);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(112, 58);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLeyendaModifVenta);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(918, 61);
            this.groupBox1.TabIndex = 91;
            this.groupBox1.TabStop = false;
            // 
            // lblLeyendaModifVenta
            // 
            this.lblLeyendaModifVenta.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeyendaModifVenta.Location = new System.Drawing.Point(70, 23);
            this.lblLeyendaModifVenta.Name = "lblLeyendaModifVenta";
            this.lblLeyendaModifVenta.Size = new System.Drawing.Size(779, 25);
            this.lblLeyendaModifVenta.TabIndex = 0;
            this.lblLeyendaModifVenta.Text = "Modificación Venta ";
            this.lblLeyendaModifVenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmModificarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 819);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxAceptar);
            this.Controls.Add(this.groupBoxCant);
            this.Controls.Add(this.groupBoxDesc);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.GroupBoxBotonEliminar);
            this.Controls.Add(this.groupBoxCantidadAlta);
            this.Controls.Add(this.GroupBoxBotonBusqueda);
            this.Controls.Add(this.GroupBoxCodArticulo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmModificarVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Venta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmModificarVenta_FormClosing);
            this.Load += new System.EventHandler(this.frmModificarVenta_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsVenta)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.GroupBoxBotonEliminar.ResumeLayout(false);
            this.groupBoxCantidadAlta.ResumeLayout(false);
            this.groupBoxCantidadAlta.PerformLayout();
            this.GroupBoxBotonBusqueda.ResumeLayout(false);
            this.GroupBoxCodArticulo.ResumeLayout(false);
            this.GroupBoxCodArticulo.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBoxDesc.ResumeLayout(false);
            this.groupBoxDesc.PerformLayout();
            this.groupBoxCant.ResumeLayout(false);
            this.groupBoxCant.PerformLayout();
            this.groupBoxAceptar.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox GroupBoxBotonEliminar;
        private System.Windows.Forms.Button btnEliminarArticulo;
        private System.Windows.Forms.GroupBox groupBoxCantidadAlta;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.GroupBox GroupBoxBotonBusqueda;
        private System.Windows.Forms.Button btnBuscarArticulo;
        private System.Windows.Forms.GroupBox GroupBoxCodArticulo;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox chkAgregarItem;
        private System.Windows.Forms.GroupBox groupBoxDesc;
        private System.Windows.Forms.GroupBox groupBoxCant;
        private System.Windows.Forms.TextBox txtCantidadModif;
        private System.Windows.Forms.GroupBox groupBoxAceptar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLeyendaModifVenta;
    }
}