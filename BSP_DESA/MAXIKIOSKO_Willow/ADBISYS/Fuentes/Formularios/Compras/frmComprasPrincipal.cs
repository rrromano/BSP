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

namespace ADBISYS.Formularios.Compras
{
    public partial class frmComprasPrincipal : Form
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

        public frmComprasPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmComprasPrincipal_Load(object sender, EventArgs e)
        {
            llenarGrilla();
            grdProveedores = fg.formatoGrilla(grdProveedores, 1);
        }

        private void llenarGrilla()
        {
            try
            {
                if (EstoyBuscando == false)
                {
                    Entidades.Compras entCompras = new ADBISYS.Entidades.Compras();
                    ds = entCompras.obtenerCompras();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdProveedores.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        grdProveedores.DataSource = null;
                    }
                }
                else
                {
                    //cadenaSql = "EXEC adp_busqueda_proveedores";
                    //cadenaSql = cadenaSql + " @tabla = " + fg.fcSql("PROVEEDORES", "String");
                    //cadenaSql = cadenaSql + ",@campo_tabla = " + fg.fcSql(obtenerCampoTabla().ToString(), "String");
                    //cadenaSql = cadenaSql + ",@texto = " + fg.fcSql(textoAnterior, "String");

                    //ds = objConect.ejecutarQuerySelect(cadenaSql);
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    grdProveedores.DataSource = ds.Tables[0];
                    //}

                }

                if ((filaSeleccionada > 0) && (celdaSeleccionada > 0) && (filaSeleccionada <= grdProveedores.Rows.Count - 1))
                {
                    grdProveedores[celdaSeleccionada, filaSeleccionada].Selected = true;
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
