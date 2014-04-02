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
                TimeSpan hora = System.DateTime.Now.TimeOfDay;
                ConectarBD con = new ConectarBD();
                String sSQL;

                sSQL = "exec adp_registrar_mov_caja ";
                sSQL = sSQL + " @Ingreso_Salida = 1";
                sSQL = sSQL + " , @Descripcion = 'Apertura de caja del día " + System.DateTime.Now.Date.ToString() + "'";
                sSQL = sSQL + " , @Valor = '" + txtCajaInicial.Text + "'";
                sSQL = sSQL + " , @fecha = '" + fg.appFechaSistema().ToString() + "'";
                sSQL = sSQL + " , @hora = '" + hora.ToString().Substring(0,8) + "'";

                con.ejecutarQuery(sSQL);
                

                sSQL = "exec adp_actualizar_estado_global ";
                sSQL = sSQL + "   @estado = 1";
                con.ejecutarQuery(sSQL);

                this.Hide();
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
            //fg.keyPressNumerosDecimales(e);
            fg.keyPressNumeros(e);
        }

    }
}