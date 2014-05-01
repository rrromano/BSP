using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.Formularios.Proveedores;
using ADBISYS.Conexion;
using ADBISYS.Entidades;

namespace ADBISYS.Formularios.Proveedores
{
    public partial class frmProveedoresPrincipal : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql, campoAnterior, textoAnterior, campoOrdenamiento = "";
        int filaSeleccionada = 0;
        int celdaSeleccionada = 0;
        Boolean EstoyBuscando =false;
        Boolean ordenamiento = true;
        Dictionary<string, string> campos_tabla = new Dictionary<string, string>();

        public frmProveedoresPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevoProveedor();
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            nuevoProveedor();
        }

        private void nuevoProveedor()
        {
            mostrarFormularioNuevoProveedor();
            llenarGrilla();
            grdProveedores = fg.formatoGrilla(grdProveedores, 1);
            grdProveedores.Focus();
        }

        private void mostrarFormularioNuevoProveedor()
        {
            celdaSeleccionada = grdProveedores.CurrentCellAddress.X;
            filaSeleccionada = grdProveedores.CurrentCellAddress.Y;
            frmNuevoProveedor nuevoProveedor = new frmNuevoProveedor();
            nuevoProveedor.ShowDialog();
        }

        private void llenarGrilla()
        {
            try
            {
                if (EstoyBuscando == false)
                {
                    Entidades.Proveedores entProveedores = new ADBISYS.Entidades.Proveedores();
                    ds = entProveedores.obtenerProveedores();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdProveedores.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        grdProveedores.DataSource = null;
                    }
                }
                else
                {
                    cadenaSql = "EXEC adp_busqueda_proveedores";
                    cadenaSql = cadenaSql + " @tabla = " + fg.fcSql("PROVEEDORES","String");
                    cadenaSql = cadenaSql + ",@campo_tabla = " + fg.fcSql(obtenerCampoTabla().ToString(),"String");
                    cadenaSql = cadenaSql + ",@texto = " + fg.fcSql(textoAnterior, "String");

                    ds = objConect.ejecutarQuerySelect(cadenaSql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdProveedores.DataSource = ds.Tables[0];
                    }
                    
                }

                if ((filaSeleccionada > 0) && (celdaSeleccionada > 0) && (filaSeleccionada <= grdProveedores.Rows.Count - 1))
                {
                    grdProveedores[celdaSeleccionada, filaSeleccionada].Selected = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificarProveedor();
        }

        private void modificarProveedor()
        {
            if (grdProveedores.DataSource != null)
            {
                if (notFilaSeleccionada()) return;
                mostrarFormularioModificarProveedor();
                llenarGrilla();
                grdProveedores = fg.formatoGrilla(grdProveedores, 1);
                grdProveedores.Focus();
            }
            else
            {
                MessageBox.Show("No existen Proveedores.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnModificar.Focus();
            }
        }

        private void mostrarFormularioModificarProveedor()
        {

            celdaSeleccionada = grdProveedores.CurrentCellAddress.X;
            filaSeleccionada = grdProveedores.CurrentCellAddress.Y;

            frmModificarProveedor modificarProveedor = new frmModificarProveedor();
            modificarProveedor.proveedor_codigo      = grdProveedores.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString();
            modificarProveedor.proveedor_rubro       = grdProveedores.Rows[filaSeleccionada].Cells["RUBRO"].Value.ToString();
            modificarProveedor.proveedor_nombre      = grdProveedores.Rows[filaSeleccionada].Cells["NOMBRE"].Value.ToString();
            modificarProveedor.proveedor_contacto    = grdProveedores.Rows[filaSeleccionada].Cells["CONTACTO"].Value.ToString();
            modificarProveedor.proveedor_direccion   = grdProveedores.Rows[filaSeleccionada].Cells["DIRECCIÓN"].Value.ToString();
            modificarProveedor.proveedor_localidad   = grdProveedores.Rows[filaSeleccionada].Cells["LOCALIDAD"].Value.ToString();
            modificarProveedor.proveedor_provincia   = grdProveedores.Rows[filaSeleccionada].Cells["PROVINCIA"].Value.ToString();
            modificarProveedor.proveedor_telefono    = grdProveedores.Rows[filaSeleccionada].Cells["TELÉFONO"].Value.ToString();
            modificarProveedor.proveedor_cuit        = grdProveedores.Rows[filaSeleccionada].Cells["CUIT"].Value.ToString();

            modificarProveedor.ShowDialog();            
        }

        private bool notFilaSeleccionada()
        {
            try
            {
                if (grdProveedores.SelectedRows.Count != 0)
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

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modificarProveedor();
        }

        private void grdProveedores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            modificarProveedor();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminoProveedor();
        }

        private void eliminoProveedor()
        {
            if (grdProveedores.DataSource != null)
            {
                if (notFilaSeleccionada()) return;
                eliminarProveedor();
                llenarGrilla();
                grdProveedores = fg.formatoGrilla(grdProveedores, 1);
                btnEliminar.Focus();
            }
            else
            {
                MessageBox.Show("No existen Proveedores.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void eliminarProveedor()
        {
            celdaSeleccionada = grdProveedores.CurrentCellAddress.X;
            filaSeleccionada = grdProveedores.CurrentCellAddress.Y;
            string nombre_Proveedor = grdProveedores.Rows[filaSeleccionada].Cells["NOMBRE"].Value.ToString();
            string id_Proveedor = grdProveedores.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString();

            if (MessageBox.Show("¿Está seguro que desea eliminar el Proveedor " + id_Proveedor + "-" + nombre_Proveedor + "?", "Eliminar Proveedor.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Entidades.Proveedores entProveedores = new ADBISYS.Entidades.Proveedores();
                    entProveedores.eliminarProveedor(id_Proveedor);
                    grdProveedores.Focus();
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

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eliminoProveedor();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarProveedor();
        }

        private void buscarProveedor()
        {
            Entidades.Proveedores entProveedores = new ADBISYS.Entidades.Proveedores();
            ds = entProveedores.obtenerProveedores();
            if(ds.Tables[0].Rows.Count > 0)
            {
                mostrarFormularioBusquedaProveedor();
                llenarGrilla();
                grdProveedores = fg.formatoGrilla(grdProveedores, 1);
                grdProveedores.Focus();
            }
            else
            {
                MessageBox.Show("No existen Proveedores.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBuscar.Focus();
            }
        }

        private void mostrarFormularioBusquedaProveedor()
        {
            frmBusquedaProveedor buscarProveedor = new frmBusquedaProveedor();
            buscarProveedor.campo = campoAnterior;
            buscarProveedor.texto = textoAnterior;
            buscarProveedor.estoyBuscando = EstoyBuscando;
            buscarProveedor.ShowDialog();
            EstoyBuscando = buscarProveedor.estoyBuscando;
            campoAnterior = buscarProveedor.campo;
            textoAnterior = buscarProveedor.texto;
            campos_tabla = buscarProveedor.campos_tabla;
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
            buscarProveedor();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            ordenamientoProveedor();
        }

        private void ordenamientoProveedor()
        {    
            if (grdProveedores.DataSource != null)
            {
                mostrarFormularioOrdenarProveedor();
                grdProveedores.Focus();
            }
            else
            {
                MessageBox.Show("No existen Proveedores.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOrdenar.Focus();
            }
        }

        private void mostrarFormularioOrdenarProveedor()
        {
            frmOrdenarProveedor ordenarProveedores = new frmOrdenarProveedor();
            ordenarProveedores.Ascendente = ordenamiento;
            ordenarProveedores.campo = campoOrdenamiento;
            ordenarProveedores.ShowDialog();
            campoOrdenamiento = ordenarProveedores.campo;
            ordenamiento = ordenarProveedores.Ascendente;
            DataGridViewColumn columna = grdProveedores.Columns[campoOrdenamiento];
            if (campoOrdenamiento != "")
            {
                if (ordenamiento == true)
                {
                    grdProveedores.Sort(columna, ListSortDirection.Ascending);
                }
                if (ordenamiento == false)
                {
                    grdProveedores.Sort(columna, ListSortDirection.Descending);
                }
            }
        }

        private void frmProveedoresPrincipal_Load(object sender, EventArgs e)
        {
            llenarGrilla(); 
            grdProveedores = fg.formatoGrilla(grdProveedores, 1); 
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

        private void grdProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;
                modificarProveedor();
            }
        }

        private void ordenarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ordenamientoProveedor();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llenarGrilla();
        }
    }
}
