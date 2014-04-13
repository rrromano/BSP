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
    public partial class frmModificarProveedor : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql, rubroAnterior, usuario = "";
        public string proveedor_codigo, proveedor_rubro,
               proveedor_nombre, proveedor_contacto,
               proveedor_direccion, proveedor_localidad,
               proveedor_provincia, proveedor_telefono,
               proveedor_cuit = "";

        Dictionary<int, string> rubros = new Dictionary<int, string>();

        public frmModificarProveedor()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            mostrarFormularioNuevoRubro();
        }

        private void mostrarFormularioNuevoRubro()
        {
            frmNuevoRubro nuevoRubro = new frmNuevoRubro();
            nuevoRubro.ShowDialog();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressNumeros(e);
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressNumeros(e);
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validoCampos()) return;
            modificarProveedor();
        }

        private void modificarProveedor()
        {
            try
            {
                usuario = Properties.Settings.Default.UsuarioLogueado.ToString();

                cadenaSql = "EXEC adp_modificar_proveedor";
                cadenaSql = cadenaSql + " @Proveedor_ID_Proveedor = " + fg.fcSql(txtCodigo.Text,"String");
                cadenaSql = cadenaSql + ",@Proveedor_IdRubro = " + obtenerIdRubro().ToString();
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

        private void frmModificarProveedor_Activated(object sender, EventArgs e)
        {
            cargarComboRubro();
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

        private void frmModificarProveedor_Load(object sender, EventArgs e)
        {
            cargarComboRubro();
            cargarDatosProveedor();
        }

        private void cargarDatosProveedor()
        {
            txtCodigo.Text = proveedor_codigo;
            cboRubro.Text = proveedor_rubro;
            txtNombre.Text = proveedor_nombre;
            txtContacto.Text = proveedor_contacto;
            txtDireccion.Text = proveedor_direccion;
            txtLocalidad.Text = proveedor_localidad;
            txtProvincia.Text = proveedor_provincia;
            txtTelefono.Text = proveedor_telefono;
            txtCuit.Text = proveedor_cuit;
        }
    }
}
