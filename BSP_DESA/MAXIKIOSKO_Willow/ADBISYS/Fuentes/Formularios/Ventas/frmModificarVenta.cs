using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.Conexion;

namespace ADBISYS.Formularios.Ventas
{
    public partial class frmModificarVenta : Form
    {
        #region Declaraciones

        Entidades.Venta Venta = new Entidades.Venta();

        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

        #endregion

        public frmModificarVenta()
        {
            InitializeComponent();
        }

        public frmModificarVenta(Entidades.Venta ventaModif)
        {
            InitializeComponent();
            Venta = ventaModif;
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            buscquedaArticuloManual();
        }

        private void buscquedaArticuloManual()
        {
            try
            {
                frmBusquedaArticuloManual busqueda = new frmBusquedaArticuloManual();
                busqueda.ShowDialog();

                cargarArticulosEnGrilla();
                grdItemsVenta = fg.formatoGrilla(grdItemsVenta, 9);

                txtCodigoArticulo.Text = String.Empty;
                txtCodigoArticulo.Focus();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void buscarArticuloYGuardarVentaTemporal()
        {
            try
            {
                buscquedaArticuloManual();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        #region Cargar Artículo en Grilla

        private void cargarArticulosEnGrilla()
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                DataSet DsArticulosVenta = new DataSet();
                String sSQL;
                DataGridView aux = new DataGridView();

                sSQL = "EXEC dbo.adp_obtenerArticulosVenta_Temporal ";
                DsArticulosVenta = Conex.ejecutarQuerySelect(sSQL);

                if (DsArticulosVenta.Tables[0].Rows.Count > 0)
                {
                    if (grdItemsVenta.Rows.Count != 0)
                    {
                        aux.DataSource = grdItemsVenta.DataSource;
                    }

                    grdItemsVenta.DataSource = null;
                    grdItemsVenta = fg.agregarBotones(grdItemsVenta, "SELECCIONAR");
                    grdItemsVenta.DataSource = DsArticulosVenta.Tables[0];
                }
                else
                {
                    grdItemsVenta = fg.eliminarBotones(grdItemsVenta, "SELECCIONAR");
                    grdItemsVenta.DataSource = null;
                }

                actualizarPrecioTotalVenta(DsArticulosVenta);
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        #endregion

        #region Actualizar Precio Total Venta

        private void actualizarPrecioTotalVenta(DataSet DsArticulosVenta)
        {
            try
            {
                Double valorTotalCompra;
                valorTotalCompra = 0;

                foreach (DataRow dataRow in DsArticulosVenta.Tables[0].Rows)
                {
                    valorTotalCompra = valorTotalCompra + Double.Parse(dataRow["PRECIO_VENTA"].ToString());
                }

                lblTotalVenta.Text = fg.DevolverCadenaCon2Decimales(valorTotalCompra.ToString());

            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        #endregion

        #region Actualizar Grilla

        private void actualizarGrilla()
        {
            try
            {
                if (grdItemsVenta.Rows.Count == 0)
                {
                    grdItemsVenta.DataSource = null;
                }

                grdItemsVenta = fg.formatoGrilla(grdItemsVenta, 9);
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        #endregion

        #region Eliminar Articulo Venta

        private void grdItemsVenta_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (grdItemsVenta.Columns[e.ColumnIndex].Name == "SELECCIONAR")
            {

                DataGridViewRow row = grdItemsVenta.Rows[e.RowIndex]; // Se toma la fila seleccionada
                DataGridViewCheckBoxCell cellSelecion = row.Cells["SELECCIONAR"] as DataGridViewCheckBoxCell; // Se selecciona la celda del checkbox

                Boolean HayArticuloSeleccionado = false;

                foreach (DataGridViewRow fila in grdItemsVenta.Rows)
                {
                    DataGridViewCheckBoxCell celda = fila.Cells["SELECCIONAR"] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(celda.Value)) //Columna de checks
                    {
                        HayArticuloSeleccionado = true;
                    }
                }

                if (Convert.ToBoolean(cellSelecion.Value)) // Se valida si esta checkeada
                {
                    btnEliminarArticulo.Enabled = true;
                }
                else
                {
                    if (!(HayArticuloSeleccionado))
                    {
                        btnEliminarArticulo.Enabled = false;
                    }
                }
            }
        }
        #endregion

        private void guardarArticuloVentaTemporal()
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                String sSQL;
                sSQL = "EXEC dbo.adp_insertarArticuloVenta_Temporal ";
                sSQL = sSQL + " @Id_Articulo = " + fg.fcSql(txtCodigoArticulo.Text, "INTEGER");
                sSQL = sSQL + " ,@Cantidad = " + fg.fcSql(txtCantidad.Text, "INTEGER");

                Conex.ejecutarQuery(sSQL);
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void frmModificarVenta_Load(object sender, EventArgs e)
        {
            try
            {
                lblTotalVenta.Text = Venta.m_importe.ToString();
                llenarTablaTemporal();
                cargarArticulosEnGrilla();
                grdItemsVenta = fg.formatoGrilla(grdItemsVenta, 9);

                txtCodigoArticulo.Text = String.Empty;
                txtCodigoArticulo.Focus();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void llenarTablaTemporal()
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                String sSQL;
                sSQL = "EXEC dbo.adp_InsertaTodosLosArticulosDeVenta_Temporal ";
                sSQL = sSQL + " @Id_Venta= " + fg.fcSql(this.Venta.m_Id_Venta.ToString(), "INTEGER");

                Conex.ejecutarQuery(sSQL);
            }
            catch (Exception)
            {
            }
        }

        #region Poner Valores En Default
        private void ponerValoresEnDefault()
        {
            try
            {
                txtCantidad.Text = "1";
                lblTotalVenta.Text = "0,00";
                grdItemsVenta.DataSource = null;
                txtCodigoArticulo.Focus();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }
        #endregion

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean encontreUnRegistros = false;
                Entidades.Venta Venta = new Entidades.Venta();

                foreach (DataGridViewRow row in grdItemsVenta.Rows)
                {
                    DataGridViewCheckBoxCell celda = row.Cells["SELECCIONAR"] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(celda.Value))
                    {
                        encontreUnRegistros = true;
                        Venta.borrarArticulosVenta_Temporal(Int64.Parse(grdItemsVenta.Rows[row.Index].Cells["ID"].Value.ToString()));
                        //grdItemsVenta.Rows.RemoveAt(row.Index);
                        //i = 0;
                    }
                }

                grdItemsVenta.DataSource = null;
                cargarArticulosEnGrilla();
                actualizarGrilla();

                if (!(encontreUnRegistros))
                {
                    MessageBox.Show("Debe seleccionar el artículo que desea cancelar.", "Cancelar Artículo Venta.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                if (grdItemsVenta.Rows.Count == 0)
                {
                    Venta.borrarArticulosVenta_Temporal();
                    btnEliminarArticulo.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void btnConfirmarModificacionVenta_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Venta Venta = new Entidades.Venta();
                Venta.guardarVentaYSusArticulos();
                ponerValoresEnDefault();
                fg.eliminarBotones(grdItemsVenta, "SELECCIONAR");
                Venta.actualizaMovimientoVentas(fg.appFechaSistema());
                MessageBox.Show("Venta confirmada correctamente.", "Venta Confirmada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Venta Venta = new Entidades.Venta();
                Venta.borrarArticulosVenta_Temporal();
                this.Close();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }
    }
}
