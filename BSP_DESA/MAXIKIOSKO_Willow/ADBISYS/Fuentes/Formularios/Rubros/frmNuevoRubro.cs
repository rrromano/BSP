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

namespace ADBISYS.Formularios.Rubros
{
    public partial class frmNuevoRubro : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql,usuario = "";

        public frmNuevoRubro()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressLetras(e);
            e.KeyChar = fg.keyPressMayusculas(e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!(validoCampos())) return;
            if (!(verificarRubroExistente())) return;
            altaDeRubro();
        }

        private bool validoCampos()
        {
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("El campo Descripción es obligatorio.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcion.Focus();
                return false;
            }
            return true;
        }

        private void altaDeRubro()
        {
            try
            {
                usuario = Properties.Settings.Default.UsuarioLogueado.ToString();

                cadenaSql = "EXEC adp_nuevo_rubro";
                cadenaSql = cadenaSql + " @Rubro_Descripcion = " + fg.fcSql(txtDescripcion.Text, "String");
                cadenaSql = cadenaSql + ",@Rubro_Login = " + fg.fcSql(usuario, "String");

                objConect.ejecutarQuery(cadenaSql);
                this.Hide();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmNuevoRubro_Activated(object sender, EventArgs e)
        {
            cargarCodigoRubro();
        }

        private void cargarCodigoRubro()
        {
            try
            {
                cadenaSql = "EXEC adp_maximo_rubro";
                ds = objConect.ejecutarQuerySelect(cadenaSql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCodigo.Text = ds.Tables[0].Rows[0]["maximo"].ToString();
                }
                else
                {
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool verificarRubroExistente()
        {
            try
            {
                cadenaSql = "EXEC adp_verifico_rubro_existente @Rubro_Descripcion = " + fg.fcSql(txtDescripcion.Text, "String");
                ds = objConect.ejecutarQuerySelect(cadenaSql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (int.Parse(ds.Tables[0].Rows[0]["RESULTADO"].ToString()) == 1)
                    {
                        MessageBox.Show("El rubro " + txtDescripcion.Text + " ya existe.", "Alta de Rubro.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDescripcion.Focus();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
