﻿namespace ADBISYS.Formularios.Ingresar
{
    partial class frmAdministrarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministrarUsuario));
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContraseniaActual = new System.Windows.Forms.Label();
            this.lblContraseniaNueva = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtContraRepe = new System.Windows.Forms.TextBox();
            this.lblContraRepe = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtContraNueva = new System.Windows.Forms.TextBox();
            this.txtContraActual = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(21, 23);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(64, 18);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblContraseniaActual
            // 
            this.lblContraseniaActual.AutoSize = true;
            this.lblContraseniaActual.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseniaActual.Location = new System.Drawing.Point(21, 70);
            this.lblContraseniaActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContraseniaActual.Name = "lblContraseniaActual";
            this.lblContraseniaActual.Size = new System.Drawing.Size(144, 18);
            this.lblContraseniaActual.TabIndex = 1;
            this.lblContraseniaActual.Text = "Contraseña Actual";
            // 
            // lblContraseniaNueva
            // 
            this.lblContraseniaNueva.AutoSize = true;
            this.lblContraseniaNueva.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseniaNueva.Location = new System.Drawing.Point(21, 117);
            this.lblContraseniaNueva.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContraseniaNueva.Name = "lblContraseniaNueva";
            this.lblContraseniaNueva.Size = new System.Drawing.Size(146, 18);
            this.lblContraseniaNueva.TabIndex = 2;
            this.lblContraseniaNueva.Text = "Contraseña Nueva";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(234, 24);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(92, 18);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Descripción";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtContraRepe);
            this.groupBox1.Controls.Add(this.lblContraRepe);
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.txtContraNueva);
            this.groupBox1.Controls.Add(this.txtContraActual);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.lblUsuario);
            this.groupBox1.Controls.Add(this.lblDescripcion);
            this.groupBox1.Controls.Add(this.lblContraseniaActual);
            this.groupBox1.Controls.Add(this.lblContraseniaNueva);
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(678, 264);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // txtContraRepe
            // 
            this.txtContraRepe.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraRepe.Location = new System.Drawing.Point(220, 161);
            this.txtContraRepe.MaxLength = 255;
            this.txtContraRepe.Name = "txtContraRepe";
            this.txtContraRepe.Size = new System.Drawing.Size(244, 25);
            this.txtContraRepe.TabIndex = 5;
            this.txtContraRepe.UseSystemPasswordChar = true;
            this.txtContraRepe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContraRepe_KeyPress);
            // 
            // lblContraRepe
            // 
            this.lblContraRepe.AutoSize = true;
            this.lblContraRepe.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraRepe.Location = new System.Drawing.Point(21, 164);
            this.lblContraRepe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContraRepe.Name = "lblContraRepe";
            this.lblContraRepe.Size = new System.Drawing.Size(151, 18);
            this.lblContraRepe.TabIndex = 7;
            this.lblContraRepe.Text = "Repetir Contraseña";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(264, 205);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(200, 47);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(25, 205);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(216, 47);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtContraNueva
            // 
            this.txtContraNueva.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraNueva.Location = new System.Drawing.Point(220, 114);
            this.txtContraNueva.MaxLength = 255;
            this.txtContraNueva.Name = "txtContraNueva";
            this.txtContraNueva.Size = new System.Drawing.Size(244, 25);
            this.txtContraNueva.TabIndex = 4;
            this.txtContraNueva.UseSystemPasswordChar = true;
            this.txtContraNueva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContraNueva_KeyPress);
            // 
            // txtContraActual
            // 
            this.txtContraActual.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraActual.Location = new System.Drawing.Point(220, 67);
            this.txtContraActual.MaxLength = 255;
            this.txtContraActual.Name = "txtContraActual";
            this.txtContraActual.Size = new System.Drawing.Size(244, 25);
            this.txtContraActual.TabIndex = 3;
            this.txtContraActual.UseSystemPasswordChar = true;
            this.txtContraActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContraActual_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(360, 21);
            this.txtDescripcion.MaxLength = 255;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(294, 25);
            this.txtDescripcion.TabIndex = 2;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(109, 21);
            this.txtUsuario.MaxLength = 255;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(112, 25);
            this.txtUsuario.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(511, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 142);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // frmAdministrarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 296);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdministrarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Usuario";
            this.Load += new System.EventHandler(this.frmAdministrarUsuario_Load);
            this.Activated += new System.EventHandler(this.frmAdministrarUsuario_Activated);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContraseniaActual;
        private System.Windows.Forms.Label lblContraseniaNueva;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtContraNueva;
        private System.Windows.Forms.TextBox txtContraActual;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtContraRepe;
        private System.Windows.Forms.Label lblContraRepe;
    }
}