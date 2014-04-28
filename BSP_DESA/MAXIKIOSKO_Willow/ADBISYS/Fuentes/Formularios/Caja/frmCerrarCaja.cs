using System;
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
        public frmCerrarCaja()
        {
            InitializeComponent();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                MovimientoCaja movCaja = new MovimientoCaja();
                DateTime fecSisActual = fg.appFechaSistema();
                String Hora = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
                String Descripcion = "Cierre de caja del día " + fg.appFechaSistema().ToString();

                movCaja.registrarMovimientoCaja(0, Descripcion, 0.00, fecSisActual, Hora);

                ParametrosGenerales pg = new ParametrosGenerales();
                pg.modificarEstadoGlobalSistema(0);
                pg.modificarFechaSistema(fecSisActual.AddDays(1));

                MessageBox.Show("Se realizó el cierre de caja Correctamente.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
