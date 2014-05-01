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
using ADBISYS.Formularios.Proveedores;

namespace ADBISYS.Formularios.Compras
{
    public partial class frmModificarCompra : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql, proveedorAnterior, usuario = "";
        Dictionary<int, string> proveedores = new Dictionary<int, string>();
        public string compra_codigo, compra_proveedor, compra_importe = "";

        public frmModificarCompra()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmModificarCompra_Load(object sender, EventArgs e)
        {
            cargarComboProveedores();
            cargarDatosCompra();
        }

        private void cargarDatosCompra()
        {
            txtCodigo.Text = compra_codigo;
            cboProveedor.Text = compra_proveedor;
            txtImporte.Text = compra_importe;
        }

        private void cargarComboProveedores()
        {
            try
            {
                proveedorAnterior = cboProveedor.Text;
                cboProveedor.Items.Clear();
                proveedores.Clear();

                Entidades.Compras entCompras = new ADBISYS.Entidades.Compras();
                ds = entCompras.obtenerInfoProveedores();

                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    cboProveedor.Items.Add(dataRow["NOMBRE"]);
                    proveedores.Add(int.Parse(dataRow["ID_PROVEEDOR"].ToString()), dataRow["NOMBRE"].ToString());
                }
                cboProveedor.Text = proveedorAnterior;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cargarCodigoCompra()
        {
            try
            {
                Entidades.Compras entCompras = new ADBISYS.Entidades.Compras();
                ds = entCompras.obtenerMaximaCompra();

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

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            mostrarFormularioNuevoProveedor();
        }

        private void mostrarFormularioNuevoProveedor()
        {
            frmNuevoProveedor nuevoProveedor = new frmNuevoProveedor();
            nuevoProveedor.ShowDialog();
            cargarComboProveedores();
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressNumerosDecimales(e, txtImporte);
            fg.keyPressNumericoDiezDosDecimales(e, txtImporte.Text.Length, txtImporte.Text);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!(validoCampos())) return;
            if (!validoImporte()) return;
            modificarCompra();
        }

        private void modificarCompra()
        {
            try
            {
                usuario = Properties.Settings.Default.UsuarioLogueado.ToString();

                cadenaSql = "EXEC adp_modificar_compra";
                cadenaSql = cadenaSql + " @Compra_IdCompra = " + fg.fcSql(txtCodigo.Text, "String");
                cadenaSql = cadenaSql + ",@Compra_IdProveedor = " + obtenerIdProveedor().ToString();
                cadenaSql = cadenaSql + ",@Compra_Importe = " + fg.fcSql(txtImporte.Text, "Double");
                cadenaSql = cadenaSql + ",@Compra_Fecha_Compra = " + fg.fcSql(fg.appFechaSistema().ToString(), "Datetime");
                if (usuario != "")
                { cadenaSql = cadenaSql + ",@Compra_Login = " + fg.fcSql(usuario, "String"); }

                objConect.ejecutarQuery(cadenaSql);
                this.Hide();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private object obtenerIdProveedor()
        {
            try
            {
                foreach (KeyValuePair<int, string> proveedor in proveedores)
                {
                    if (cboProveedor.Text == proveedor.Value)
                    {
                        return (proveedor.Key);
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

        private bool validoImporte()
        {
            if (fg.esUnNumeroDecimal(txtImporte.Text) == false)
            {
                MessageBox.Show("El importe ingresado es inválido.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtImporte.Focus();
                return false;
            }
            return true;
        }

        private bool validoCampos()
        {
            if (cboProveedor.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Proveedor.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboProveedor.Focus();
                return false;
            }

            if (txtImporte.Text == "")
            {
                MessageBox.Show("El campo Importe es obligatorio.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtImporte.Focus();
                return false;
            }
            return true;
        }
    }
}
