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
using ADBISYS.Formularios.Rubros;


namespace ADBISYS.Formularios.Proveedores
{
    public partial class frmNuevoProveedor : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql, rubroAnterior,usuario = "";

        public frmNuevoProveedor()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressNumeros(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressNumeros(e);
        }

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            mostrarFormularioNuevoRubro();
        }

        private void mostrarFormularioNuevoRubro()
        {
            frmNuevoRubro nuevoRubro = new frmNuevoRubro();
            nuevoRubro.ShowDialog();
        }

        private void frmNuevoProveedor_Activated(object sender, EventArgs e)
        {
            cargarCodigoProveedor();
            cargarComboRubro();
        }

        private void cargarCodigoProveedor()
        {
            try
            {
                cadenaSql = "EXEC adp_maximo_proveedor";
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

        private void cargarComboRubro()
        {
            try
            {
                rubroAnterior = cboRubro.Text;
                cboRubro.Items.Clear();
                cadenaSql = "EXEC adp_info_rubros";
                ds = objConect.ejecutarQuerySelect(cadenaSql);

                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    cboRubro.Items.Add(dataRow[1]);
                }
                cboRubro.Text = rubroAnterior;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            cboRubro.Text = null;
            txtNombre.Text = "";
            txtContacto.Text = "";
            txtDireccion.Text = "";
            txtLocalidad.Text = "";
            txtProvincia.Text = "";
            txtTelefono.Text = "";
            txtCuit.Text = "";
            cboRubro.Focus();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(validoCampos()) return;
            altaDeProveedor();
        }

        private bool validoCampos()
        {
            if (cboRubro.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Rubro.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboRubro.Focus();
                return true;
            }

            if (txtNombre.Text == "")
            {
                MessageBox.Show("El campo Nombre es obligatorio.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
                return true;
            }
            return false;
        }

        private void altaDeProveedor()
        {
            try
            {
                usuario = Properties.Settings.Default.UsuarioLogueado.ToString();

                cadenaSql = "EXEC adp_nuevo_proveedor";
                cadenaSql = cadenaSql + " @Rubro = " + fg.fcSql(cboRubro.Text, "String");
                cadenaSql = cadenaSql + ",@Nombre = " + fg.fcSql(txtNombre.Text, "String");
                cadenaSql = cadenaSql + ",@Contacto = " + fg.fcSql(txtContacto.Text, "String");
                cadenaSql = cadenaSql + ",@Direccion = " + fg.fcSql(txtDireccion.Text, "String");
                cadenaSql = cadenaSql + ",@Localidad = " + fg.fcSql(txtLocalidad.Text, "String");
                cadenaSql = cadenaSql + ",@Provincia = " + fg.fcSql(txtProvincia.Text, "String");
                if (txtTelefono.Text != "")
                { cadenaSql = cadenaSql + ",@Telefono = " + txtTelefono.Text; }
                if (txtCuit.Text != "")
                { cadenaSql = cadenaSql + ",@Cuit = " + txtCuit.Text; }
                cadenaSql = cadenaSql + ",@Login = " + fg.fcSql(usuario, "String");

                objConect.ejecutarQuery(cadenaSql);
                this.Hide();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
