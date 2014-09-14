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
    public partial class frmNuevaVenta : Form
    {
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

        public frmNuevaVenta()
        {
            InitializeComponent();
        }

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
                if (e.KeyChar == 13)
                {
                    //SI APRETO ENTER EJECUTO ESTE CODIGO

                    Entidades.Articulo articulo = new ADBISYS.Entidades.Articulo();
                    articulo = obtenerArticulo(txtCodigoArticulo.Text);
                    cargarArticuloEnGrilla(articulo);
                }
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        private void cargarArticuloEnGrilla(ADBISYS.Entidades.Articulo articulo)
        {
            //GUARDO EN LA GRILLA EL ARTICULO QUE RECIBO POR PARAMETRO
            throw new NotImplementedException();
        }

        private ADBISYS.Entidades.Articulo obtenerArticulo(String codigo)
        {
            String sSQL = "";
            DataSet Ds = new DataSet();

            sSQL = "EXEC dbo.adp_obtenerArticulo ";
            sSQL = sSQL + " @Id_Articulo = " + fg.fcSql(codigo, "STRING");

            Ds = venta.obtenerVentas(fg.appFechaSistema());
        }

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
            MessageBox.Show("Venta Ok");
        }
        #endregion
        #region Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
