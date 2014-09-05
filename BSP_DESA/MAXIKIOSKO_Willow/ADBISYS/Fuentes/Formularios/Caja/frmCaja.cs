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
        ConectarBD objConect = new ConectarBD();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        int celdaSeleccionada = 0;
        int filaSeleccionada = 0;
        string cadenaSql, campoAnterior, textoAnterior, campoOrdenamiento = "";
        Boolean EstoyBuscando =false;
        Boolean ordenamiento = true;
        Dictionary<string, string> campos_tabla = new Dictionary<string, string>();
        DataSet Ds = new DataSet();

        public frmCaja()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void llenarGrillaMovimientosCaja()
        {
            try 
	        {
                if (EstoyBuscando == false)
                {
                    Entidades.Caja caja = new Entidades.Caja();
                    Ds = caja.obtenerMovimientosCaja(fg.appFechaSistema());
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        grdMovsCaja.DataSource = Ds.Tables[0];
                    }
                    else
                    {
                        grdMovsCaja.DataSource = null;
                    }
                }
                else
                {
                    cadenaSql = "EXEC adp_busqueda_movimientos_caja";
                    cadenaSql = cadenaSql + " @tabla = " + fg.fcSql("MOVIMIENTOS_CAJA", "String");
                    cadenaSql = cadenaSql + ",@campo_tabla = " + fg.fcSql(obtenerCampoTabla().ToString(), "String");
                    cadenaSql = cadenaSql + ",@texto = " + fg.fcSql(textoAnterior, "String").Replace(",",".");
                    cadenaSql = cadenaSql + ",@Fecha = " + fg.fcSql(fg.appFechaSistema().ToString(), "Datetime");

                    Ds = objConect.ejecutarQuerySelect(cadenaSql);
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        grdMovsCaja.DataSource = Ds.Tables[0];
                    }
                }

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

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void nuevoMovimientoCaja()
        {
            frmNuevoMovimientoCaja nuevoMov = new frmNuevoMovimientoCaja();
            nuevoMov.ShowDialog();
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
                mostrarFormularioModificarMovimientoCaja();
                llenarGrillaMovimientosCaja();
                grdMovsCaja = fg.formatoGrilla(grdMovsCaja, 1);
                grdMovsCaja.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarFormularioModificarMovimientoCaja()
        {
            try
            {
                celdaSeleccionada = grdMovsCaja.CurrentCellAddress.X;
                filaSeleccionada  = grdMovsCaja.CurrentCellAddress.Y;

                MovimientoCaja movCaja = new MovimientoCaja();
                movCaja.m_Id = Int32.Parse(grdMovsCaja.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString());
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

        private void grdMovsCaja_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                {
                    e.SuppressKeyPress = true;
                    modificarMovCaja();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCaja_Load(object sender, EventArgs e)
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

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void btnActualizar_Click(object sender, EventArgs e)
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

        private void salirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarMovimiento();
        }

        private void buscarMovimiento()
        {
            Entidades.Caja caja = new Entidades.Caja();
            DataSet Ds = new DataSet();
            Ds.Reset();
            Ds = caja.obtenerMovimientosCaja(fg.appFechaSistema());
            if (Ds.Tables[0].Rows.Count > 0)
            {
                mostrarFormularioBusquedaMovimientos();
                llenarGrillaMovimientosCaja();
                grdMovsCaja = fg.formatoGrilla(grdMovsCaja, 1);
                grdMovsCaja.Focus();
            }
            else
            {
                MessageBox.Show("No existen Movimientos.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBuscar.Focus();
            }
        }

        private void mostrarFormularioBusquedaMovimientos()
        {
            frmBusquedaMovCaja buscarMovCaja = new frmBusquedaMovCaja();
            buscarMovCaja.campo = campoAnterior;
            buscarMovCaja.texto = textoAnterior;
            buscarMovCaja.estoyBuscando = EstoyBuscando;
            buscarMovCaja.ShowDialog();
            EstoyBuscando = buscarMovCaja.estoyBuscando;
            campoAnterior = buscarMovCaja.campo;
            textoAnterior = buscarMovCaja.texto;
            campos_tabla = buscarMovCaja.campos_tabla;
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

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            ordenamientoMovimientosCaja();
        }

        private void ordenarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ordenamientoMovimientosCaja();
        }

        private void ordenamientoMovimientosCaja()
        {
            if (grdMovsCaja.DataSource != null)
            {
                mostrarFormularioOrdenarMovCaja();
                grdMovsCaja.Focus();
            }
            else
            {
                MessageBox.Show("No existen Movimientos.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOrdenar.Focus();
            }
        }

        private void mostrarFormularioOrdenarMovCaja()
        {
            frmOrdenarMovCaja ordenarMovCaja = new frmOrdenarMovCaja();
            ordenarMovCaja.Ascendente = ordenamiento;
            ordenarMovCaja.campo = campoOrdenamiento;
            ordenarMovCaja.ShowDialog();
            campoOrdenamiento = ordenarMovCaja.campo;
            ordenamiento = ordenarMovCaja.Ascendente;
            DataGridViewColumn columna = grdMovsCaja.Columns[campoOrdenamiento];
            if (campoOrdenamiento != "")
            {
                if (ordenamiento == true)
                {
                    grdMovsCaja.Sort(columna, ListSortDirection.Ascending);
                }
                if (ordenamiento == false)
                {
                    grdMovsCaja.Sort(columna, ListSortDirection.Descending);
                }
            }
        }

        private void buscarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            buscarMovimiento();
        }
    }
}
