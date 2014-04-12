using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.Formularios.Proveedores;
using ADBISYS.Conexion;

namespace ADBISYS.Formularios.Proveedores
{
    public partial class frmProveedoresPrincipal : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

        public frmProveedoresPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            mostrarFormularioNuevoProveedor();
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mostrarFormularioNuevoProveedor();
        }

        private void mostrarFormularioNuevoProveedor()
        {
            frmNuevoProveedor nuevoProveedor = new frmNuevoProveedor();
            nuevoProveedor.ShowDialog();
        }

        //private void frmProveedoresPrincipal_Activated(object sender, EventArgs e)
        //{
        //    llenaGrilla();
        //}

        //private void llenarGrilla()
        //{
 
        //}
    }
}
