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

namespace ADBISYS.Formularios.Reportes
{
    public partial class frmReporteCompras : Form
    {
        ConectarBD objConect = new ConectarBD();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        DataSet Ds = new DataSet();
        
        public frmReporteCompras()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Debemos generar el reporte");
            return;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validarFechas()) return;

            Entidades.Reportes entRepo = new ADBISYS.Entidades.Reportes();
            Ds = entRepo.verificarExistenciaCompras(DateTime.Parse(dtpFechaDesde.Text.ToString()), DateTime.Parse(dtpFechaHasta.Text.ToString()));

            if (Ds.Tables[0].Rows.Count > 0)
            {
                grdCompras.DataSource = Ds.Tables[0];
                grdCompras = fg.formatoGrilla(grdCompras, 1);
                btnGenerarReporte.Enabled = true;
            }
            else
            {
                if (dtpFechaDesde.Text == dtpFechaHasta.Text)
                {
                    grdCompras.DataSource = null;
                    btnGenerarReporte.Enabled = false;
                    MessageBox.Show("No existen Compras para la Fecha " + dtpFechaDesde.Text.ToString() + ".", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFechaDesde.Focus();
                    return;
                }
                else
                {
                    grdCompras.DataSource = null;
                    btnGenerarReporte.Enabled = false;
                    MessageBox.Show("No existen Compras entre las Fechas " + dtpFechaDesde.Text.ToString() + " y " + dtpFechaHasta.Text.ToString() + ".", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFechaDesde.Focus();
                    return;
                }
            }
        }

        private bool validarFechas()
        {
            if (DateTime.Parse(dtpFechaDesde.Text.ToString()) > DateTime.Parse(dtpFechaHasta.Text.ToString()))
            {
                MessageBox.Show("Las Fechas seleccionadas son incorrectas. \nFecha Desde no puede ser posterior a Fecha Hasta.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFechaDesde.Focus();
                return true;
            }
            return false;
        }

        private void frmReporteCompras_Load(object sender, EventArgs e)
        {
            vaciarImporte();
        }

        private void vaciarImporte()
        {
            lblTotal.Text = "0,00";
        }
    }
}
