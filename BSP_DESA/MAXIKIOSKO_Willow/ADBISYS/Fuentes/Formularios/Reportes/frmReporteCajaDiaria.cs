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
    public partial class frmReporteCajaDiaria : Form
    {
        ConectarBD objConect = new ConectarBD();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        DataSet Ds = new DataSet();
        
        public frmReporteCajaDiaria()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Caja caja = new Entidades.Caja();
                Ds = caja.obtenerMovimientosCaja(DateTime.Parse(dtpFechaCaja.Text.ToString()));
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    grdMovimientosCaja.DataSource = Ds.Tables[0];
                    grdMovimientosCaja = fg.formatoGrilla(grdMovimientosCaja, 1);
                    btnGenerarReporte.Enabled = true;
                    actualizarGanancia();

                    Entidades.Reportes reporte = new Entidades.Reportes();
                    Ds = reporte.obtenerItemsEliminados(DateTime.Parse(dtpFechaCaja.Text.ToString()),"");
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        btnItemsEliminados.Enabled = true;
                    }
                    else
                    {
                        btnItemsEliminados.Enabled = false;
                    }
                }
                else
                {
                    grdMovimientosCaja.DataSource = null;
                    btnItemsEliminados.Enabled = false;
                    btnGenerarReporte.Enabled = false;
                    vaciarImporte();
                    MessageBox.Show("No existen Movimientos de Caja para la Fecha " + dtpFechaCaja.Text.ToString() + ".", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFechaCaja.Focus();
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarGanancia()
        {
            Entidades.Venta entVentas = new Entidades.Venta();
            DataSet Ds = new DataSet();
            Ds.Reset();
            Ds = entVentas.obtenerGanancia(DateTime.Parse(dtpFechaCaja.Text.ToString()), DateTime.Parse(dtpFechaCaja.Text.ToString()));
            lblGanancia.Text = Ds.Tables[0].Rows[0]["Ganancia"].ToString();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Debemos generar el reporte");
            return;
        }

        private void dtpFechaCaja_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Entidades.Caja caja = new Entidades.Caja();
                Ds = caja.obtenerMovimientosCaja(DateTime.Parse(dtpFechaCaja.Text.ToString()));
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    grdMovimientosCaja.DataSource = Ds.Tables[0];
                    grdMovimientosCaja = fg.formatoGrilla(grdMovimientosCaja, 1);
                    btnGenerarReporte.Enabled = true;
                    actualizarGanancia();

                    Entidades.Reportes reporte = new Entidades.Reportes();
                    Ds = reporte.obtenerItemsEliminados(DateTime.Parse(dtpFechaCaja.Text.ToString()), "");
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        btnItemsEliminados.Enabled = true;
                    }
                    else
                    {
                        btnItemsEliminados.Enabled = false;
                    }
                }
                else
                {
                    grdMovimientosCaja.DataSource = null;
                    btnItemsEliminados.Enabled = false;
                    btnGenerarReporte.Enabled = false;
                    vaciarImporte();
                    MessageBox.Show("No existen Movimientos de Caja para la Fecha " + dtpFechaCaja.Text.ToString() + ".", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFechaCaja.Focus();
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnItemsEliminados_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemsEliminados itemsEliminados = new frmItemsEliminados();
                itemsEliminados.fecha = dtpFechaCaja.Text;
                itemsEliminados.ShowDialog();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReporteCajaDiaria_Load(object sender, EventArgs e)
        {
            try
            {
                vaciarImporte();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vaciarImporte()
        {
            lblGanancia.Text = "0,00";
        }
    }
}
