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
using ADBISYS.Formularios.Caja;
using ADBISYS.Entidades;

namespace ADBISYS.Formularios.Caja
{
    public partial class frmCaja : Form
    {
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        int celdaSeleccionada = 0;
        int filaSeleccionada = 0;

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
            modificarMovCaja();
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
            modificarMovCaja();
        }

        private void modificarMovCaja()
        {
            try
            {
                if (notFilaSeleccionada()) return;
                mostrarFormularioModificarTipoMovimientoCaja();
                llenarGrillaMovimientosCaja();
                grdMovsCaja = fg.formatoGrilla(grdMovsCaja, 1);
                grdMovsCaja.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarFormularioModificarTipoMovimientoCaja()
        {
            try
            {
                celdaSeleccionada = grdMovsCaja.CurrentCellAddress.X;
                filaSeleccionada  = grdMovsCaja.CurrentCellAddress.Y;

                MovimientoCaja movCaja = new MovimientoCaja();
                movCaja.m_Id = Int32.Parse(grdMovsCaja.Rows[filaSeleccionada].Cells["CODIGO"].Value.ToString());
                movCaja.m_descripcion = grdMovsCaja.Rows[filaSeleccionada].Cells["MOVIMIENTO"].Value.ToString();
                movCaja.m_valor = Double.Parse(grdMovsCaja.Rows[filaSeleccionada].Cells["VALOR"].Value.ToString());

                if (grdMovsCaja.Rows[filaSeleccionada].Cells["INGRESO/SALIDA"].Value.ToString() == "INGRESO")
                {
                    movCaja.m_entradaSalida = 1;
                }
                else
                {
                    movCaja.m_entradaSalida = 0;
                }
                

                frmModificarMovimientoCaja modifCaja = new frmModificarMovimientoCaja(movCaja);
                modifCaja.ShowDialog(); 
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
                if (grdMovsCaja.SelectedRows.Count != 0){return false;}
                else{MessageBox.Show("Debe seleccionar un Movimiento de Caja.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);return true;}
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

    }
}
