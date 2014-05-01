using System;
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
                    if (hayMovimientosHoy())
                    {
                        if (!(preguntoSiEliminarMovimientosHoy()))
                        {
                            return;
                        }
                        else
                        {
                            eliminarMovimientosHoy();
                        }
                    }

                    registrarCajaInicial();
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarMovimientosHoy()
        {
            try
            {
                Entidades.Caja caja = new Entidades.Caja();
                caja.eliminarMovCajaPorFecha(DateTime.Now.Date);
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean preguntoSiEliminarMovimientosHoy()
        {
            try
            {
                if (MessageBox.Show("No se puede iniciar la caja del día de hoy ya que existen movimientos con la fecha de hoy. Si inicia la caja se eliminaran todos los movimientos actuales con la fecha de hoy. \n¿Está seguro que desa continuar?", "¿Está Seguro?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool hayMovimientosHoy()
        {
            try
            {
                Entidades.Caja caja = new Entidades.Caja();

                return caja.verificarExistenciaMovCajaSegunFecha(DateTime.Now.Date);
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool validar()
        {
            try
            {
                if (txtCajaInicial.Text.Length == 0)
                {
                    MessageBox.Show("Debe indicar el importe de la caja para poder iniciar la misma.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (!(fg.esUnNumeroDecimal(txtCajaInicial.Text)))
                {
                    MessageBox.Show("El importe ingresado es inválido.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCajaInicial.Focus();
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
                ParametrosGenerales pg = new ParametrosGenerales();
                pg.modificarEstadoGlobalSistema(0);
                pg.modificarFechaSistema(DateTime.Now.Date);
                registrarMovimientosInicialesCaja();
                modificarCajaInicial();

                //ParametrosGenerales pg = new ParametrosGenerales();
                pg.modificarEstadoGlobalSistema(1);

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