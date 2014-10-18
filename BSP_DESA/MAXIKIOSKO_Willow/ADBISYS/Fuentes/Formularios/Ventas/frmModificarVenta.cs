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

        Int32 filaSeleccionada = 0;
        Int32 columnaSeleccionada = 0;
        Entidades.Venta Venta = new Entidades.Venta();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

        #endregion

        #region InitializeComponent

        public frmModificarVenta()
        {
            InitializeComponent();
        }

        public frmModificarVenta(Entidades.Venta ventaModif)
        {
            InitializeComponent();
            Venta = ventaModif;
        }

        #endregion

        #region Form_Load

        private void frmModificarVenta_Load(object sender, EventArgs e)
        {
            try
            {
                txtDescripcion.Text = "";
                txtCantidadModif.Text = "";
                txtDescripcion.Enabled = false;
                txtCantidadModif.Enabled = false;
                chkAgregarItem.Checked = true;
                chkAgregarItem.Checked = false;
                lblTotalVenta.Text = Venta.m_importe.ToString();

                lblLeyendaModifVenta.Text = "Modificación Venta " + Venta.m_Id_Venta.ToString();

                //======================================================================================
                //VACÍO LA TABLA TMP_ARTICULOS_VENTAS **************************************************
                //======================================================================================
                Venta.borrarArticulosVenta_Temporal();

                //======================================================================================
                //SE LLENA LA TABLA TMP_ARTICULOS_VENTAS CON LOS REGISTROS DE LA TABLA ARTICULOS_VENTAS 
                //PARA LA VENTA CON ID_VENTA = M.ID_VENTA   *******************************************
                //======================================================================================
                llenarTablaTemporal();

                //======================================================================================
                //SE CARGAN EN LA GRILLA LOS REGISTROS DE LA TABLA TMP_ARTICULOS_VENTAS ****************
                //======================================================================================
                grdItemsVenta = fg.formatoGrilla(grdItemsVenta, 9);
                cargarArticulosEnGrilla();

                //======================================================================================
                //ACTUALIZACIÓN DEL PRECIO TOTAL DE LA VENTA *******************************************
                //======================================================================================
                //actualizarPrecioTotalVenta();

                txtCodigoArticulo.Text = String.Empty;
                txtCodigoArticulo.Focus();

            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        #endregion

        #region Buscar Artículo

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

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                fg.keyPressNumerosDecimales(e, txtCodigoArticulo);

                if (e.KeyChar == 13 && txtCodigoArticulo.Text.Length > 0)
                {
                    //SI APRETO ENTER EJECUTO ESTE CODIGO

                    DataSet DsArticulo = new DataSet();
                    Entidades.Articulo Articulo = new Entidades.Articulo();
                    //Entidades.Venta Venta = new Entidades.Venta();

                    if (txtCantidad.Text.Trim() == "") { txtCantidad.Text = "1"; }

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
                    txtCantidad.Text = "1";
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
                sSQL = sSQL + " ,@Cantidad = " + fg.fcSql(txtCantidad.Text, "INTEGER");

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

                actualizarPrecioTotalVenta();
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

        #endregion

        #region Actualizar Precio Total Venta

        private void actualizarPrecioTotalVenta()
        {
            try
            {
                Double valorTotalCompra;
                valorTotalCompra = 0;

                foreach (DataGridViewRow row in this.grdItemsVenta.Rows)
                {
                    if (row.Cells["PRECIO_TOTAL"].Value != null)
                    { 
                        valorTotalCompra = valorTotalCompra + Double.Parse(row.Cells["PRECIO_TOTAL"].Value.ToString());
                    }
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

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                btnEliminarArticulo.Enabled = false;
                txtDescripcion.Enabled = false;
                txtCantidadModif.Enabled = false;
                btnAceptar.Enabled = false;
                txtDescripcion.Text = "";
                txtCantidadModif.Text = "";

                Boolean encontreUnRegistros = false;
                //Entidades.Venta Venta = new Entidades.Venta();

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
                actualizarPrecioTotalVenta();

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

        #region Confirmar Modificación Venta

        private void btnConfirmarModificacionVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(validarConfirmarModificacionVenta())) { return; }

                actualizarVenta();

                this.Close();

            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void actualizarVenta()
        {
            try
            {
                //================================================================================
                //PASO 1: SE BORRAN LOS REGISTROS DE LA TABLA TMP_ARTICULOS_VENTAS ***************
                //================================================================================
                Venta.borrarArticulosVenta_Temporal();

                //================================================================================
                //PASO 2: SE INSERTAN ARTICULOS DE LA GRILLA EN LA TABLA TMP_ARTICULOS_VENTAS ****
                //================================================================================
                foreach (DataGridViewRow row in grdItemsVenta.Rows)
                {
                    UInt64 IdArticulo = UInt64.Parse(row.Cells["CÓDIGO"].Value.ToString());
                    Int32 Cantidad = Int32.Parse(row.Cells["CANTIDAD"].Value.ToString());

                    Venta.guardarArticuloVentaTemporal(IdArticulo, Cantidad);
                }

                //================================================================================
                //PASO 3: SE ACTUALIZA LA VENTA QUE TIENE ID_VENTA = VENTA.M_ID ******************
                //================================================================================
                Venta.actualizarVenta(Venta.m_Id_Venta);

                //================================================================================
                //PASO 4: SE PONEN TODOS LOS VALORES EN DEFAULT **********************************
                //================================================================================
                ponerValoresEnDefault();

                //================================================================================
                //PASO 5: SE ELIMINA EL CAMPO SELECCIONAR ****************************************
                //================================================================================
                fg.eliminarBotones(grdItemsVenta, "SELECCIONAR");

                //================================================================================
                //PASO 6: SE ACTUALIZA EL MOVIMIENTO DE CAJA 3 - VENTAS **************************
                //================================================================================
                Venta.actualizaMovimientoVentas(fg.appFechaSistema());

                //MessageBox.Show("Venta modificada correctamente.", "Venta Modificada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private bool validarConfirmarModificacionVenta()
        {
            try
            {
                if (grdItemsVenta.Rows.Count == 0)
                {
                    MessageBox.Show("No se puede confirmar la venta ya que no se han seleccionado los artículos correspondiente a la misma.", "Venta No Confirmada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return true;

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

                if (filaSeleccionada == -1) { return; }

                if (grdItemsVenta.Columns[columnaSeleccionada].Name != "SELECCIONAR")
                {
                    grdItemsVenta.Columns[columnaSeleccionada].ReadOnly = true;

                    txtDescripcion.Enabled = false;
                    txtCantidadModif.Enabled = true;
                    btnAceptar.Enabled = true;
                    txtDescripcion.Text = grdItemsVenta.Rows[filaSeleccionada].Cells["DESCRIPCIÓN"].Value.ToString();
                    txtCantidadModif.Text = grdItemsVenta.Rows[filaSeleccionada].Cells["CANTIDAD"].Value.ToString();
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

        private void frmModificarVenta_FormClosing(object sender, FormClosingEventArgs e)
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
                    Boolean deseaContinuar = (MessageBox.Show("Se cerrará el formulario sin confirmar la modificación de la Venta. ¿Desea continuar de todos modos?", "Cancelar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);

                    if (!(deseaContinuar))
                    {
                        return false;
                    }
                }

                //Entidades.Venta Venta = new Entidades.Venta();
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

        private void chkAgregarItem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (chkAgregarItem.Checked)
                {
                    txtCantidad.Enabled = true;
                    txtCodigoArticulo.Enabled = true;
                    btnBuscarArticulo.Enabled = true;
                    btnEliminarArticulo.Enabled = false;
                }
                else
                {
                    txtCantidad.Enabled = false;
                    txtCodigoArticulo.Enabled = false;
                    btnBuscarArticulo.Enabled = false;
                    btnEliminarArticulo.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Double valor_Unitario = Double.Parse(grdItemsVenta.Rows[filaSeleccionada].Cells["PRECIO_UNIDAD"].Value.ToString());
                Double precio_total = valor_Unitario * Int32.Parse(txtCantidadModif.Text);

                grdItemsVenta.Rows[filaSeleccionada].Cells["DESCRIPCIÓN"].Value = txtDescripcion.Text;
                grdItemsVenta.Rows[filaSeleccionada].Cells["CANTIDAD"].Value = txtCantidadModif.Text;
                grdItemsVenta.Rows[filaSeleccionada].Cells["PRECIO_TOTAL"].Value = precio_total.ToString();

                txtDescripcion.Enabled = false;
                txtCantidadModif.Enabled = false;
                btnAceptar.Enabled = false;
                txtDescripcion.Text = "";
                txtCantidadModif.Text = "";

                Venta.borrarArticulosVenta_Temporal();

                foreach (DataGridViewRow row in grdItemsVenta.Rows)
                {
                    UInt64 IdArticulo = UInt64.Parse(row.Cells["CÓDIGO"].Value.ToString());
                    Int32 Cantidad = Int32.Parse(row.Cells["CANTIDAD"].Value.ToString());

                    Venta.guardarArticuloVentaTemporal(IdArticulo, Cantidad);
                }

                actualizarPrecioTotalVenta();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressNumeros(e);
        }

        private void grdItemsVenta_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                filaSeleccionada = grdItemsVenta.CurrentCellAddress.Y;
                columnaSeleccionada = grdItemsVenta.CurrentCellAddress.X;

                if (filaSeleccionada == -1) { return; }

                if (grdItemsVenta.Columns[columnaSeleccionada].Name != "SELECCIONAR")
                {
                    grdItemsVenta.Columns[columnaSeleccionada].ReadOnly = true;

                    txtDescripcion.Enabled = false;
                    txtCantidadModif.Enabled = true;
                    btnAceptar.Enabled = true;
                    txtDescripcion.Text = grdItemsVenta.Rows[filaSeleccionada].Cells["DESCRIPCIÓN"].Value.ToString();
                    txtCantidadModif.Text = grdItemsVenta.Rows[filaSeleccionada].Cells["CANTIDAD"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

    }
}
