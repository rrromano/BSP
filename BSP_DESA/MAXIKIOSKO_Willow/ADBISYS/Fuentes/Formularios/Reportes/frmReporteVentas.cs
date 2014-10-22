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
    public partial class frmReporteVentas : Form
    {
        ConectarBD objConect = new ConectarBD();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        DataSet Ds = new DataSet();
        int filaSeleccionada = 0;
        
        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarFechas()) return;
                Entidades.Reportes entRepo = new ADBISYS.Entidades.Reportes();
                Ds = entRepo.verificarExistenciaVentas(DateTime.Parse(dtpFechaDesde.Text.ToString()), DateTime.Parse(dtpFechaHasta.Text.ToString()));

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    grdVentas.DataSource = Ds.Tables[0];
                    grdVentas = fg.formatoGrilla(grdVentas, 1);
                    btnGenerarReporte.Enabled = true;
                    btnVisualizar.Enabled = true;
                    actualizarGanancia();
                }
                else
                {
                    if (dtpFechaDesde.Text == dtpFechaHasta.Text)
                    {
                        grdVentas.DataSource = null;
                        btnGenerarReporte.Enabled = false;
                        btnVisualizar.Enabled = false;
                        vaciarImporte();
                        MessageBox.Show("No existen Ventas para la Fecha " + dtpFechaDesde.Text.ToString() + ".", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtpFechaDesde.Focus();
                        return;
                    }
                    else
                    {
                        grdVentas.DataSource = null;
                        btnGenerarReporte.Enabled = false;
                        btnVisualizar.Enabled = false;
                        vaciarImporte();
                        MessageBox.Show("No existen Ventas entre las Fechas " + dtpFechaDesde.Text.ToString() + " y " + dtpFechaHasta.Text.ToString() + ".", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtpFechaDesde.Focus();
                        return;
                    }
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
            Ds = entVentas.obtenerGanancia(DateTime.Parse(dtpFechaDesde.Text.ToString()), DateTime.Parse(dtpFechaHasta.Text.ToString()));
            lblGanancia.Text = Ds.Tables[0].Rows[0]["Ganancia"].ToString();
        }

        //private void actualizarLabelTotal()
        //{
        //    try
        //    {
        //        Entidades.Reportes entRepo = new ADBISYS.Entidades.Reportes();
        //        Ds = entRepo.obtenerTotalVentas(DateTime.Parse(dtpFechaDesde.Text.ToString()), DateTime.Parse(dtpFechaHasta.Text.ToString()));

        //        if (Ds.Tables[0].Rows.Count > 0)
        //        {
        //            lblGanancia.Text = Ds.Tables[0].Rows[0]["IMPORTE"].ToString();
        //        }
        //        return;
        //    }
        //    catch (Exception r)
        //    {
        //        MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private bool validarFechas()
        {
            try
            {
                if (DateTime.Parse(dtpFechaDesde.Text.ToString()) > DateTime.Parse(dtpFechaHasta.Text.ToString()))
                {
                    MessageBox.Show("Las Fechas seleccionadas son incorrectas. \nFecha Desde no puede ser posterior a Fecha Hasta.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFechaDesde.Focus();
                    return true;
                }
                return false;
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Debemos generar el reporte");
                return;
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
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

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdVentas.DataSource != null)
                {
                    if (notFilaSeleccionada()) return;
                    mostrarFormularioVisualizarVenta();
                }
                else
                {
                    MessageBox.Show("No existen Ventas.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarFormularioVisualizarVenta()
        {
            try
            {
                filaSeleccionada = grdVentas.CurrentCellAddress.Y;
                frmVisualizarVenta visualizarVenta = new frmVisualizarVenta();
                visualizarVenta.codigo_venta = grdVentas.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString();
                visualizarVenta.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private bool notFilaSeleccionada()
        {
            try
            {
                if (grdVentas.SelectedRows.Count != 0)
                {
                    return false;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una Venta.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private void grdVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdVentas.DataSource != null)
                {
                    if (notFilaSeleccionada()) return;
                    mostrarFormularioVisualizarVenta();
                }
                else
                {
                    MessageBox.Show("No existen Ventas.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdVentas_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                {
                    e.SuppressKeyPress = true;
                    mostrarFormularioVisualizarVenta();
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
