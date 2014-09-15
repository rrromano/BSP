﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.Conexion;
using ADBISYS.Entidades;
using ADBISYS.FuncionesGenerales;

namespace ADBISYS.Formularios.Reportes
{
    public partial class frmItemsEliminados : Form
    {
        ConectarBD objConect = new ConectarBD();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        DataSet Ds = new DataSet();
        public string fecha = "";

        public frmItemsEliminados()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmItemsEliminados_Load(object sender, EventArgs e)
        {
            cargarComboItemsEliminados();
        }

        private void cargarComboItemsEliminados()
        {
            cboItemsEliminados.Items.Add("RUBROS");
            cboItemsEliminados.Items.Add("PROVEEDORES");
            cboItemsEliminados.Items.Add("MOVIMIENTOS DE CAJA");
            cboItemsEliminados.Items.Add("ARTICULOS");
            cboItemsEliminados.Items.Add("COMPRAS");
            cboItemsEliminados.Items.Add("VENTAS");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Entidades.Reportes reporte = new Entidades.Reportes();
            Ds = reporte.obtenerItemsEliminados(DateTime.Parse(fecha),cboItemsEliminados.Text);
            if (Ds.Tables[0].Rows.Count > 0)
            {
                grdItemsEliminados.DataSource = Ds.Tables[0];
                grdItemsEliminados = fg.formatoGrilla(grdItemsEliminados, 1);
                cboItemsEliminados.Focus();
            }
            else
            {
                if ((cboItemsEliminados.Text == "COMPRAS") || (cboItemsEliminados.Text == "VENTAS"))
                {
                    MessageBox.Show("No existen " + cboItemsEliminados.Text.ToLower() + " eliminadas para la fecha " + fecha + ".", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    MessageBox.Show("No existen " + cboItemsEliminados.Text.ToLower() + " eliminados para la fecha " + fecha + ".", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cboItemsEliminados.Focus();
            }
        }
    }
}
