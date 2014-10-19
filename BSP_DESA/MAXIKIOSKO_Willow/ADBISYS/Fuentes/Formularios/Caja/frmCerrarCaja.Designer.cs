namespace ADBISYS.Formularios.Caja
{
    partial class frmCerrarCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCerrarCaja));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpGanancia = new System.Windows.Forms.GroupBox();
            this.lblGanancia = new System.Windows.Forms.Label();
            this.grpCierreParcial = new System.Windows.Forms.GroupBox();
            this.lblTotalParcial = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCerrarCaja = new System.Windows.Forms.Button();
            this.grdMovsCaja = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.grpGanancia.SuspendLayout();
            this.grpCierreParcial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMovsCaja)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grpGanancia);
            this.groupBox2.Controls.Add(this.grpCierreParcial);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnCerrarCaja);
            this.groupBox2.Controls.Add(this.grdMovsCaja);
            this.groupBox2.Location = new System.Drawing.Point(19, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 568);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // grpGanancia
            // 
            this.grpGanancia.Controls.Add(this.lblGanancia);
            this.grpGanancia.Location = new System.Drawing.Point(253, 358);
            this.grpGanancia.Name = "grpGanancia";
            this.grpGanancia.Size = new System.Drawing.Size(230, 100);
            this.grpGanancia.TabIndex = 20;
            this.grpGanancia.TabStop = false;
            this.grpGanancia.Text = "Ganancia";
            this.grpGanancia.Visible = false;
            // 
            // lblGanancia
            // 
            this.lblGanancia.AutoSize = true;
            this.lblGanancia.Font = new System.Drawing.Font("Verdana", 18F);
            this.lblGanancia.Location = new System.Drawing.Point(57, 39);
            this.lblGanancia.Name = "lblGanancia";
            this.lblGanancia.Size = new System.Drawing.Size(113, 36);
            this.lblGanancia.TabIndex = 4;
            this.lblGanancia.Text = "TOTAL";
            // 
            // grpCierreParcial
            // 
            this.grpCierreParcial.Controls.Add(this.lblTotalParcial);
            this.grpCierreParcial.Location = new System.Drawing.Point(22, 358);
            this.grpCierreParcial.Name = "grpCierreParcial";
            this.grpCierreParcial.Size = new System.Drawing.Size(225, 100);
            this.grpCierreParcial.TabIndex = 19;
            this.grpCierreParcial.TabStop = false;
            this.grpCierreParcial.Text = "Cierre Parcial";
            // 
            // lblTotalParcial
            // 
            this.lblTotalParcial.AutoSize = true;
            this.lblTotalParcial.Font = new System.Drawing.Font("Verdana", 18F);
            this.lblTotalParcial.Location = new System.Drawing.Point(57, 39);
            this.lblTotalParcial.Name = "lblTotalParcial";
            this.lblTotalParcial.Size = new System.Drawing.Size(113, 36);
            this.lblTotalParcial.TabIndex = 4;
            this.lblTotalParcial.Text = "TOTAL";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(22, 475);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(225, 69);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarCaja.Image")));
            this.btnCerrarCaja.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCerrarCaja.Location = new System.Drawing.Point(253, 475);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(230, 69);
            this.btnCerrarCaja.TabIndex = 15;
            this.btnCerrarCaja.Text = "C&errar Caja";
            this.btnCerrarCaja.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCerrarCaja.UseVisualStyleBackColor = true;
            this.btnCerrarCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);
            // 
            // grdMovsCaja
            // 
            this.grdMovsCaja.BackgroundColor = System.Drawing.Color.White;
            this.grdMovsCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMovsCaja.Location = new System.Drawing.Point(22, 34);
            this.grdMovsCaja.Name = "grdMovsCaja";
            this.grdMovsCaja.RowTemplate.Height = 24;
            this.grdMovsCaja.Size = new System.Drawing.Size(461, 318);
            this.grdMovsCaja.TabIndex = 14;
            // 
            // frmCerrarCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 593);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCerrarCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cierre de Caja";
            this.Activated += new System.EventHandler(this.frmCerrarCaja_Activated);
            this.groupBox2.ResumeLayout(false);
            this.grpGanancia.ResumeLayout(false);
            this.grpGanancia.PerformLayout();
            this.grpCierreParcial.ResumeLayout(false);
            this.grpCierreParcial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMovsCaja)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCerrarCaja;
        private System.Windows.Forms.DataGridView grdMovsCaja;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpCierreParcial;
        private System.Windows.Forms.Label lblTotalParcial;
        private System.Windows.Forms.GroupBox grpGanancia;
        private System.Windows.Forms.Label lblGanancia;



    }
}