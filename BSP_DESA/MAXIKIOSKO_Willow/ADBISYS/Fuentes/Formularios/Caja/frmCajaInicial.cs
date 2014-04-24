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
using System.Text.RegularExpressions;

namespace ADBISYS.Formularios.Caja
{
    public partial class frmCajaInicial : Form
    {
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

        public frmCajaInicial()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validar())
                {
                    registrarCajaInicial();
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validar()
        {
            try
            {
                Entidades.Caja caja = new Entidades.Caja();
                DateTime fechaSistema = fg.appFechaSistema();
                Regex reg = new Regex("[0-9]*.*[0-9][0-9]");


                if (caja.obtenerEstado() != 0)
                {
                    MessageBox.Show("No se puede iniciar la caja del día " + fechaSistema.ToString() + " debido a que no se cerró la caja del día " + caja.obtenerFechaCajaAbierta().ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (txtCajaInicial.Text.Length == 0)
                {
                    MessageBox.Show("Debe indicar el importe de la caja para poder iniciar la misma.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (!(reg.IsMatch(txtCajaInicial.Text.ToString())))
                {
                    MessageBox.Show("Debe indicar un importe correcto.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;                    
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void registrarCajaInicial()
        {
            try
            {
                registrarMovimientosInicialesCaja();
                modificarCajaInicial();
                fg.modificarEstadoGlobalSistema(1);
                this.Hide();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }

        private void modificarCajaInicial()
        {
            DateTime Dia = fg.appFechaSistema();
            MovimientoCaja movCaja = new MovimientoCaja();
            movCaja.modificarCajaInicial(Dia, txtCajaInicial.Text);
        }

        private void registrarMovimientosInicialesCaja()
        {
            try 
            {
                TimeSpan hora = System.DateTime.Now.TimeOfDay;
                MovimientoCaja movCaja = new MovimientoCaja();
                DateTime Dia = fg.appFechaSistema();
                String Hora = hora.ToString().Substring(0, 8);

                movCaja.registrarMovimientosCaja(Dia, Hora);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtCajaInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressNumerosDecimales(e, txtCajaInicial);
            //fg.keyPressNumeros(e);
        }
    }
}