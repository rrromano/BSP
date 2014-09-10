using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.Formularios.Rubros;
using ADBISYS.Conexion;
using ADBISYS.Entidades;

namespace ADBISYS.Formularios.Rubros
{
    public partial class frmRubrosPrincipal : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql, campoAnterior, textoAnterior, campoOrdenamiento = "";
        int filaSeleccionada = 0;
        int celdaSeleccionada = 0;
        Boolean EstoyBuscando = false;
        Boolean ordenamiento = true;
        Dictionary<string, string> campos_tabla = new Dictionary<string, string>();

        public frmRubrosPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevoRubro();
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            nuevoRubro();
        }

        private void nuevoRubro()
        {
            mostrarFormularioNuevoRubro();
            llenarGrilla();
            grdRubros = fg.formatoGrilla(grdRubros, 1);
            grdRubros.Focus();
        }

        private void llenarGrilla()
        {
            try
            {
                if (EstoyBuscando == false)
                {
                    Entidades.Rubros entRubros = new ADBISYS.Entidades.Rubros();
                    ds = entRubros.obtenerRubros();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdRubros.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        grdRubros.DataSource = null;
                    }
                }
                else
                {
                    cadenaSql = "EXEC adp_busqueda_rubros";
                    cadenaSql = cadenaSql + " @tabla = " + fg.fcSql("RUBROS", "String");
                    cadenaSql = cadenaSql + ",@campo_tabla = " + fg.fcSql(obtenerCampoTabla().ToString(), "String");
                    cadenaSql = cadenaSql + ",@texto = " + fg.fcSql(textoAnterior, "String");

                    ds = objConect.ejecutarQuerySelect(cadenaSql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdRubros.DataSource = ds.Tables[0];
                    }
                }

                if ((filaSeleccionada > 0) && (celdaSeleccionada > 0) &&(filaSeleccionada <= grdRubros.Rows.Count - 1))
                {
                    grdRubros[celdaSeleccionada, filaSeleccionada].Selected = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void mostrarFormularioNuevoRubro()
        {
            celdaSeleccionada = grdRubros.CurrentCellAddress.X;
            filaSeleccionada = grdRubros.CurrentCellAddress.Y;
            frmNuevoRubro nuevoRubro = new frmNuevoRubro();
            nuevoRubro.ShowDialog();
        }

        private void frmRubrosPrincipal_Load(object sender, EventArgs e)
        {
            llenarGrilla();
            grdRubros = fg.formatoGrilla(grdRubros, 1);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificarRubro();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modificarRubro();
        }

        private void modificarRubro()
        {
            if (grdRubros.DataSource != null)
            {
                if (notFilaSeleccionada()) return;
                mostrarFormularioModificarProveedor();
                llenarGrilla();
                grdRubros = fg.formatoGrilla(grdRubros, 1);
                grdRubros.Focus();
            }
            else
            {
                MessageBox.Show("No existen Rubros.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnModificar.Focus();
            }
        }

        private void mostrarFormularioModificarProveedor()
        {
            celdaSeleccionada = grdRubros.CurrentCellAddress.X;
            filaSeleccionada = grdRubros.CurrentCellAddress.Y;

            frmModificarRubro modificarRubro = new frmModificarRubro();
            modificarRubro.rubro_codigo = grdRubros.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString();
            modificarRubro.rubro_descripcion = grdRubros.Rows[filaSeleccionada].Cells["DESCRIPCIÓN"].Value.ToString();
            modificarRubro.ShowDialog();
        }

        private bool notFilaSeleccionada()
        {
            try
            {
                if (grdRubros.SelectedRows.Count != 0)
                {
                    return false;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un Proveedor.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private void grdRubros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;
                modificarRubro();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminoRubro();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eliminoRubro();
        }

        private void eliminoRubro()
        {
            if (grdRubros.DataSource != null)
            {
                if (notFilaSeleccionada()) return;
                eliminarRubro();
                llenarGrilla();
                grdRubros = fg.formatoGrilla(grdRubros, 1);
                btnEliminar.Focus();
            }
            else
            {
                MessageBox.Show("No existen Rubros.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void eliminarRubro()
        {
            celdaSeleccionada = grdRubros.CurrentCellAddress.X;
            filaSeleccionada = grdRubros.CurrentCellAddress.Y;
            string descripcion_rubro = grdRubros.Rows[filaSeleccionada].Cells["DESCRIPCIÓN"].Value.ToString();
            string id_Rubro = grdRubros.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString();

            if (MessageBox.Show("¿Está seguro que desea eliminar el Rubro " + id_Rubro + "-" + descripcion_rubro + "?", "Eliminar Rubro.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Entidades.Rubros entRubros = new ADBISYS.Entidades.Rubros();

                    ds = entRubros.verificoRubroDelProveedor(id_Rubro);
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        MessageBox.Show("No se puede eliminar el Rubro " + id_Rubro + "-" + descripcion_rubro + " porque existe un proveedor que lo tiene asignado.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        entRubros.eliminarRubro(id_Rubro);
                        grdRubros.Focus();
                    }
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

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actualizarRubro();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarRubro();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscarRubro();
        }

        private void buscarRubro()
        {
            Entidades.Rubros entRubros = new ADBISYS.Entidades.Rubros();
            ds = entRubros.obtenerRubros();
            if (ds.Tables[0].Rows.Count > 0)
            {
                mostrarFormularioBusquedaRubros();
                llenarGrilla();
                grdRubros = fg.formatoGrilla(grdRubros, 1);
                grdRubros.Focus();
            }
            else
            {
                MessageBox.Show("No existen Rubros.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBuscar.Focus();
            }
        }

        private void mostrarFormularioBusquedaRubros()
        {
            frmBusquedaRubro buscarRubro = new frmBusquedaRubro();
            buscarRubro.campo = campoAnterior;
            buscarRubro.texto = textoAnterior;
            buscarRubro.estoyBuscando = EstoyBuscando;
            buscarRubro.ShowDialog();
            EstoyBuscando = buscarRubro.estoyBuscando;
            campoAnterior = buscarRubro.campo;
            textoAnterior = buscarRubro.texto;
            campos_tabla = buscarRubro.campos_tabla;
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

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            ordenamientoProveedor();
        }

        private void ordenarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ordenamientoProveedor();
        }

        private void ordenamientoProveedor()
        {
            if (grdRubros.DataSource != null)
            {
                mostrarFormularioOrdenarRubros();
                grdRubros.Focus();
            }
            else
            {
                MessageBox.Show("No existen Rubros.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOrdenar.Focus();
            }
        }

        private void mostrarFormularioOrdenarRubros()
        {
            frmOrdenarRubros ordenarRubros = new frmOrdenarRubros();
            ordenarRubros.Ascendente = ordenamiento;
            ordenarRubros.campo = campoOrdenamiento;
            ordenarRubros.ShowDialog();
            campoOrdenamiento = ordenarRubros.campo;
            ordenamiento = ordenarRubros.Ascendente;
            DataGridViewColumn columna = grdRubros.Columns[campoOrdenamiento];
            if (campoOrdenamiento != "")
            {
                if (ordenamiento == true)
                {
                    grdRubros.Sort(columna, ListSortDirection.Ascending);
                }
                if (ordenamiento == false)
                {
                    grdRubros.Sort(columna, ListSortDirection.Descending);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizarRubro();
        }

        private void actualizarRubro()
        {
            try
            {
                llenarGrilla();
                grdRubros = fg.formatoGrilla(grdRubros, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
