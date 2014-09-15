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

        #endregion

        #region InitailizeComponent

        public frmNuevaVenta()
        {
            InitializeComponent();
        }

        #endregion

        #region Buscar Articulo

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            //va a abrir un formulario nuevo donde vas a buscar al articulo 
            //una vez que lo encuentres se debe generar una nueva instancia de ese nuevo articulo
            //se llama a la funcion cargarArticuloEnGrilla(articulo) pasandole por parametro la nueva instancia
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
                    Entidades.Articulo articulo = new ADBISYS.Entidades.Articulo();
                    DsArticulo = articulo.obtenerArticulos(txtCodigoArticulo.Text);

                    if (DsArticulo.Tables[0].Rows.Count > 0)
                    {
                        guardarArticuloVentaTemporal(DsArticulo);
                    }
                    else
                    {
                        buscarArticuloYGuardarVentaTemporal();
                    }
                    cargarArticulosEnGrilla();
                    grdItemsCompra = fg.formatoGrilla(grdItemsCompra, 1);

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
            MessageBox.Show("NO ENCONTRE EL ARTICULO ENTONCES MUESTRO FORMULARIO DE BUSQUEDA DE ARTICULOS");
        }

        private void guardarArticuloVentaTemporal(DataSet DsArticulo)
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

        private void cargarArticulosEnGrilla()
        {
            try
            {
                //GUARDO EN LA GRILLA EL ARTICULO QUE RECIBO POR PARAMETRO
                //if (DsArticulo.Tables[0].Rows.Count > 0)
                //{
                //    grdItemsCompra.DataSource = DsArticulo.Tables[0];
                //}

                ConectarBD Conex = new ConectarBD();
                DataSet DsArticulosVenta = new DataSet();
                String sSQL;
                sSQL = "EXEC dbo.adp_obtenerArticulosVenta_Temporal ";
                DsArticulosVenta = Conex.ejecutarQuerySelect(sSQL);
                if (DsArticulosVenta.Tables[0].Rows.Count > 0)
                {
                    grdItemsCompra.DataSource = DsArticulosVenta.Tables[0];
                }

                actualizarPrecioTotalVenta(DsArticulosVenta);

            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

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

        #region Form_Load
        private void frmNuevaVenta_Load(object sender, EventArgs e)
        {
            try
            {
                ponerValoresEnDefault();
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
                grdItemsCompra.DataSource = null;
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
                Entidades.Venta Venta = new Entidades.Venta();
                Venta.guardarVentaYSusArticulos();
                Venta.actualizaMovimientoVentas(fg.appFechaSistema());
                ponerValoresEnDefault();
                MessageBox.Show("Venta confirmada correctamente.", "Venta Confirmada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            try
            {
                if (grdItemsCompra.RowCount > 0)
                {
                    Boolean deseaContinuar = (MessageBox.Show("Se cerrará el formulario sin confirmar la Venta. ¿Desea continuar de todos modos?", "Cancelar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);

                    if (!(deseaContinuar))
                    {
                        return;
                    }
                }

                Entidades.Venta Venta = new Entidades.Venta();
                Venta.borrarArticulosVenta_Temporal();
                this.Close();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        #endregion
    }
}
