using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADBISYS.Formularios.Caja
{
    public partial class frmTipoMovimientoCaja : Form
    {

        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        int celdaSeleccionada = 0;
        int filaSeleccionada = 0;

        public frmTipoMovimientoCaja()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                nuevoMovimientoCaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoMovimientoCaja()
        {
            frmNuevoMovimientoCaja nuevoMov = new frmNuevoMovimientoCaja();
            nuevoMov.ShowDialog();
        }

        private void frmTipoMovimientoCaja_Activated(object sender, EventArgs e)
        {
            try
            {
                llenarGrillaTipoMovCaja();
                grdTipoMovCaja = fg.formatoGrilla(grdTipoMovCaja, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenarGrillaTipoMovCaja()
        {
            Entidades.MovimientoCaja MovCaja = new Entidades.MovimientoCaja();
            DataSet Ds = new DataSet();

            Ds.Reset();
            Ds = MovCaja.obtenerTipoMovsCaja();
            if (Ds.Tables[0].Rows.Count > 0) grdTipoMovCaja.DataSource = Ds.Tables[0];

            if ((filaSeleccionada > 0) && (celdaSeleccionada > 0) && (filaSeleccionada <= grdTipoMovCaja.Rows.Count - 1))
            {
                grdTipoMovCaja[celdaSeleccionada, filaSeleccionada].Selected = true;
            }
        }
    }
}
