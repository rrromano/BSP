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
    public partial class frmNuevaVenta : Form
    {

        #region Declaraciones

        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        Int32 filaSeleccionada = 0;
        Int32 columnaSeleccionada = 0;

        #endregion

        #region InitailizeComponent

        public frmNuevaVenta()
        {
            InitializeComponent();
        }

        #endregion

        #region Form_Load

        private void frmNuevaVenta_Load(object sender, EventArgs e)
        {
            try
            {
                ponerValoresEnDefault();
                actualizarGrilla();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        #endregion

        #region Buscar Articulo

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            //va a abrir un formulario nuevo donde vas a buscar al articulo 
            //una vez que lo encuentres se debe generar una nueva instancia de ese nuevo articulo
            //se llama a la funcion cargarArticuloEnGrilla(articulo) pasandole por parametro la nueva instancia

            buscquedaArticuloManual();
        }

        private void buscquedaArticuloManual()
        {
            try
            {
                frmBusquedaArticuloManual busqueda = new frmBusquedaArticuloManual();
                busqueda.ShowDialog();

                cargarArticulosEnGrilla();

                //=============================================================
                //IMPORTANTE: HAY QUE HACER QUE LA GRILLA SEA READONLY = FALSE
                //=============================================================
                grdItemsVenta = fg.formatoGrilla(grdItemsVenta, 9);
                //grdItemsVenta = fg.formatoGrilla(grdItemsVenta, 1);
                //=============================================================

                txtCodigoArticulo.Text = String.Empty;
                txtCodigoArticulo.Focus();

            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                fg.keyPressNumerosDecimales(e, txtCodigoArticulo);

                if (e.KeyChar == 13 && txtCodigoArticulo.Text.Length > 0 )
                {
                    //SI APRETO ENTER EJECUTO ESTE CODIGO

                    DataSet DsArticulo = new DataSet();
                    Entidades.Articulo Articulo = new Entidades.Articulo();
                    Entidades.Venta Venta = new Entidades.Venta();

                    DsArticulo = Articulo.obtenerArticulos(txtCodigoArticulo.Text);

                    if (DsArticulo.Tables[0].Rows.Count > 0)
                    {
                        Venta.guardarArticuloVentaTemporal(UInt64.Parse(txtCodigoArticulo.Text), Int32.Parse(txtCantidad.Text));
                    }
                    else
                    {
                        buscarArticuloYGuardarVentaTemporal();
                    }
                    cargarArticulosEnGrilla();
                    //grdItemsVenta = fg.formatoGrilla(grdItemsVenta, 9);

                    txtCodigoArticulo.Text = String.Empty;
                    txtCodigoArticulo.Focus();
                }
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

        private void guardarArticuloVentaTemporal()
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                String sSQL;
                sSQL = "EXEC dbo.adp_insertarArticuloVenta_Temporal ";
                sSQL = sSQL + " @Id_Articulo = " + fg.fcSql(txtCodigoArticulo.Text, "INTEGER");
                sSQL = sSQL + " ,@Cantidad = " + fg.fcSql(txtCantidad.Text,"INTEGER");

                Conex.ejecutarQuery(sSQL);
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        #endregion

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

                    for (int i = 0; i <= grdItemsVenta.Rows.Count - 1; i++)
                    {
                        grdItemsVenta.Rows[i].Cells["SELECCIONAR"].ReadOnly = false;
                    }
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
                    valorTotalCompra = valorTotalCompra + Double.Parse(dataRow["PRECIO_TOTAL"].ToString());
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

                //=============================================================
                //IMPORTANTE: HAY QUE HACER QUE LA GRILLA SEA READONLY = FALSE
                //=============================================================
                grdItemsVenta = fg.formatoGrilla(grdItemsVenta, 9);
                //grdItemsVenta = fg.formatoGrilla(grdItemsVenta, 1);
                //=============================================================

            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        #endregion

        #region Eliminar Articulo Venta

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
                        Venta.borrarArticulosVenta_Temporal(UInt64.Parse(grdItemsVenta.Rows[row.Index].Cells["ID"].Value.ToString()));
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

        #endregion

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

        #region TabIndexChanged
        private void btnConfirmarVenta_TabIndexChanged(object sender, EventArgs e)
        {
            txtCodigoArticulo.Focus();
        }
        private void groupBox6_TabIndexChanged(object sender, EventArgs e)
        {
            txtCodigoArticulo.Focus();
        }
        private void txtCantidad_TabIndexChanged(object sender, EventArgs e)
        {
            txtCodigoArticulo.Focus();
        }
        private void groupBox5_TabIndexChanged(object sender, EventArgs e)
        {
            txtCodigoArticulo.Focus();
        }
        private void btnSalir_TabIndexChanged(object sender, EventArgs e)
        {
            txtCodigoArticulo.Focus();
        }
        #endregion

        #region Confirmar Venta

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(validarConfirmarVenta())) { return; }
                Entidades.Venta Venta = new Entidades.Venta();
                Venta.guardarVentaYSusArticulos();
                ponerValoresEnDefault();
                fg.eliminarBotones(grdItemsVenta, "SELECCIONAR");
                Venta.actualizaMovimientoVentas(fg.appFechaSistema());
                frmVentasPrincipal form = new frmVentasPrincipal();

                MessageBox.Show("Venta confirmada correctamente.", "Venta Confirmada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private bool validarConfirmarVenta()
        {
            try
            {
                if (grdItemsVenta.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("No se puede confirmar la venta ya que no se han seleccionados los artículos correspondiente a la misma.", "Venta No Confirmada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
                return false;
            }
        }

        #endregion

        #region Click Grilla ItemsVenta

        private void grdItemsVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                filaSeleccionada = e.RowIndex;
                columnaSeleccionada = e.ColumnIndex;

                if (grdItemsVenta.Columns[columnaSeleccionada].Name != "SELECCIONAR")
                {
                    grdItemsVenta.Columns[columnaSeleccionada].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        //===================================================================================
        //MUY IMPORTANTE EL EVENTO CurrentCellDirtyStateChanged. NO ELIMINAR!
        //===================================================================================
        private void grdItemsVenta_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdItemsVenta.IsCurrentCellDirty)
                {
                    grdItemsVenta.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }
        //===================================================================================

        //===================================================================================
        //MUY IMPORTANTE EL EVENTO CellValueChanged. NO ELIMINAR!
        //===================================================================================
        private void grdItemsVenta_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }
        //===================================================================================

        #endregion

        #region Salir

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void frmNuevaVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!(Salir()))
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private bool Salir()
        {
            try
            {
                if (grdItemsVenta.RowCount > 0)
                {
                    Boolean deseaContinuar = (MessageBox.Show("Se cerrará el formulario sin confirmar la Venta. ¿Desea continuar de todos modos?", "Cancelar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);

                    if (!(deseaContinuar))
                    {
                        return false;
                    }
                }

                Entidades.Venta Venta = new Entidades.Venta();
                Venta.borrarArticulosVenta_Temporal();

                return true;
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
                return false;
            }
        }

        #endregion

    }
}
