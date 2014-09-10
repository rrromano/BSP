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

        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql, campoAnterior, textoAnterior, campoOrdenamiento = "";
        int filaSeleccionada = 0;
        int celdaSeleccionada = 0;
        Boolean EstoyBuscando = false;
        Boolean ordenamiento = true;
        Dictionary<string, string> campos_tabla = new Dictionary<string, string>();

        public frmVentasPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevaVenta();
        }

        private void nuevaVenta()
        {
            try
            {
                mostrarFormularioNuevaCompra();
                llenarGrilla();
                grdVentas = fg.formatoGrilla(grdVentas, 1);
                grdVentas.Focus();
            }
            catch (Exception e)
            {
                mostrarErrorTryCatch(e);
            }
        }

        private void mostrarErrorTryCatch(Exception e)
        {
            MessageBox.Show("Error: " + e.Message, "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mostrarFormularioNuevaCompra()
        {
            try
            {
                celdaSeleccionada = grdVentas.CurrentCellAddress.X;
                filaSeleccionada = grdVentas.CurrentCellAddress.Y;
                frmNuevaVenta nuevaVenta = new frmNuevaVenta();
                nuevaVenta.ShowDialog();
            }
            catch (Exception e)
            {
                mostrarErrorTryCatch(e);
            }
        }

        private void llenarGrilla()
        {
            try
            {
                if (EstoyBuscando == false)
                {
                    Entidades.Venta venta = new ADBISYS.Entidades.Venta();
                    ds = venta.obtenerVentas(fg.appFechaSistema());

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
                    cadenaSql = cadenaSql + ",@campo_tabla = " + fg.fcSql(obtenerCampoTabla().ToString(), "String");
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
                mostrarErrorTryCatch(e);
                return;
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
                mostrarErrorTryCatch(e);
                return "error";
            }
        }
    }
}
