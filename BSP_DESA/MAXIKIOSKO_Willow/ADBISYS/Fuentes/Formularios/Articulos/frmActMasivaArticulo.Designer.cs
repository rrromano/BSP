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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RBporcentaje = new System.Windows.Forms.RadioButton();
            this.RBPrecio = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnNuevoRol = new System.Windows.Forms.Button();
            this.cboRubro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPrecioPorcentaje = new System.Windows.Forms.TextBox();
            this.cboAumentarDisminuir = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPrecioPorcentaje = new System.Windows.Forms.Label();
            this.lblInformacion = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblInformacion);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(19, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 420);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(19, 464);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(225, 69);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActualizar.Location = new System.Drawing.Point(248, 464);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(230, 69);
            this.btnActualizar.TabIndex = 19;
            this.btnActualizar.Text = "&Aceptar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cajaToolStripMenuItem,
            this.salidaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(496, 31);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cajaToolStripMenuItem
            // 
            this.cajaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articulosToolStripMenuItem,
            this.salirToolStripMenuItem1});
            this.cajaToolStripMenuItem.Name = "cajaToolStripMenuItem";
            this.cajaToolStripMenuItem.Size = new System.Drawing.Size(77, 27);
            this.cajaToolStripMenuItem.Text = "Ir a...";
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(164, 28);
            this.articulosToolStripMenuItem.Text = "Artículos";
            this.articulosToolStripMenuItem.Click += new System.EventHandler(this.articulosToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem1
            // 
            this.salirToolStripMenuItem1.Name = "salirToolStripMenuItem1";
            this.salirToolStripMenuItem1.Size = new System.Drawing.Size(164, 28);
            this.salirToolStripMenuItem1.Text = "Salir";
            this.salirToolStripMenuItem1.Click += new System.EventHandler(this.salirToolStripMenuItem1_Click);
            // 
            // salidaToolStripMenuItem
            // 
            this.salidaToolStripMenuItem.Name = "salidaToolStripMenuItem";
            this.salidaToolStripMenuItem.Size = new System.Drawing.Size(81, 27);
            this.salidaToolStripMenuItem.Text = "Salida";
            this.salidaToolStripMenuItem.Click += new System.EventHandler(this.salidaToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RBPrecio);
            this.groupBox2.Controls.Add(this.RBporcentaje);
            this.groupBox2.Location = new System.Drawing.Point(32, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 89);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actualizar por";
            // 
            // RBporcentaje
            // 
            this.RBporcentaje.AutoSize = true;
            this.RBporcentaje.Location = new System.Drawing.Point(35, 40);
            this.RBporcentaje.Name = "RBporcentaje";
            this.RBporcentaje.Size = new System.Drawing.Size(169, 27);
            this.RBporcentaje.TabIndex = 26;
            this.RBporcentaje.TabStop = true;
            this.RBporcentaje.Text = "Por Porcentaje";
            this.RBporcentaje.UseVisualStyleBackColor = true;
            this.RBporcentaje.CheckedChanged += new System.EventHandler(this.RBporcentaje_CheckedChanged);
            // 
            // RBPrecio
            // 
            this.RBPrecio.AutoSize = true;
            this.RBPrecio.Location = new System.Drawing.Point(235, 40);
            this.RBPrecio.Name = "RBPrecio";
            this.RBPrecio.Size = new System.Drawing.Size(127, 27);
            this.RBPrecio.TabIndex = 27;
            this.RBPrecio.TabStop = true;
            this.RBPrecio.Text = "Por Precio";
            this.RBPrecio.UseVisualStyleBackColor = true;
            this.RBPrecio.CheckedChanged += new System.EventHandler(this.RBPrecio_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnNuevoRol);
            this.groupBox4.Controls.Add(this.cboRubro);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(30, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(398, 89);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Seleccione Rubro";
            // 
            // btnNuevoRol
            // 
            this.btnNuevoRol.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoRol.Image")));
            this.btnNuevoRol.Location = new System.Drawing.Point(329, 37);
            this.btnNuevoRol.Name = "btnNuevoRol";
            this.btnNuevoRol.Size = new System.Drawing.Size(45, 30);
            this.btnNuevoRol.TabIndex = 36;
            this.btnNuevoRol.UseVisualStyleBackColor = true;
            // 
            // cboRubro
            // 
            this.cboRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRubro.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRubro.FormattingEnabled = true;
            this.cboRubro.Location = new System.Drawing.Point(92, 37);
            this.cboRubro.Name = "cboRubro";
            this.cboRubro.Size = new System.Drawing.Size(223, 30);
            this.cboRubro.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 23);
            this.label2.TabIndex = 34;
            this.label2.Text = "Rubro";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblPrecioPorcentaje);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cboAumentarDisminuir);
            this.groupBox3.Controls.Add(this.txtPrecioPorcentaje);
            this.groupBox3.Location = new System.Drawing.Point(31, 277);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(397, 116);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            // 
            // txtPrecioPorcentaje
            // 
            this.txtPrecioPorcentaje.Location = new System.Drawing.Point(252, 69);
            this.txtPrecioPorcentaje.Name = "txtPrecioPorcentaje";
            this.txtPrecioPorcentaje.Size = new System.Drawing.Size(119, 29);
            this.txtPrecioPorcentaje.TabIndex = 36;
            // 
            // cboAumentarDisminuir
            // 
            this.cboAumentarDisminuir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAumentarDisminuir.FormattingEnabled = true;
            this.cboAumentarDisminuir.Location = new System.Drawing.Point(252, 33);
            this.cboAumentarDisminuir.Name = "cboAumentarDisminuir";
            this.cboAumentarDisminuir.Size = new System.Drawing.Size(119, 30);
            this.cboAumentarDisminuir.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 23);
            this.label1.TabIndex = 39;
            this.label1.Text = "Aumentar / Disminuir";
            // 
            // lblPrecioPorcentaje
            // 
            this.lblPrecioPorcentaje.AutoSize = true;
            this.lblPrecioPorcentaje.Location = new System.Drawing.Point(24, 72);
            this.lblPrecioPorcentaje.Name = "lblPrecioPorcentaje";
            this.lblPrecioPorcentaje.Size = new System.Drawing.Size(191, 23);
            this.lblPrecioPorcentaje.TabIndex = 40;
            this.lblPrecioPorcentaje.Text = "Precio / Porcentaje";
            // 
            // lblInformacion
            // 
            this.lblInformacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInformacion.ForeColor = System.Drawing.Color.Red;
            this.lblInformacion.Location = new System.Drawing.Point(32, 229);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(395, 45);
            this.lblInformacion.TabIndex = 38;
            this.lblInformacion.Text = "lblInformacion";
            this.lblInformacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmActMasivaArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 557);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmActMasivaArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualización Masiva de Artículos";
            this.Load += new System.EventHandler(this.frmActMasivaArticulo_Load);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salidaToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RBPrecio;
        private System.Windows.Forms.RadioButton RBporcentaje;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnNuevoRol;
        private System.Windows.Forms.ComboBox cboRubro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPrecioPorcentaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAumentarDisminuir;
        private System.Windows.Forms.Label lblPrecioPorcentaje;
        private System.Windows.Forms.Label lblInformacion;
    }
}