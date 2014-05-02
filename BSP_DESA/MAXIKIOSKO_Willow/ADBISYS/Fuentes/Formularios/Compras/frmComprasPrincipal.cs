using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.Formularios.Compras;
using ADBISYS.Conexion;
using ADBISYS.Entidades;

namespace ADBISYS.Formularios.Compras
{
    public partial class frmComprasPrincipal : Form
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

        public frmComprasPrincipal()
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

        private void frmComprasPrincipal_Load(object sender, EventArgs e)
        {
            llenarGrilla();
            grdCompras = fg.formatoGrilla(grdCompras, 1);
        }

        private void llenarGrilla()
        {
            try
            {
                if (EstoyBuscando == false)
                {
                    Entidades.Compras entCompras = new ADBISYS.Entidades.Compras();
                    ds = entCompras.obtenerCompras(fg.appFechaSistema());

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdCompras.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        grdCompras.DataSource = null;
                    }
                }
                else
                {
                    cadenaSql = "EXEC adp_busqueda_compras";
                    cadenaSql = cadenaSql + " @tabla = " + fg.fcSql("COMPRAS", "String");
                    cadenaSql = cadenaSql + ",@campo_tabla = " + fg.fcSql(obtenerCampoTabla().ToString(), "String");
                    cadenaSql = cadenaSql + ",@texto = " + fg.fcSql(textoAnterior, "String").Replace(",",".");

                    ds = objConect.ejecutarQuerySelect(cadenaSql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdCompras.DataSource = ds.Tables[0];
                    }

                }

                if ((filaSeleccionada > 0) && (celdaSeleccionada > 0) && (filaSeleccionada <= grdCompras.Rows.Count - 1))
                {
                    grdCompras[celdaSeleccionada, filaSeleccionada].Selected = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevaCompra();
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            nuevaCompra();
        }

        private void nuevaCompra()
        {
            mostrarFormularioNuevaCompra();
            llenarGrilla();
            grdCompras = fg.formatoGrilla(grdCompras, 1);
            grdCompras.Focus();
        }

        private void mostrarFormularioNuevaCompra()
        {
            celdaSeleccionada = grdCompras.CurrentCellAddress.X;
            filaSeleccionada = grdCompras.CurrentCellAddress.Y;
            frmNuevaCompra nuevaCompra = new frmNuevaCompra();
            nuevaCompra.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificarCompra();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modificarCompra();
        }

        private void modificarCompra()
        {
            if (grdCompras.DataSource != null)
            {
                if (notFilaSeleccionada()) return;
                mostrarFormularioModificarProveedor();
                llenarGrilla();
                grdCompras = fg.formatoGrilla(grdCompras, 1);
                grdCompras.Focus();
            }
            else
            {
                MessageBox.Show("No existen Compras.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnModificar.Focus();
            }
        }

        private void mostrarFormularioModificarProveedor()
        {
            celdaSeleccionada = grdCompras.CurrentCellAddress.X;
            filaSeleccionada = grdCompras.CurrentCellAddress.Y;

            frmModificarCompra modificarCompra = new frmModificarCompra();
            modificarCompra.compra_codigo = grdCompras.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString();
            modificarCompra.compra_proveedor = grdCompras.Rows[filaSeleccionada].Cells["PROVEEDOR"].Value.ToString();
            modificarCompra.compra_importe = grdCompras.Rows[filaSeleccionada].Cells["IMPORTE"].Value.ToString().Replace(",",".");

            modificarCompra.ShowDialog();
        }

        private bool notFilaSeleccionada()
        {
            try
            {
                if (grdCompras.SelectedRows.Count != 0)
                {
                    return false;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una Compra.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private void grdCompras_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            modificarCompra();
        }

        private void grdCompras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;
                modificarCompra();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminoCompra();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eliminoCompra();
        }

        private void eliminoCompra()
        {
            if (grdCompras.DataSource != null)
            {
                if (notFilaSeleccionada()) return;
                eliminarCompra();
                llenarGrilla();
                grdCompras = fg.formatoGrilla(grdCompras, 1);
                btnEliminar.Focus();
            }
            else
            {
                MessageBox.Show("No existen Compras.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void eliminarCompra()
        {
            celdaSeleccionada = grdCompras.CurrentCellAddress.X;
            filaSeleccionada = grdCompras.CurrentCellAddress.Y;
            string compra_proveedor = grdCompras.Rows[filaSeleccionada].Cells["PROVEEDOR"].Value.ToString();
            string id_compra = grdCompras.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString();
            string importe = grdCompras.Rows[filaSeleccionada].Cells["IMPORTE"].Value.ToString();

            if (MessageBox.Show("¿Está seguro que desea eliminar la Compra " + id_compra + " correspondiente al Proveedor " + compra_proveedor + " con importe: $" + importe + "?", "Eliminar Compra.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Entidades.Compras entCompras = new ADBISYS.Entidades.Compras();
                    entCompras.eliminarCompra(id_compra);
                    entCompras.actualizar_moovimiento_compras(fg.appFechaSistema());
                    grdCompras.Focus();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarCompra();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscarCompra();
        }

        private void buscarCompra()
        {
            Entidades.Compras entCompras = new ADBISYS.Entidades.Compras();
            ds = entCompras.obtenerCompras(fg.appFechaSistema());
            if (ds.Tables[0].Rows.Count > 0)
            {
                mostrarFormularioBusquedaCompras();
                llenarGrilla();
                grdCompras = fg.formatoGrilla(grdCompras, 1);
                grdCompras.Focus();
            }
            else
            {
                MessageBox.Show("No existen Compras.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBuscar.Focus();
            }
        }

        private void mostrarFormularioBusquedaCompras()
        {
            frmBusquedaCompra buscarCompra = new frmBusquedaCompra();
            buscarCompra.campo = campoAnterior;
            buscarCompra.texto = textoAnterior;
            buscarCompra.estoyBuscando = EstoyBuscando;
            buscarCompra.ShowDialog();
            EstoyBuscando = buscarCompra.estoyBuscando;
            campoAnterior = buscarCompra.campo;
            textoAnterior = buscarCompra.texto;
            campos_tabla  = buscarCompra.campos_tabla;
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
            ordenamientoCompras();
        }

        private void ordenarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ordenamientoCompras();
        }

        private void ordenamientoCompras()
        {
            if (grdCompras.DataSource != null)
            {
                mostrarFormularioOrdenarCompras();
                grdCompras.Focus();
            }
            else
            {
                MessageBox.Show("No existen Compras.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOrdenar.Focus();
            }
        }

        private void mostrarFormularioOrdenarCompras()
        {
            frmOrdenarCompras ordenarCompras = new frmOrdenarCompras();
            ordenarCompras.Ascendente = ordenamiento;
            ordenarCompras.campo = campoOrdenamiento;
            ordenarCompras.ShowDialog();
            campoOrdenamiento = ordenarCompras.campo;
            ordenamiento = ordenarCompras.Ascendente;
            DataGridViewColumn columna = grdCompras.Columns[campoOrdenamiento];
            if (campoOrdenamiento != "")
            {
                if (ordenamiento == true)
                {
                    grdCompras.Sort(columna, ListSortDirection.Ascending);
                }
                if (ordenamiento == false)
                {
                    grdCompras.Sort(columna, ListSortDirection.Descending);
                }
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            llenarGrilla();
        }

    }
}
