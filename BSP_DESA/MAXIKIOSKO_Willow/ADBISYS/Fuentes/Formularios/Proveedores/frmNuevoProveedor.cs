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
        Dictionary<int, string> rubros = new Dictionary<int, string>();

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
                rubros.Clear();

                cadenaSql = "EXEC adp_info_rubros";
                ds = objConect.ejecutarQuerySelect(cadenaSql);

                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    cboRubro.Items.Add(dataRow["DESCRIPCION"]);
                    rubros.Add(int.Parse(dataRow["ID_RUBRO"].ToString()), dataRow["DESCRIPCION"].ToString());
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
                cadenaSql = cadenaSql + " @Proveedor_IdRubro = " + obtenerIdRubro().ToString();
                cadenaSql = cadenaSql + ",@Proveedor_Nombre = " + fg.fcSql(txtNombre.Text, "String");
                if (txtContacto.Text != "")
                { cadenaSql = cadenaSql + ",@Proveedor_Contacto = " + fg.fcSql(txtContacto.Text, "String"); }
                if (txtDireccion.Text != "")
                { cadenaSql = cadenaSql + ",@Proveedor_Direccion = " + fg.fcSql(txtDireccion.Text, "String"); }
                if (txtLocalidad.Text != "")
                { cadenaSql = cadenaSql + ",@Proveedor_Localidad = " + fg.fcSql(txtLocalidad.Text, "String"); }
                if (txtProvincia.Text != "")
                { cadenaSql = cadenaSql + ",@Proveedor_Provincia = " + fg.fcSql(txtProvincia.Text, "String"); }
                if (txtTelefono.Text != "")
                { cadenaSql = cadenaSql + ",@Proveedor_Telefono = " + txtTelefono.Text; }
                if (txtCuit.Text != "")
                { cadenaSql = cadenaSql + ",@Proveedor_Cuit = " + txtCuit.Text; }
                if (usuario != "")
                { cadenaSql = cadenaSql + ",@Proveedor_Login = " + fg.fcSql(usuario, "String"); }

                objConect.ejecutarQuery(cadenaSql);
                this.Hide();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private int obtenerIdRubro()
        {
            try
            {
                foreach (KeyValuePair<int, string> rubro in rubros)
                {
                    if (cboRubro.Text == rubro.Value)
                    {
                        return (rubro.Key);
                    }
                }
                return 0;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 9;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = fg.keyPressMayusculas(e);
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = fg.keyPressMayusculas(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = fg.keyPressMayusculas(e);
        }

        private void txtLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = fg.keyPressMayusculas(e);
        }

        private void txtProvincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = fg.keyPressMayusculas(e);
        }
    }
}
