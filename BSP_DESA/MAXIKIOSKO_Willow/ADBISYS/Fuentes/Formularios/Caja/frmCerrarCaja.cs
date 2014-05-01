﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.FuncionesGenerales;
using ADBISYS.Entidades;

namespace ADBISYS.Formularios.Caja
{
    public partial class frmCerrarCaja : Form
    {
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

        public frmCerrarCaja()
        {
            InitializeComponent();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            try
            {
                MovimientoCaja movCaja = new MovimientoCaja();
                DateTime fecSisActual = fg.appFechaSistema();
                String Hora = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
                String Descripcion = "Cierre de caja del día " + fg.appFechaSistema().ToString();

                movCaja.registrarMovimientoCaja(0, Descripcion, 0.00, fecSisActual, Hora);

                ParametrosGenerales pg = new ParametrosGenerales();
                pg.modificarEstadoGlobalSistema(0);
                //pg.modificarFechaSistema(fecSisActual.AddDays(1));

                MessageBox.Show("Se realizó el cierre de caja Correctamente.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCerrarCaja_Activated(object sender, EventArgs e)
        {
            try
            {
                llenarGrillaMovimientosCierreCaja();
                grdMovsCaja = fg.formatoGrilla(grdMovsCaja, 1);
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenarGrillaMovimientosCierreCaja()
        {
            try
            {
                Entidades.Caja Caja = new Entidades.Caja();
                DataSet Ds = new DataSet();

                Ds.Reset();
                Ds = Caja.obtenerMovimientosCierreCaja(fg.appFechaSistema());
                if (Ds.Tables[0].Rows.Count > 0) grdMovsCaja.DataSource = Ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Boolean respuesta = (MessageBox.Show("¿Desea modificar algún movimiento antes de realizar el Cierre de la Caja del día de Hoy?", "Cierre de Caja.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);

            if (respuesta)
            {
                frmCaja caja = new frmCaja();
                caja.Show();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
