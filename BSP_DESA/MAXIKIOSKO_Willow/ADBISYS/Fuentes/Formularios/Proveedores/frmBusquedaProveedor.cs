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

namespace ADBISYS.Formularios.Proveedores
{
    public partial class frmBusquedaProveedor : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql,campoAnt,textoAnt = "";
        public string campoBusqueda, textoBusqueda = "";

        public frmBusquedaProveedor()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmBusquedaProveedor_Activated(object sender, EventArgs e)
        {
            cargarComboCampo();
            chkBusqueda.Checked = false;
        }

        private void cargarComboCampo()
        {
            try
            {
                string campoSelec = cboCampo.Text;
                cboCampo.Items.Clear();

                cadenaSql = "EXEC adp_cboBusqueda_proveedores";
                ds = objConect.ejecutarQuerySelect(cadenaSql);

                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    cboCampo.Items.Add(dataRow["CAMPO"]);
                }

                cboCampo.Text = campoSelec;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = fg.keyPressMayusculas(e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //RR 2014-04-17
            if (validoCampos()) return;
            campoBusqueda = cboCampo.Text;
            textoBusqueda = txtTexto.Text;
            this.Hide();
        }

        private bool validoCampos()
        {
            if (cboCampo.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Campo.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboCampo.Focus();
                return true;
            }

            if (txtTexto.Text == "")
            {
                MessageBox.Show("El campo Texto a buscar es obligatorio.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTexto.Focus();
                return true;
            }
            return false;
        }

        private void chkBusqueda_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBusqueda.Checked == true)
            {
                campoAnt = cboCampo.Text;
                textoAnt = txtTexto.Text;
                cboCampo.Items.Clear();
                txtTexto.Text = "";
                cboCampo.Enabled = false;
                txtTexto.Enabled = false;
            }
            else
            {
                cboCampo.Enabled = true;
                txtTexto.Enabled = true;
                cargarComboCampo();
                cboCampo.Text = campoAnt;
                txtTexto.Text = textoAnt;
            }
        }

    }
}
