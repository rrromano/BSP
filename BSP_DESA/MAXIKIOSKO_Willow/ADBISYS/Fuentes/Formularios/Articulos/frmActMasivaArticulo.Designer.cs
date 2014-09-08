namespace ADBISYS.Formularios.Articulos
{
    partial class frmActMasivaArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActMasivaArticulo));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblPrecioPorcentaje = new System.Windows.Forms.Label();
            this.txtPrecioPorcentaje = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cboAumentarDisminuir = new System.Windows.Forms.ComboBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboRubro = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RBPrecio = new System.Windows.Forms.RadioButton();
            this.RBporcentaje = new System.Windows.Forms.RadioButton();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.btnActualizar);
            this.groupBox4.Controls.Add(this.btnCancelar);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Location = new System.Drawing.Point(17, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(501, 422);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblPrecioPorcentaje);
            this.groupBox3.Controls.Add(this.txtPrecioPorcentaje);
            this.groupBox3.Location = new System.Drawing.Point(16, 239);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(469, 85);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            // 
            // lblPrecioPorcentaje
            // 
            this.lblPrecioPorcentaje.AutoSize = true;
            this.lblPrecioPorcentaje.Location = new System.Drawing.Point(32, 38);
            this.lblPrecioPorcentaje.Name = "lblPrecioPorcentaje";
            this.lblPrecioPorcentaje.Size = new System.Drawing.Size(191, 23);
            this.lblPrecioPorcentaje.TabIndex = 40;
            this.lblPrecioPorcentaje.Text = "Precio / Porcentaje";
            // 
            // txtPrecioPorcentaje
            // 
            this.txtPrecioPorcentaje.Location = new System.Drawing.Point(249, 35);
            this.txtPrecioPorcentaje.Name = "txtPrecioPorcentaje";
            this.txtPrecioPorcentaje.Size = new System.Drawing.Size(195, 29);
            this.txtPrecioPorcentaje.TabIndex = 36;
            this.txtPrecioPorcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioPorcentaje_KeyPress);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cboAumentarDisminuir);
            this.groupBox6.Location = new System.Drawing.Point(252, 115);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(233, 125);
            this.groupBox6.TabIndex = 46;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Aumentar / Disminuir";
            // 
            // cboAumentarDisminuir
            // 
            this.cboAumentarDisminuir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAumentarDisminuir.FormattingEnabled = true;
            this.cboAumentarDisminuir.Location = new System.Drawing.Point(28, 53);
            this.cboAumentarDisminuir.Name = "cboAumentarDisminuir";
            this.cboAumentarDisminuir.Size = new System.Drawing.Size(177, 30);
            this.cboAumentarDisminuir.TabIndex = 45;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActualizar.Location = new System.Drawing.Point(260, 336);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(225, 69);
            this.btnActualizar.TabIndex = 19;
            this.btnActualizar.Text = "&Aceptar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(16, 336);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(225, 69);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboRubro);
            this.groupBox5.Location = new System.Drawing.Point(16, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(469, 95);
            this.groupBox5.TabIndex = 37;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Seleccione el Rubro";
            // 
            // cboRubro
            // 
            this.cboRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRubro.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRubro.FormattingEnabled = true;
            this.cboRubro.Location = new System.Drawing.Point(123, 40);
            this.cboRubro.Name = "cboRubro";
            this.cboRubro.Size = new System.Drawing.Size(223, 30);
            this.cboRubro.TabIndex = 38;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RBPrecio);
            this.groupBox2.Controls.Add(this.RBporcentaje);
            this.groupBox2.Location = new System.Drawing.Point(16, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 125);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actualización Por";
            // 
            // RBPrecio
            // 
            this.RBPrecio.AutoSize = true;
            this.RBPrecio.Location = new System.Drawing.Point(30, 42);
            this.RBPrecio.Name = "RBPrecio";
            this.RBPrecio.Size = new System.Drawing.Size(89, 27);
            this.RBPrecio.TabIndex = 45;
            this.RBPrecio.TabStop = true;
            this.RBPrecio.Text = "Precio";
            this.RBPrecio.UseVisualStyleBackColor = true;
            // 
            // RBporcentaje
            // 
            this.RBporcentaje.AutoSize = true;
            this.RBporcentaje.Location = new System.Drawing.Point(30, 75);
            this.RBporcentaje.Name = "RBporcentaje";
            this.RBporcentaje.Size = new System.Drawing.Size(131, 27);
            this.RBporcentaje.TabIndex = 44;
            this.RBporcentaje.TabStop = true;
            this.RBporcentaje.Text = "Porcentaje";
            this.RBporcentaje.UseVisualStyleBackColor = true;
            // 
            // frmActMasivaArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(535, 445);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmActMasivaArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualización Masiva de Artículos";
            this.Load += new System.EventHandler(this.frmActMasivaArticulo_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblPrecioPorcentaje;
        private System.Windows.Forms.TextBox txtPrecioPorcentaje;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cboAumentarDisminuir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cboRubro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RBPrecio;
        private System.Windows.Forms.RadioButton RBporcentaje;
    }
}