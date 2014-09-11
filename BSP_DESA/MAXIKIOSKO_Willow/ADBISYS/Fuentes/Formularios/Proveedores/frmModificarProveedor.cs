﻿using System;
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
using ADBISYS.Entidades;

namespace ADBISYS.Formularios.Proveedores
{
    public partial class frmModificarProveedor : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql, rubroAnterior, usuario = "";
        public string   proveedor_codigo,    proveedor_rubro,proveedor_nombre, proveedor_contacto,
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
            if (validoTextoEnCampos()) return;
            if (validoExistenciaProveedor()) return;
            modificarProveedor();
        }

        private bool validoTextoEnCampos()
        {
            if (txtNombre.Text != "")
            {
                if (txtNombre.Text.Trim() == "")
                {
                    MessageBox.Show("El nombre ingresado es incorrecto.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombre.Focus();
                    return true;
                }
            }

            if (txtContacto.Text != "")
            {
                if (txtContacto.Text.Trim() == "")
                {
                    MessageBox.Show("El contacto ingresado es incorrecto.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtContacto.Focus();
                    return true;
                }
            }

            if (txtDireccion.Text != "")
            {
                if (txtDireccion.Text.Trim() == "")
                {
                    MessageBox.Show("La dirección ingresada es incorrecta.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDireccion.Focus();
                    return true;
                }
            }

            if (txtLocalidad.Text != "")
            {
                if (txtLocalidad.Text.Trim() == "")
                {
                    MessageBox.Show("La localidad ingresada es incorrecta.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLocalidad.Focus();
                    return true;
                }
            }

            if (txtProvincia.Text != "")
            {
                if (txtProvincia.Text.Trim() == "")
                {
                    MessageBox.Show("La provincia ingresada es incorrecta.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProvincia.Focus();
                    return true;
                }
            }
            return false;
        }

        private bool validoExistenciaProveedor()
        {
            try
            {
                cadenaSql = "EXEC adp_verificoExistencia_proveedor";
                cadenaSql = cadenaSql + " @Id_Rubro = " + obtenerIdRubro().ToString();
                cadenaSql = cadenaSql + ",@Nombre = " + fg.fcSql(txtNombre.Text, "String");
                cadenaSql = cadenaSql + ",@Id_Proveedor = " + fg.fcSql(txtCodigo.Text, "String");

                ds = objConect.ejecutarQuerySelect(cadenaSql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Ya existe un proveedor con Nombre: " + txtNombre.Text + " y Rubro: " + cboRubro.Text + ".", "Alta de Proveedor.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboRubro.Focus();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private void modificarProveedor()
        {
            try
            {
                usuario = Properties.Settings.Default.UsuarioLogueado.ToString();

                cadenaSql = "EXEC adp_modificar_proveedor";
                cadenaSql = cadenaSql + " @Proveedor_ID_Proveedor = " + fg.fcSql(txtCodigo.Text,"String");
                cadenaSql = cadenaSql + ",@Proveedor_IdRubro = " + obtenerIdRubro().ToString();
                cadenaSql = cadenaSql + ",@Proveedor_Nombre = " + fg.fcSql(txtNombre.Text.Trim(), "String");
                if (txtContacto.Text != "")
                { cadenaSql = cadenaSql + ",@Proveedor_Contacto = " + fg.fcSql(txtContacto.Text.Trim(), "String"); }
                if (txtDireccion.Text != "")
                { cadenaSql = cadenaSql + ",@Proveedor_Direccion = " + fg.fcSql(txtDireccion.Text.Trim(), "String"); }
                if (txtLocalidad.Text != "")
                { cadenaSql = cadenaSql + ",@Proveedor_Localidad = " + fg.fcSql(txtLocalidad.Text.Trim(), "String"); }
                if (txtProvincia.Text != "")
                { cadenaSql = cadenaSql + ",@Proveedor_Provincia = " + fg.fcSql(txtProvincia.Text.Trim(), "String"); }
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
