using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.Formularios.Articulos;
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        private void actualizar()
        {
            try
            {
                llenarGrilla();
                grdArticulos = fg.formatoGrilla(grdArticulos, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevoArticulo();
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            nuevoArticulo();
        }

        private void nuevoArticulo()
        {
            if (Properties.Settings.Default.UsuarioLogueado == "")
            {
                MessageBox.Show("Debe iniciar sesión.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            mostrarFormularioNuevoArticulo();
            llenarGrilla();
            grdArticulos = fg.formatoGrilla(grdArticulos, 1);
            grdArticulos.Focus();
        }

        private void mostrarFormularioNuevoArticulo()
        {
            celdaSeleccionada = grdArticulos.CurrentCellAddress.X;
            filaSeleccionada = grdArticulos.CurrentCellAddress.Y;
            frmNuevoArticulo nuevoArticulo = new frmNuevoArticulo();
            nuevoArticulo.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                modificarArticulo();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                modificarArticulo();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarArticulo()
        {
            if (grdArticulos.DataSource != null)
            {
                if (Properties.Settings.Default.UsuarioLogueado == "")
                {
                    MessageBox.Show("Debe iniciar sesión.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (notFilaSeleccionada()) return;
                mostrarFormularioModificarArticulo();
                llenarGrilla();
                grdArticulos = fg.formatoGrilla(grdArticulos, 1);
                grdArticulos.Focus();
            }
            else
            {
                MessageBox.Show("No existen Artículos.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnModificar.Focus();
            }
        }

        private void mostrarFormularioModificarArticulo()
        {
            try
            {
                celdaSeleccionada = grdArticulos.CurrentCellAddress.X;
                filaSeleccionada = grdArticulos.CurrentCellAddress.Y;

                frmModificarArticulo modificarArticulo = new frmModificarArticulo();
                modificarArticulo.articulo_codigo = grdArticulos.Rows[filaSeleccionada].Cells["CÓDIGO"].Value.ToString();
                modificarArticulo.articulo_desccripcion = grdArticulos.Rows[filaSeleccionada].Cells["DESCRIPCIÓN"].Value.ToString();
                modificarArticulo.articulo_precioVenta = grdArticulos.Rows[filaSeleccionada].Cells["PRECIO_VENTA"].Value.ToString();
                modificarArticulo.articulo_rubro = grdArticulos.Rows[filaSeleccionada].Cells["RUBRO"].Value.ToString();
                modificarArticulo.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool notFilaSeleccionada()
        {
            try
            {
                if (grdArticulos.SelectedRows.Count != 0)
                {
                    return false;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un Artículo.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private void grdArticulos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                modificarArticulo();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdArticulos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                {
                    e.SuppressKeyPress = true;
                    modificarArticulo();
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
