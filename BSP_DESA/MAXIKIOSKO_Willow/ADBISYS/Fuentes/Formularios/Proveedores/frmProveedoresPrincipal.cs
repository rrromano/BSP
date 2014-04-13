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
        string cadenaSql = "";

        public frmProveedoresPrincipal()
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

        private void frmProveedoresPrincipal_Activated(object sender, EventArgs e)
        {
            llenarGrilla();
            grdProveedores = fg.formatoGrilla(grdProveedores, 1);
        }

        private void llenarGrilla()
        {
            try
            {
                cadenaSql = "EXEC adp_obtener_proveedores";
                ds = objConect.ejecutarQuerySelect(cadenaSql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdProveedores.DataSource = ds.Tables[0];
                }
                else
                {
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(notFilaSeleccionada()) return;
            mostrarFormularioModificarProveedor();
        }

        private void mostrarFormularioModificarProveedor()
        {

            int filaSeleccionada = grdProveedores.SelectedRows[0].Index;

            frmModificarProveedor modificarProveedor = new frmModificarProveedor();
            modificarProveedor.proveedor_codigo      = grdProveedores.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString();
            modificarProveedor.proveedor_rubro       = grdProveedores.Rows[filaSeleccionada].Cells["RUBRO"].Value.ToString();
            modificarProveedor.proveedor_nombre      = grdProveedores.Rows[filaSeleccionada].Cells["NOMBRE"].Value.ToString();
            modificarProveedor.proveedor_contacto    = grdProveedores.Rows[filaSeleccionada].Cells["CONTACTO"].Value.ToString();
            modificarProveedor.proveedor_direccion   = grdProveedores.Rows[filaSeleccionada].Cells["DIRECCIÓN"].Value.ToString();
            modificarProveedor.proveedor_localidad   = grdProveedores.Rows[filaSeleccionada].Cells["LOCALIDAD"].Value.ToString();
            modificarProveedor.proveedor_provincia   = grdProveedores.Rows[filaSeleccionada].Cells["PROVINCIA"].Value.ToString();
            modificarProveedor.proveedor_telefono    = grdProveedores.Rows[filaSeleccionada].Cells["TELÉFONO"].Value.ToString();
            modificarProveedor.proveedor_cuit        = grdProveedores.Rows[filaSeleccionada].Cells["CUIT"].Value.ToString();

            modificarProveedor.ShowDialog();
            
        }

        private bool notFilaSeleccionada()
        {
            try
            {
                if (grdProveedores.SelectedRows.Count != 0)
                {
                    return false;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un Proveedor.", "Modificar Proveedor.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnModificar.Focus();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostrarFormularioModificarProveedor();
        }

        private void grdProveedores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mostrarFormularioModificarProveedor();
        }
    }
}
