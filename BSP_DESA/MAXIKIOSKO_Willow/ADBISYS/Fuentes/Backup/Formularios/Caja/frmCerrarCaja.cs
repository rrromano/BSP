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
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

        public frmCerrarCaja()
        {
            InitializeComponent();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean deseaModificarUnMovimiento = (MessageBox.Show("¿Desea modificar algún movimiento antes de realizar el Cierre de Caja correspondiente?", "Cierre de Caja.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);

                if (deseaModificarUnMovimiento)
                {
                    frmCaja caja = new frmCaja();
                    caja.ShowDialog();
                }
                else
                {
                    Entidades.Caja caja = new Entidades.Caja();
                    Boolean deseaContinuarConElCierreDeLaCaja = (MessageBox.Show("A continuación se realizará el Cierre de Caja correspondiente al día " + caja.obtenerFechaCajaAbierta() + ". ¿Desea Continuar?", "Cierre de Caja.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);

                    if (deseaContinuarConElCierreDeLaCaja)
                    {
                        MovimientoCaja movCaja = new MovimientoCaja();
                        DateTime fecSisActual = fg.appFechaSistema();
                        String Hora = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
                        String Descripcion = "Cierre de caja del día " + fg.appFechaSistema().ToString();

                        DataSet Ds = new DataSet();
                        Ds.Reset();
                        Ds = caja.obtenerCierreParcialCaja(fg.appFechaSistema());
                        double valor = double.Parse(Ds.Tables[0].Rows[0]["Cierre_Parcial"].ToString());

                        movCaja.registrarMovimientoCaja(0, Descripcion, valor, fecSisActual, Hora);

                        ParametrosGenerales pg = new ParametrosGenerales();
                        pg.modificarEstadoGlobalSistema(0); //CIERRO LA CAJA - ESTADO "0"

                        MessageBox.Show("Se realizó el Cierre de Caja Correctamente.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }
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
                actualizarCierreParcial();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarCierreParcial()
        {
            Entidades.Caja caja = new Entidades.Caja();
            DataSet Ds = new DataSet();
            Ds.Reset();
            Ds = caja.obtenerCierreParcialCaja(fg.appFechaSistema());
            txtCierreParcial.Text = Ds.Tables[0].Rows[0]["Cierre_Parcial"].ToString();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
