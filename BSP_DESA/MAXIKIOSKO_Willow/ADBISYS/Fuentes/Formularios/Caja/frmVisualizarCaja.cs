using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.Conexion;
using ADBISYS.FuncionesGenerales;
namespace ADBISYS.Formularios.Caja
{
    public partial class frmVisualizarCaja : Form
    {
        public frmVisualizarCaja()
        {
            FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
            InitializeComponent();
            llenarGrillaMovimientosCaja();
            grdMovsCaja = fg.formatoGrilla(grdMovsCaja, 1);
        }

        private void llenarGrillaMovimientosCaja()
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                Entidades.Caja caja = new Entidades.Caja();
                DataSet Ds = new DataSet();

                Ds.Reset();
                Ds = caja.obtenerMovimientosCaja(fg.appFechaSistema());
                grdMovsCaja.DataSource = Ds.Tables[0];

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ajustarColumnaGrilla(DataGridView grid, int nroColumna, int anchoColumna)
        {
            try
            {
                grid.Columns[nroColumna].Width = anchoColumna;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calcularTotalesCaja()
        {
            try
            {
                Entidades.Caja caja = new Entidades.Caja();
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

                txtCajaInicial.Text = caja.obtenerTotalesDia(fg.appFechaSistema(), 1).ToString();
                txtCajaActual.Text = caja.obtenerImporteCajaActual(fg.appFechaSistema()).ToString();
                txtTotalCompras.Text = caja.obtenerTotalesDia(fg.appFechaSistema(), 2).ToString();
                txtTotalVentas.Text = caja.obtenerTotalesDia(fg.appFechaSistema(), 3).ToString();
                txtGastos.Text = caja.obtenerTotalesDia(fg.appFechaSistema(), 4).ToString();
                txtIngresos.Text = caja.obtenerTotalesDia(fg.appFechaSistema(), 5).ToString();
                txtRetiros.Text = caja.obtenerTotalesDia(fg.appFechaSistema(), 6).ToString();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

