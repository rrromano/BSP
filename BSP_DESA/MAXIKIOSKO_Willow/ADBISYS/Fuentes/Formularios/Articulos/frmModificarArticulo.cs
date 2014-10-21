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
using ADBISYS.Entidades;
using ADBISYS.Formularios.Rubros;

namespace ADBISYS.Formularios.Articulos
{
    public partial class frmModificarArticulo : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql, rubroAnterior, usuario = "";
        public string articulo_codigo, articulo_desccripcion, articulo_precioVenta, articulo_precioCompra, articulo_rubro = "";
        Dictionary<int, string> rubros = new Dictionary<int, string>();
        
        public frmModificarArticulo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmModificarArticulo_Load(object sender, EventArgs e)
        {
            cargarComboRubro();
            cargarDatosArticulo();
        }

        private void cargarDatosArticulo()
        {
            txtCodigo.Text = articulo_codigo;
            txtDescripcion.Text = articulo_desccripcion;
            txtPrecioVenta.Text = articulo_precioVenta;
            txtPrecioCompra.Text = articulo_precioCompra;
            cboRubro.Text = articulo_rubro;
            txtDescripcion.Focus();
        }

        private void cargarComboRubro()
        {
            try
            {
                rubroAnterior = cboRubro.Text;
                cboRubro.Items.Clear();
                rubros.Clear();

                Entidades.Proveedores entProveedores = new ADBISYS.Entidades.Proveedores();
                ds = entProveedores.obtenerInfoRubros();

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

        private void btnNuevoRubro_Click(object sender, EventArgs e)
        {
            mostrarFormularioNuevoRubro();
        }

        private void mostrarFormularioNuevoRubro()
        {
            frmNuevoRubro nuevoRubro = new frmNuevoRubro();
            nuevoRubro.ShowDialog();
            cargarComboRubro();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            txtPrecioVenta.Text = "";
            txtPrecioCompra.Text = "";
            cboRubro.Text = null;
            txtDescripcion.Focus();
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressNumerosDecimales(e, txtPrecioVenta);
            fg.keyPressNumericoDiezDosDecimales(e, txtPrecioVenta.Text.Length, txtPrecioVenta.Text);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = fg.keyPressMayusculas(e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validoCampos()) return;
            if (validoTextoEnCampos()) return;
            modificacionDeArticulo();
        }

        private void modificacionDeArticulo()
        {
            usuario = Properties.Settings.Default.UsuarioLogueado.ToString();

            cadenaSql = "EXEC adp_modificar_articulo";
            cadenaSql = cadenaSql + " @Articulo_ID_Articulo = " + fg.fcSql(txtCodigo.Text.Trim(), "String");
            cadenaSql = cadenaSql + ",@Articulo_Descripcion = " + fg.fcSql(txtDescripcion.Text.Trim(), "String");
            cadenaSql = cadenaSql + ",@Articulo_Precio_Venta = " + fg.fcSql(txtPrecioVenta.Text.Replace(",", "."), "Double");
            cadenaSql = cadenaSql + ",@Articulo_Precio_Compra = " + fg.fcSql(txtPrecioCompra.Text.Replace(",", "."), "Double");
            cadenaSql = cadenaSql + ",@Articulo_Rubro = " + obtenerIdRubro().ToString();
            cadenaSql = cadenaSql + ",@Articulo_Login = " + fg.fcSql(usuario, "String");

            objConect.ejecutarQuery(cadenaSql);
            this.Hide();
        }

        private object obtenerIdRubro()
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
                return -1;
            }
        }

        private bool validoTextoEnCampos()
        {
            if (txtDescripcion.Text != "")
            {
                if (txtDescripcion.Text.Trim() == "")
                {
                    MessageBox.Show("La Descripción ingresada es incorrecta.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescripcion.Focus();
                    return true;
                }
            }

            if (fg.esUnNumeroDecimal(txtPrecioVenta.Text) == false)
            {
                MessageBox.Show("El Precio Venta ingresado es inválido.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrecioVenta.Focus();
                return true;
            }
            if (double.Parse(txtPrecioVenta.Text.ToString()) == 0)
            {
                MessageBox.Show("El Precio Venta ingresado es inválido.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrecioVenta.Focus();
                return true;
            }

            if (fg.esUnNumeroDecimal(txtPrecioCompra.Text) == false)
            {
                MessageBox.Show("El Precio Compra ingresado es inválido.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrecioCompra.Focus();
                return true;
            }
            if (double.Parse(txtPrecioCompra.Text.ToString()) == 0)
            {
                MessageBox.Show("El Precio Compra ingresado es inválido.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrecioCompra.Focus();
                return true;
            }

            return false;
        }

        private bool validoCampos()
        {
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("El campo Descripción es obligatorio.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcion.Focus();
                return true;
            }

            if (txtPrecioVenta.Text == "")
            {
                MessageBox.Show("El campo Precio Venta es obligatorio.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrecioVenta.Focus();
                return true;
            }

            if (txtPrecioCompra.Text == "")
            {
                MessageBox.Show("El campo Precio Compra es obligatorio.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrecioCompra.Focus();
                return true;
            }

            if (cboRubro.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Rubro.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboRubro.Focus();
                return true;
            }

            return false;
        }
    }
}
