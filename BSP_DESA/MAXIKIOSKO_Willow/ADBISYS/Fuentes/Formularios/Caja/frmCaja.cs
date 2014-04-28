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
                grdMovsCaja = fg.formatoGrilla(grdMovsCaja, 1);
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

                if ((filaSeleccionada > 0) && (celdaSeleccionada > 0) && (filaSeleccionada <= grdMovsCaja.Rows.Count - 1))
                {
                    grdMovsCaja[celdaSeleccionada, filaSeleccionada].Selected = true;
                }
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
                modificarMovCaja();
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
                if (puedoEliminar())
                {
                    eliminarMovCaja();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool puedoEliminar()
        {
            try
            {
                celdaSeleccionada = grdMovsCaja.CurrentCellAddress.X;
                filaSeleccionada = grdMovsCaja.CurrentCellAddress.Y;

                MovimientoCaja movCaja = new MovimientoCaja();
                movCaja.m_Id = Int32.Parse(grdMovsCaja.Rows[filaSeleccionada].Cells["CODIGO"].Value.ToString());
                movCaja.m_descripcion = grdMovsCaja.Rows[filaSeleccionada].Cells["MOVIMIENTO"].Value.ToString();

                if (movCaja.m_Id <= 6)
                {
                    MessageBox.Show("No se permite eliminar el Movimiento " + movCaja.m_Id + " - " + movCaja.m_descripcion + ".", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (puedoEliminar())
                {
                    eliminarMovCaja();
                }
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
                eliminarMovCaja();
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

        private void eliminarMovCaja()
        {
            try
            {
                if (grdMovsCaja.DataSource != null)
                {
                    if (notFilaSeleccionada()) return;
                    eliminarMovimientoCaja();
                    llenarGrillaMovimientosCaja();
                    grdMovsCaja = fg.formatoGrilla(grdMovsCaja, 1);
                    btnEliminar.Focus();
                }
                else
                {
                    MessageBox.Show("No existen Proveedores.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarMovimientoCaja()
        {
            try
            {
                celdaSeleccionada = grdMovsCaja.CurrentCellAddress.X;
                filaSeleccionada = grdMovsCaja.CurrentCellAddress.Y;

                MovimientoCaja movCaja = new MovimientoCaja();
                movCaja.m_Id = Int32.Parse(grdMovsCaja.Rows[filaSeleccionada].Cells["CODIGO"].Value.ToString());
                movCaja.m_descripcion = grdMovsCaja.Rows[filaSeleccionada].Cells["MOVIMIENTO"].Value.ToString();

                if (MessageBox.Show("¿Está seguro que desea eliminar el movimiento " + movCaja.m_Id + "-" + movCaja.m_descripcion + "?", "Eliminar Movimiento Caja.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Entidades.Caja caja = new Entidades.Caja();
                        caja.eliminarMovCaja(movCaja.m_Id);
                        grdMovsCaja.Focus();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    btnEliminar.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
