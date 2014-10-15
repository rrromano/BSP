using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADBISYS.Formularios.Ventas
{
    public partial class frmBusquedaArticuloManual : Form
    {
        #region Declaraciones

        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        Int32 filaSeleccionada = 0;
        Int32 columnaSeleccionada = 0;

        #endregion

        public frmBusquedaArticuloManual()
        {
            InitializeComponent();
            txtDescripcionArticulo.Focus();
        }

        private void frmBusquedaArticuloManual_Load(object sender, EventArgs e)
        {
            try
            {
                actualizarGrillaResultados();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void txtArticulo_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtDescripcionArticulo.Text.Trim() == "") 
                {
                    grdResultados.DataSource = null;
                    return;
                }

                DataSet DsArticulo = new DataSet();
                Entidades.Articulo articulo = new ADBISYS.Entidades.Articulo();
                DsArticulo = articulo.BusquedaManualArticulo(txtDescripcionArticulo.Text);

                if (DsArticulo.Tables[0].Rows.Count > 0)
                {
                    grdResultados.DataSource = DsArticulo.Tables[0];
                    actualizarGrillaResultados();
                }
                else
                {
                    grdResultados.DataSource = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void actualizarGrillaResultados()
        {
            try
            {
                grdResultados = fg.formatoGrilla(grdResultados, 2);
                txtDescripcionArticulo.Focus();
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

                if (!(validarBusqueda())) { return; }

                //MessageBox.Show("Seleccionó ID: " + DsArt.Tables[0].Rows[0]["CÓDIGO"].ToString() + " DESCRIPCION: " + DsArt.Tables[0].Rows[0]["DESCRIPCIÓN"].ToString());

                Entidades.Articulo Articulo = new Entidades.Articulo();
                Entidades.Venta Venta = new Entidades.Venta();

                DataSet DsArticulo = new DataSet();
                
                UInt64 IdArticulo;
                Int32 Cantidad;

                IdArticulo = UInt64.Parse(grdResultados.Rows[filaSeleccionada].Cells["ID"].Value.ToString());

                DsArticulo = Articulo.obtenerArticulos(IdArticulo.ToString());


                if (DsArticulo.Tables[0].Rows.Count > 0)
                {
                    IdArticulo = UInt64.Parse(DsArticulo.Tables[0].Rows[0]["CÓDIGO"].ToString());
                    Cantidad = Int32.Parse(txtCantidad.Text);
                    Venta.guardarArticuloVentaTemporal(IdArticulo, Cantidad);
                }
                else
                {
                    MessageBox.Show("Artículo inexistente en la Base de Datos");
                }

                this.Close();

            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private bool validarBusqueda()
        {
            try
            {
                if (grdResultados.Rows.Count == 0)
                {
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

        private void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                Formularios.Articulos.frmNuevoArticulo nuevoArt = new ADBISYS.Formularios.Articulos.frmNuevoArticulo();
                nuevoArt.ShowDialog();
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void grdResultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                filaSeleccionada = e.RowIndex;
                columnaSeleccionada = e.ColumnIndex;
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void grdResultados_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Int32 selectedCellCount = grdResultados.GetCellCount(DataGridViewElementStates.Selected);
                if (selectedCellCount > 0)
                {
                    filaSeleccionada = grdResultados.SelectedCells[1].RowIndex;
                    columnaSeleccionada = grdResultados.SelectedCells[1].ColumnIndex;
                }
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }
    }
}
