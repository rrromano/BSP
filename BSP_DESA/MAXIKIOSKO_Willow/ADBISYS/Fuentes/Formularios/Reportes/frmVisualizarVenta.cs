using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.FuncionesGenerales;
using ADBISYS.Conexion;
using ADBISYS.Entidades;

namespace ADBISYS.Formularios.Reportes
{
    public partial class frmVisualizarVenta : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet Ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql = "";
        public string codigo_venta = "";
        
        public frmVisualizarVenta()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVisualizarVenta_Load(object sender, EventArgs e)
        {
            llenarCamposVenta();
            llenarGrilla();
        }

        private void llenarGrilla()
        {
            try
            {
                Entidades.Reportes entRepo = new ADBISYS.Entidades.Reportes();
                Ds = entRepo.obtenerArticulosVenta(codigo_venta);

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    grdArticulosVenta.DataSource = Ds.Tables[0];
                    grdArticulosVenta = fg.formatoGrilla(grdArticulosVenta, 1);
                }
                return;
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenarCamposVenta()
        {
            try
            {   
                Entidades.Reportes entRepo = new ADBISYS.Entidades.Reportes();
                Ds = entRepo.obtenerVenta(codigo_venta);
                txtCodigo.Text = Ds.Tables[0].Rows[0]["CÓDIGO"].ToString();
                txtImporte.Text = Ds.Tables[0].Rows[0]["IMPORTE"].ToString();
                txtCantArt.Text = Ds.Tables[0].Rows[0]["ARTÍCULOS"].ToString();
                txtFecha.Text = Ds.Tables[0].Rows[0]["FECHA_VENTA"].ToString();
                txtHora.Text = Ds.Tables[0].Rows[0]["HORA_VENTA"].ToString();
                return;
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
