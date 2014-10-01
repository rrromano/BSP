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
    public partial class frmTipoMovCaja : Form
    {
        ConectarBD objConect = new ConectarBD();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        int celdaSeleccionada = 0;
        int filaSeleccionada = 0;
        string cadenaSql, campoAnterior, textoAnterior, campoOrdenamiento = "";
        Boolean EstoyBuscando = false;
        Boolean ordenamiento = true;
        Dictionary<string, string> campos_tabla = new Dictionary<string, string>();
        DataSet Ds = new DataSet();

        public frmTipoMovCaja()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                nuevoTipoMovimientoCaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoTipoMovimientoCaja()
        {
            frmNuevoMovCaja nuevoMov = new frmNuevoMovCaja();
            nuevoMov.ShowDialog();
            llenarGrillaTipoMovimientosCaja();
            grdTipoMovCaja = fg.formatoGrilla(grdTipoMovCaja, 1);
            grdTipoMovCaja.Focus();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                modificarTipoMovCaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarTipoMovCaja()
        {
            try
            {
                if (notFilaSeleccionada()) return;
                mostrarFormularioModificarTipoMovimientoCaja();
                llenarGrillaTipoMovimientosCaja();
                grdTipoMovCaja = fg.formatoGrilla(grdTipoMovCaja, 1);
                grdTipoMovCaja.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenarGrillaTipoMovimientosCaja()
        {
            try
            {
                if (EstoyBuscando == false)
                {
                    Entidades.TipoMovimientoCaja TipoMovCaja = new Entidades.TipoMovimientoCaja();
                    DataSet Ds = new DataSet();
                    Ds = TipoMovCaja.obtenerTiposMovimientosCaja();
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        grdTipoMovCaja.DataSource = Ds.Tables[0];
                    }
                    else
                    {
                        grdTipoMovCaja.DataSource = null;
                    }

                }
                else
                {
                    cadenaSql = "EXEC adp_busqueda_TipoMovimientos_caja";
                    cadenaSql = cadenaSql + " @tabla = " + fg.fcSql("TIPOMOVIMIENTO_CAJA", "String");
                    cadenaSql = cadenaSql + ",@campo_tabla = " + fg.fcSql(obtenerCampoTabla().ToString(), "String");
                    cadenaSql = cadenaSql + ",@texto = " + fg.fcSql(textoAnterior, "String").Replace(",", ".");

                    Ds = objConect.ejecutarQuerySelect(cadenaSql);
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        grdTipoMovCaja.DataSource = Ds.Tables[0];
                    }
                }

                if ((filaSeleccionada > 0) && (celdaSeleccionada > 0) && (filaSeleccionada <= grdTipoMovCaja.Rows.Count - 1))
                {
                    grdTipoMovCaja[celdaSeleccionada, filaSeleccionada].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private object obtenerCampoTabla()
        {
            try
            {
                foreach (KeyValuePair<string, string> campo in campos_tabla)
                {
                    if (campoAnterior == campo.Value)
                    {
                        return (campo.Key);
                    }
                }
                return "ok";
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "error";
            }
        }

        private void mostrarFormularioModificarTipoMovimientoCaja()
        {
            try
            {
                celdaSeleccionada = grdTipoMovCaja.CurrentCellAddress.X;
                filaSeleccionada = grdTipoMovCaja.CurrentCellAddress.Y;

                Entidades.TipoMovimientoCaja TipoMovCaja = new Entidades.TipoMovimientoCaja();
                TipoMovCaja.m_ID_TipoMovimiento = Int32.Parse(grdTipoMovCaja.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString());
                TipoMovCaja.m_Descripcion = grdTipoMovCaja.Rows[filaSeleccionada].Cells["MOVIMIENTO"].Value.ToString();

                if (grdTipoMovCaja.Rows[filaSeleccionada].Cells["INGRESO/SALIDA"].Value.ToString() == "INGRESO")
                {
                    TipoMovCaja.m_entradaSalida = 1;
                }
                else
                {
                    TipoMovCaja.m_entradaSalida = 0;
                }

                frmModificarTipoMovCaja modifTipoMovCaja = new frmModificarTipoMovCaja(TipoMovCaja);
                modifTipoMovCaja.ShowDialog();
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
                if (grdTipoMovCaja.SelectedRows.Count != 0) { return false; }
                else { MessageBox.Show("Debe seleccionar un Movimiento de Caja.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information); return true; }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (puedoEliminar())
                {
                    eliminarTipoMovimientoCaja();
                    eliminarEseTipoMovimientoConFechaHoy();
                    llenarGrillaTipoMovimientosCaja();
                    grdTipoMovCaja = fg.formatoGrilla(grdTipoMovCaja, 1);
                    btnEliminar.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarEseTipoMovimientoConFechaHoy()
        {
            try
            {
                celdaSeleccionada = grdTipoMovCaja.CurrentCellAddress.X;
                filaSeleccionada = grdTipoMovCaja.CurrentCellAddress.Y;

                Entidades.TipoMovimientoCaja TipoMovCaja = new Entidades.TipoMovimientoCaja();
                TipoMovCaja.m_ID_TipoMovimiento = Int32.Parse(grdTipoMovCaja.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString());
                TipoMovCaja.eliminarTipoMovCajaDeHoy(TipoMovCaja.m_ID_TipoMovimiento, fg.appFechaSistema());
                grdTipoMovCaja.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarTipoMovimientoCaja()
        {
            try
            {
                celdaSeleccionada = grdTipoMovCaja.CurrentCellAddress.X;
                filaSeleccionada = grdTipoMovCaja.CurrentCellAddress.Y;

                Entidades.TipoMovimientoCaja TipoMovCaja = new Entidades.TipoMovimientoCaja();
                TipoMovCaja.m_ID_TipoMovimiento = Int32.Parse(grdTipoMovCaja.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString());
                TipoMovCaja.eliminarTipoMovCaja(TipoMovCaja.m_ID_TipoMovimiento);
                grdTipoMovCaja.Focus();
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
                if (grdTipoMovCaja.DataSource == null)
                {
                    MessageBox.Show("No existen Proveedores.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (notFilaSeleccionada()) return false;

                celdaSeleccionada = grdTipoMovCaja.CurrentCellAddress.X;
                filaSeleccionada = grdTipoMovCaja.CurrentCellAddress.Y;

                Entidades.TipoMovimientoCaja TipoMovCaja = new Entidades.TipoMovimientoCaja();
                TipoMovCaja.m_ID_TipoMovimiento = Int32.Parse(grdTipoMovCaja.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString());
                TipoMovCaja.m_Descripcion = grdTipoMovCaja.Rows[filaSeleccionada].Cells["MOVIMIENTO"].Value.ToString();

                if (TipoMovCaja.m_ID_TipoMovimiento <= 6)
                {
                    MessageBox.Show("No se permite eliminar el Movimiento " + TipoMovCaja.m_ID_TipoMovimiento + " - " + TipoMovCaja.m_Descripcion + ".", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (MessageBox.Show("¿Está seguro que desea eliminar el movimiento " + TipoMovCaja.m_ID_TipoMovimiento + "-" + TipoMovCaja.m_Descripcion + "?", "Eliminar Movimiento Caja.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    btnEliminar.Focus();
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

        private void grdTipoMovCaja_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                {
                    e.SuppressKeyPress = true;
                    modificarTipoMovCaja();
                }
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
                nuevoTipoMovimientoCaja();
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
                modificarTipoMovCaja();
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
                if (puedoEliminar())
                {
                    eliminarTipoMovimientoCaja();
                    eliminarEseTipoMovimientoConFechaHoy();
                    llenarGrillaTipoMovimientosCaja();
                    grdTipoMovCaja = fg.formatoGrilla(grdTipoMovCaja, 1);
                    btnEliminar.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void salir()
        {
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void frmTipoMovCaja_Load(object sender, EventArgs e)
        {
            try
            {
                llenarGrillaTipoMovimientosCaja();
                grdTipoMovCaja = fg.formatoGrilla(grdTipoMovCaja, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizarTipoMovCaja();
        }

        private void actualizarTipoMovCaja()
        {
            try
            {
                llenarGrillaTipoMovimientosCaja();
                grdTipoMovCaja = fg.formatoGrilla(grdTipoMovCaja, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actualizarTipoMovCaja();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarTipoMovimiento();
        }

        private void buscarTipoMovimiento()
        {
            Entidades.TipoMovimientoCaja TipoMovCaja = new Entidades.TipoMovimientoCaja();
            DataSet Ds = new DataSet();
            Ds.Reset();
            Ds = TipoMovCaja.obtenerTiposMovimientosCaja();
            if (Ds.Tables[0].Rows.Count > 0)
            {
                mostrarFormularioBusquedaTiposDeMovimientos();
                llenarGrillaTipoMovimientosCaja();
                grdTipoMovCaja = fg.formatoGrilla(grdTipoMovCaja, 1);
                grdTipoMovCaja.Focus();
            }
            else
            {
                MessageBox.Show("No existen Tipos de Movimientos de Caja.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBuscar.Focus();
            }
        }

        private void mostrarFormularioBusquedaTiposDeMovimientos()
        {
            frmBusquedaTipoMovCaja buscarTipoMovCaja = new frmBusquedaTipoMovCaja();
            buscarTipoMovCaja.campo = campoAnterior;
            buscarTipoMovCaja.texto = textoAnterior;
            buscarTipoMovCaja.estoyBuscando = EstoyBuscando;
            buscarTipoMovCaja.ShowDialog();
            EstoyBuscando = buscarTipoMovCaja.estoyBuscando;
            campoAnterior = buscarTipoMovCaja.campo;
            textoAnterior = buscarTipoMovCaja.texto;
            campos_tabla = buscarTipoMovCaja.campos_tabla;
            actualizarLabelFiltroBusqueda();
            return;
        }

        private void actualizarLabelFiltroBusqueda()
        {
            if (EstoyBuscando == true)
            {
                lbFiltroBusqueda.Text = "FILTRO DE BÚSQUEDA --> CAMPO: " + campoAnterior + ", TEXTO: " + textoAnterior + ".";
            }
            else
            {
                lbFiltroBusqueda.Text = "SIN FILTRO DE BÚSQUEDA.";
            }
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscarTipoMovimiento();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            ordenamientoTipoMovimientosCaja();
        }

        private void ordenarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ordenamientoTipoMovimientosCaja();
        }

        private void ordenamientoTipoMovimientosCaja()
        {
            if (grdTipoMovCaja.DataSource != null)
            {
                mostrarFormularioOrdenarTipoMovCaja();
                grdTipoMovCaja.Focus();
            }
            else
            {
                MessageBox.Show("No existen Tipos de Movimientos.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOrdenar.Focus();
            }
        }

        private void mostrarFormularioOrdenarTipoMovCaja()
        {
            frmOrdernarTipoMovCaja ordenarTipoMovCaja = new frmOrdernarTipoMovCaja();
            ordenarTipoMovCaja.Ascendente = ordenamiento;
            ordenarTipoMovCaja.campo = campoOrdenamiento;
            ordenarTipoMovCaja.ShowDialog();
            campoOrdenamiento = ordenarTipoMovCaja.campo;
            ordenamiento = ordenarTipoMovCaja.Ascendente;
            DataGridViewColumn columna = grdTipoMovCaja.Columns[campoOrdenamiento];
            if (campoOrdenamiento != "")
            {
                if (ordenamiento == true)
                {
                    grdTipoMovCaja.Sort(columna, ListSortDirection.Ascending);
                }
                if (ordenamiento == false)
                {
                    grdTipoMovCaja.Sort(columna, ListSortDirection.Descending);
                }
            }
        }

        private void grdTipoMovCaja_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                modificarTipoMovCaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
