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
        #endregion

        public frmBusquedaArticuloManual()
        {
            InitializeComponent();
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
                DataSet DsArticulo = new DataSet();
                Entidades.Articulo articulo = new ADBISYS.Entidades.Articulo();
                DsArticulo = articulo.BusquedaManualArticulo(txtDescripcionArticulo.Text);

                if (DsArticulo.Tables[0].Rows.Count > 0)
                {
                    grdResultados.DataSource = DsArticulo.Tables[0];
                    actualizarGrillaResultados();
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
                //foreach (DataGridViewRow row in grdResultados.Rows.)
                //{ 
                
                //}
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
                //DataGridViewRow row = grdResultados.SelectedRow;
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }
    }
}
