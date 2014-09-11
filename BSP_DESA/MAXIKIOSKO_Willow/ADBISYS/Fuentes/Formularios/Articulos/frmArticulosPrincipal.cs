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

namespace ADBISYS.Formularios.Articulos
{
    public partial class frmArticulosPrincipal : Form
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

        public frmArticulosPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmArticulosPrincipal_Load(object sender, EventArgs e)
        {
            llenarGrilla();
            grdArticulos = fg.formatoGrilla(grdArticulos, 1);
        }

        private void llenarGrilla()
        {
            try
            {
                if (EstoyBuscando == false)
                {
                    Entidades.Articulo entArticulo = new ADBISYS.Entidades.Articulo();
                    ds = entArticulo.obtenerArticulos();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdArticulos.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        grdArticulos.DataSource = null;
                    }
                }
                //else
                //{
                //    cadenaSql = "EXEC adp_busqueda_compras";
                //    cadenaSql = cadenaSql + " @tabla = " + fg.fcSql("COMPRAS", "String");
                //    cadenaSql = cadenaSql + ",@campo_tabla = " + fg.fcSql(obtenerCampoTabla().ToString(), "String");
                //    cadenaSql = cadenaSql + ",@texto = " + fg.fcSql(textoAnterior, "String").Replace(",", ".");

                //    ds = objConect.ejecutarQuerySelect(cadenaSql);
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        grdArticulos.DataSource = ds.Tables[0];
                //    }

                //}

                if ((filaSeleccionada > 0) && (celdaSeleccionada > 0) && (filaSeleccionada <= grdArticulos.Rows.Count - 1))
                {
                    grdArticulos[celdaSeleccionada, filaSeleccionada].Selected = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
