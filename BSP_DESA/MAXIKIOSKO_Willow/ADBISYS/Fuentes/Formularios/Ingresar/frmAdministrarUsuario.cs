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

namespace ADBISYS.Formularios.Ingresar
{
    public partial class frmAdministrarUsuario : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql, hPassword = "";


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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validoCamposVacios()) return;
            if (validoContraseniaActual()) return;

        }

        private bool validoCamposVacios()
        {
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("El campo Descripción es obligatorio.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcion.Focus();
                return true;
            }

            if (txtContraActual.Text == "")
            {
                MessageBox.Show("El campo Contraseña Actual es obligatorio.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContraActual.Focus();
                return true;
            }

            if (txtContraNueva.Text == "")
            {
                MessageBox.Show("El campo Contraseña Nueva es obligatorio.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContraNueva.Focus();
                return true;
            }

            if (txtContraRepe.Text == "")
            {
                MessageBox.Show("El campo Repetir Contraseña es obligatorio.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContraRepe.Focus();
                return true;
            }
            return false;
        }

        private bool validoContraseniaActual()
        {
            hPassword = fg.ComputeHash(txtContraActual.Text);
            cadenaSql = "EXEC adp_buscar_usuario";
            cadenaSql = cadenaSql + " @user = " + fg.fcSql(txtUsuario.Text, "String");
            cadenaSql = cadenaSql + ",@Pass = " + fg.fcSql(hPassword, "String");

            ds = objConect.ejecutarQuerySelect(cadenaSql);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("La Contraseña Actual es incorrecta.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Focus();
                return true;
            }
            return false;
        }

        private void txtContraActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressSinEspacios(e);
        }

        private void txtContraNueva_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressSinEspacios(e);
        }

        private void txtContraRepe_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressSinEspacios(e);
        }
    }
}
