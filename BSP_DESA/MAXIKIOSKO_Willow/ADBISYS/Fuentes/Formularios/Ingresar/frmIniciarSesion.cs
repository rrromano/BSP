using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.FuncionesGenerales;
using ADBISYS.Conexion;
using System.Windows.Forms.Design;

namespace ADBISYS.Formularios.Ingresar
{
    public partial class frmIniciarSesion : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql, hPassword, descripcionUsuario = "";

        public frmIniciarSesion()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressSinEspacios(e);
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressSinEspacios(e);
        }

        private bool validoCampos()
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("El campo Usuario es obligatorio.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Focus();
                return false;
            }

            if (txtContrasenia.Text == "")
            {
                MessageBox.Show("El campo Contraseña es obligatorio.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContrasenia.Focus();
                return false;
            }
            return true;
        }
        
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (validoCampos() && ValidoUsuario())
            {
                Properties.Settings.Default.UsuarioLogueado = descripcionUsuario; //Se asigna a la propieda el usuario Logueado. Esta "Variable" vive en toda la ejecución del programa
                this.Hide();
            }
            
        }

        private bool ValidoUsuario()
        {
            hPassword = fg.ComputeHash(txtContrasenia.Text);
            cadenaSql = "EXEC adp_buscar_usuario";
            cadenaSql = cadenaSql + " @user = " + fg.fcSql(txtUsuario.Text, "String");
            cadenaSql = cadenaSql + ",@Pass = " + fg.fcSql(hPassword, "String");

            ds = objConect.ejecutarQuerySelect(cadenaSql);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Usuario o Contraseña inválidos, intente nuevamente.", "Error al iniciar sesión.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Focus();
                return false;
            }

            descripcionUsuario = ds.Tables[0].Rows[0]["Descripcion"].ToString();
            return true;
        }
    }
}
