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

namespace ADBISYS.Formularios.Rubros
{
    public partial class frmOrdenarRubros : Form
    {
        ConectarBD objConect = new ConectarBD();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql = "";
        public string campo;
        public bool Ascendente = true;
        
        public frmOrdenarRubros()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmOrdenarRubros_Load(object sender, EventArgs e)
        {
            cargarComboCampo();

            if (campo != "")
            {
                cboCampo.Text = campo;
            }
            else
            {
                cboCampo.Text = "CÓDIGO";
            }

            if (Ascendente == true)
            {
                rbtnAscendente.Checked = true;
            }
            else
            {
                rbtnDescendente.Checked = true;
            }
        }

        private void cargarComboCampo()
        {
            try
            {
                DataSet ds = new DataSet();
                string campoSelec = cboCampo.Text;
                cboCampo.Items.Clear();

                Entidades.Rubros entRubros = new ADBISYS.Entidades.Rubros();
                ds = entRubros.obtenerCamposRubros();

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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validoCampos()) return;
            campo = cboCampo.Text;
            if (rbtnAscendente.Checked == true)
            {
                Ascendente = true;
            }
            if (rbtnDescendente.Checked == true)
            {
                Ascendente = false;
            }
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
            return false;
        }
    }
}
