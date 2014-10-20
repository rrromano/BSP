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

namespace ADBISYS.Formularios.Ventas
{
    public partial class frmVentasPrincipal : Form
    {

        #region Declaraciones
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        String cadenaSql, campoAnterior, textoAnterior, campoOrdenamiento = "";
        Int32 filaSeleccionada = 0;
        Int32 celdaSeleccionada = 0;
        Boolean EstoyBuscando = false;
        Boolean ordenamiento = true;
        Dictionary<string, string> campos_tabla = new Dictionary<string, string>();
        #endregion

        #region InitializeComponent
        public frmVentasPrincipal()
        {
            InitializeComponent();
        }
        #endregion

        #region Load_Form
        private void frmVentasPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                actualizarGrilla();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }
        #endregion

        #region Actualizar Grilla

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarGrilla();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void actualizarGrilla()
        {
            try
            {
                llenarGrilla();
                grdVentas = fg.formatoGrilla(grdVentas, 1);
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        #endregion

        #region Llenar Grilla

        private void llenarGrilla()
        {
            try
            {
                if (EstoyBuscando == false)
                {
                    Entidades.Venta venta = new ADBISYS.Entidades.Venta();
                    List<Venta> ventasDelDia = new List<Venta>();

                    //ventasDelDia = venta.obtenerVentas(fg.appFechaSistema());

                    ds = venta.obtenerVentas(fg.appFechaSistema());

                    //if (ventasDelDia.Count > 0)
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdVentas.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        grdVentas.DataSource = null;
                    }
                }
                else
                {
                    cadenaSql = "EXEC adp_busqueda_ventas";
                    cadenaSql = cadenaSql + " @tabla = " + fg.fcSql("VENTAS", "String");
                    cadenaSql = cadenaSql + ",@campo_tabla = " + fg.fcSql(fg.obtenerCampoTabla(campoAnterior, campos_tabla).ToString(), "String");
                    cadenaSql = cadenaSql + ",@texto = " + fg.fcSql(textoAnterior, "String").Replace(",", ".");
                    cadenaSql = cadenaSql + ",@fecha = " + fg.fcSql(fg.appFechaSistema().ToString(), "Datetime");

                    ds = objConect.ejecutarQuerySelect(cadenaSql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdVentas.DataSource = ds.Tables[0];
                    }
                }

                if ((filaSeleccionada > 0) && (celdaSeleccionada > 0) && (filaSeleccionada <= grdVentas.Rows.Count - 1))
                {
                    grdVentas[celdaSeleccionada, filaSeleccionada].Selected = true;
                }
            }
            catch (Exception e)
            {
                fg.mostrarErrorTryCatch(e);
                return;
            }
        }

        #endregion

        #region Nueva Venta

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                abrirFormularioNuevaVenta();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void abrirFormularioNuevaVenta()
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmNuevaVenta);

            if (frm != null)
            {
                frm.WindowState = FormWindowState.Normal;
                frm.BringToFront();
                return;
            }
            else
            {
                nuevaVenta();
            }
        }

        private void nuevaVenta()
        {
            try
            {
                mostrarFormularioNuevaVenta();
                llenarGrilla();
                grdVentas = fg.formatoGrilla(grdVentas, 1);
                //grdVentas.Focus();
            }
            catch (Exception e)
            {
                fg.mostrarErrorTryCatch(e);
            }
        }

        private void mostrarFormularioNuevaVenta()
        {
            try
            {
                celdaSeleccionada = grdVentas.CurrentCellAddress.X;
                filaSeleccionada = grdVentas.CurrentCellAddress.Y;
                frmNuevaVenta nuevaVenta = new frmNuevaVenta();
                nuevaVenta.ShowDialog();
                nuevaVenta.Select();

                this.btnActualizar.PerformClick();
            }
            catch (Exception e)
            {
                fg.mostrarErrorTryCatch(e);
            }
        }

        #endregion

        #region Eliminar Venta

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                eliminarVenta();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void eliminarVenta()
        {
            try
            {
                if (grdVentas.DataSource != null)
                {
                    if (notFilaSeleccionada()) return;

                    celdaSeleccionada = grdVentas.CurrentCellAddress.X;
                    filaSeleccionada = grdVentas.CurrentCellAddress.Y;

                    String codigo = grdVentas.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString();
                    String importe = grdVentas.Rows[filaSeleccionada].Cells["IMPORTE"].Value.ToString();
                    String fecha_modif = grdVentas.Rows[filaSeleccionada].Cells["FECHA_MODIF"].Value.ToString();

                    if (MessageBox.Show("¿Está seguro que desea eliminar la Venta " + codigo + " del día " + fecha_modif + " con importe: $" + importe + "?", "Eliminar Compra.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Entidades.Venta Venta = new Venta();
                        Venta.eliminarVenta(codigo);
                        Venta.actualizaMovimientoVentas(fg.appFechaSistema());
                        grdVentas.Focus();
                    }
                    else
                    {
                        btnEliminar.Focus();
                    }

                    llenarGrilla();
                    grdVentas = fg.formatoGrilla(grdVentas, 1);
                    btnEliminar.Focus();
                }
                else
                {
                    MessageBox.Show("No existen Compras.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        #endregion

        #region Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                modificarVenta();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void modificarVenta()
        {
            try
            {
                if (grdVentas.DataSource != null)
                {
                    if (Properties.Settings.Default.UsuarioLogueado == "")
                    {
                        MessageBox.Show("Debe iniciar sesión.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }                    
                    if (notFilaSeleccionada()) return;
                    mostrarFormularioModificarVenta();
                    llenarGrilla();
                    grdVentas = fg.formatoGrilla(grdVentas, 1);
                    grdVentas.Focus();
                }
                else
                {
                    MessageBox.Show("No se han realizado ventas en el día de hoy.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnModificar.Focus();
                }
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void mostrarFormularioModificarVenta()
        {
            try
            {
                celdaSeleccionada = grdVentas.CurrentCellAddress.X;
                filaSeleccionada = grdVentas.CurrentCellAddress.Y;
                
                Entidades.Venta ventaModif = new Entidades.Venta();

                ventaModif.m_Id_Venta = UInt64.Parse(grdVentas.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString());
                ventaModif.cargarDatosVenta();

                frmModificarVenta modificarVenta = new frmModificarVenta(ventaModif);
                modificarVenta.ShowDialog();
                this.btnActualizar.PerformClick();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                abrirFormularioNuevaVenta();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                modificarVenta();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                eliminarVenta();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarVenta();
        }

        private void grdVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                modificarVenta();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void grdVentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;
                modificarVenta();
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarGrilla();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscarVenta();
        }

        private void buscarVenta()
        {
            Entidades.Venta entVenta = new ADBISYS.Entidades.Venta();
            ds = entVenta.obtenerVentas(fg.appFechaSistema());
            if (ds.Tables[0].Rows.Count > 0)
            {
                mostrarFormularioBusquedaVentas();
                llenarGrilla();
                grdVentas = fg.formatoGrilla(grdVentas, 1);
                grdVentas.Focus();
            }
            else
            {
                MessageBox.Show("No existen Ventas.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBuscar.Focus();
            }
        }

        private void mostrarFormularioBusquedaVentas()
        {
            frmBusquedaVenta buscarVenta = new frmBusquedaVenta();
            buscarVenta.campo = campoAnterior;
            buscarVenta.texto = textoAnterior;
            buscarVenta.estoyBuscando = EstoyBuscando;
            buscarVenta.ShowDialog();
            EstoyBuscando = buscarVenta.estoyBuscando;
            campoAnterior = buscarVenta.campo;
            textoAnterior = buscarVenta.texto;
            campos_tabla = buscarVenta.campos_tabla;
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
            ordenamientoVentas();
        }

        private void ordenarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ordenamientoVentas();
        }

        private void ordenamientoVentas()
        {
            if (grdVentas.DataSource != null)
            {
                mostrarFormularioOrdenarVentas();
                grdVentas.Focus();
            }
            else
            {
                MessageBox.Show("No existen Ventas.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOrdenar.Focus();
            }
        }

        private void mostrarFormularioOrdenarVentas()
        {
            frmOrdenarVentas ordenarVentas = new frmOrdenarVentas();
            ordenarVentas.Ascendente = ordenamiento;
            ordenarVentas.campo = campoOrdenamiento;
            ordenarVentas.ShowDialog();
            campoOrdenamiento = ordenarVentas.campo;
            ordenamiento = ordenarVentas.Ascendente;
            DataGridViewColumn columna = grdVentas.Columns[campoOrdenamiento];
            if (campoOrdenamiento != "")
            {
                if (ordenamiento == true)
                {
                    grdVentas.Sort(columna, ListSortDirection.Ascending);
                }
                if (ordenamiento == false)
                {
                    grdVentas.Sort(columna, ListSortDirection.Descending);
                }
            }
        }
    }
}
