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
    public partial class frmNuevoArticulo : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql, rubroAnterior, usuario = "";
        Dictionary<int, string> rubros = new Dictionary<int, string>();

        public frmNuevoArticulo()
        {
            InitializeComponent();
        }

        private void frmNuevoArticulo_Load(object sender, EventArgs e)
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

                Entidades.Articulo entArticulos = new ADBISYS.Entidades.Articulo();
                ds = entArticulos.obtenerInfoRubros();

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
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtPrecioVenta.Text = "";
            cboRubro.Text = null;
            txtCodigo.Focus();
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

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressNumerosDecimales(e, txtPrecioVenta);
            fg.keyPressNumericoDiezDosDecimales(e, txtPrecioVenta.Text.Length, txtPrecioVenta.Text);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressNumeros(e);
            if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    txtDescripcion.Focus();
                }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = fg.keyPressMayusculas(e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validoCampos()) return;
            if (validoTextoEnCampos()) return;
            if (validoExistenciaArticulo()) return;
            altaDeArticulo();
        }

        private void altaDeArticulo()
        {
            usuario = Properties.Settings.Default.UsuarioLogueado.ToString();

            cadenaSql = "EXEC adp_nuevo_articulo";
            cadenaSql = cadenaSql + " @Articulo_ID_Articulo = " + fg.fcSql(txtCodigo.Text.Trim(), "String");
            cadenaSql = cadenaSql + ",@Articulo_Descripcion = " + fg.fcSql(txtDescripcion.Text.Trim(), "String");
            cadenaSql = cadenaSql + ",@Articulo_Precio_Venta = " + fg.fcSql(txtPrecioVenta.Text.Replace(",","."), "Double");
            cadenaSql = cadenaSql + ",@Articulo_Rubro = " + obtenerIdRubro().ToString();
            cadenaSql = cadenaSql + ",@Articulo_Login = " + fg.fcSql(usuario, "String");

            objConect.ejecutarQuery(cadenaSql);

            if (chkCargaMasiva.Checked == true)
            {
                MessageBox.Show("Se dió de Alta correctamente el Artículo: " + txtCodigo.Text + " - " + txtDescripcion.Text + ".", "Alta de Artículo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarCampos();
                return;
            }
            else
            {
                this.Hide();
            }
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

        

        private bool validoExistenciaArticulo()
        {
            Entidades.Articulo entArticulos = new ADBISYS.Entidades.Articulo();
            ds = entArticulos.validarExistenciaArticulo(txtCodigo.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Ya existe un Artículo con Código: " + txtCodigo.Text + ".", "Alta de Artículo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Focus();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool validoTextoEnCampos()
        {
            if (txtCodigo.Text != "")
            {
                if (txtCodigo.Text.Trim() == "")
                {
                    MessageBox.Show("El código ingresado es incorrecto.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodigo.Focus();
                    return true;
                }
            }

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

            return false;
        }

        private bool validoCampos()
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("El campo Código es obligatorio.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Focus();
                return true;
            }

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
