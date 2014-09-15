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

        #region fmrVentasPrincipal Declaraciones
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

        #region Llegar Grilla
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
                    cadenaSql = cadenaSql + " @tabla = " + fg.fcSql("COMPRAS", "String");
                    cadenaSql = cadenaSql + ",@campo_tabla = " + fg.fcSql(fg.obtenerCampoTabla(campoAnterior, campos_tabla).ToString(), "String");
                    cadenaSql = cadenaSql + ",@texto = " + fg.fcSql(textoAnterior, "String").Replace(",", ".");

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
            nuevaVenta();
        }

        private void nuevaVenta()
        {
            try
            {
                mostrarFormularioNuevaVenta();
                llenarGrilla();
                grdVentas = fg.formatoGrilla(grdVentas, 1);
                grdVentas.Focus();
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

    }
}
