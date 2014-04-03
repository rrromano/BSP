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

namespace ADBISYS.Formularios.Ingresar
{
    public partial class frmAdministrarUsuario : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql = "";


        public frmAdministrarUsuario()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmAdministrarUsuario_Load(object sender, EventArgs e)
        {
            cargarInfoUser();
        }

        private void cargarInfoUser()
        {
            cadenaSql = "EXEC adp_info_usuario @user = 'admin'";
            ds = objConect.ejecutarQuerySelect(cadenaSql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtUsuario.Text = ds.Tables[0].Rows[0]["Username"].ToString();
                txtDescripcion.Text = ds.Tables[0].Rows[0]["Descripcion"].ToString();
            }
            else 
            {
                return;
            }

        }

        private void frmAdministrarUsuario_Activated(object sender, EventArgs e)
        {
            txtContraActual.Focus();
        }
    }
}
