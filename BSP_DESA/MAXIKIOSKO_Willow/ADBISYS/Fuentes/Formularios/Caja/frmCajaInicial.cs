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


namespace ADBISYS.Formularios.Caja
{
    public partial class frmCajaInicial : Form
    {
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
                MessageBox.Show(r.Message);
            }
        }

        private bool validar()
        {
            try
            {
                Entidades.Caja caja = new Entidades.Caja();

                if (caja.obtenerEstado() != 0)
                {
                    MessageBox.Show("No se puede iniciar debido a que no se cerró la caja del día " + caja.obtenerFechaCajaAbierta(),"Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }

        private void registrarCajaInicial()
        {
            try
            {
                ConectarBD con = new ConectarBD();
                string sSQL;

                sSQL = "exec adp_registrar_mov_caja ";
                sSQL = sSQL + "   @Ingreso_Salida = 1";
                sSQL = sSQL + " , @Descripcion = 'Apertura de caja del día " + System.DateTime.Now.Date.ToString() + "'";
                sSQL = sSQL + " , @Valor = '" + txtCajaInicial.Text + "'";
                sSQL = sSQL + " , @fecha = '" + System.DateTime.Now.Date.ToString() + "'";
                sSQL = sSQL + " , @hora = " + System.DateTime.Now.Date.Hour.ToString();

                con.ejecutarQuery(sSQL);
                this.Hide();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}