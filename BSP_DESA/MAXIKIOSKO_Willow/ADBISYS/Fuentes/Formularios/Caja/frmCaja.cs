using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.FuncionesGenerales;
using ADBISYS.Conexion;

namespace ADBISYS.Formularios.Caja
{
    public partial class frmCaja : Form
    {
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

        public frmCaja()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void frmCaja_Activated(object sender, EventArgs e)
        {
            try
            {
                llenarGrillaMovimientosCaja();
                grdMovsCaja = fg.formatoGrilla(grdMovsCaja, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void llenarGrillaMovimientosCaja()
        {
            try 
	        {	
                Entidades.Caja caja = new Entidades.Caja();
                DataSet Ds = new DataSet();
                
                Ds.Reset();
                Ds = caja.obtenerMovimientosCaja(fg.appFechaSistema());
                if (Ds.Tables[0].Rows.Count > 0) grdMovsCaja.DataSource = Ds.Tables[0];
	        }
	        catch (Exception ex)
	        {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
	        }
        }

        private void salidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salir();
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

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                modificarMovimientoCaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                eliminarMovimientoCaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                modificarMovimientoCaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                eliminarMovimientoCaja();
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

        private void modificarMovimientoCaja()
        {
            MessageBox.Show("Falta Implementar");
        }

        private void eliminarMovimientoCaja()
        {
            MessageBox.Show("Falta Implementar");
        }

        private void salir()
        {
            this.Close();
        }

        private void grdMovsCaja_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            modificarTipoMovCaja();
        }

        private void modificarTipoMovCaja()
        {
            throw new NotImplementedException();
        }

    }
}
