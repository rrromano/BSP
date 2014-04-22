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

namespace ADBISYS.Formularios.Proveedores
{
    public partial class frmOrdenarProveedor : Form
    {
        ConectarBD objConect = new ConectarBD();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql = "";
        public string campo;
        public bool Ascendente = true;

        public frmOrdenarProveedor()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            campo = "CÓDIGO";
            Ascendente = true;
            this.Hide();
        }

        private void frmOrdenarProveedor_Load(object sender, EventArgs e)
        {
            cargarComboCampo();
            rbtnAscendente.Checked = true;
        }

        private void cargarComboCampo()
        {
            try
            {
                DataSet ds = new DataSet();
                string campoSelec = cboCampo.Text;
                cboCampo.Items.Clear();

                cadenaSql = "EXEC adp_cboBusqueda_proveedores";
                ds.Reset();
                ds = objConect.ejecutarQuerySelect(cadenaSql);

                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    cboCampo.Items.Add(dataRow["CAMPO"]);
                }

                cboCampo.Text = campoSelec;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validoCampos()) return;
            campo = cboCampo.Text;
            if (rbtnAscendente.Checked == true)
            {
                Ascendente = true;
            }
            if (rbtnAscendente.Checked == true)
            {
                Ascendente = false;
            }
            this.Hide();
        }

        private bool validoCampos()
        {
            if (cboCampo.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Campo.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboCampo.Focus();
                return true;
            }
            return false;
        }


    }
}
