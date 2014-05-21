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
using ADBISYS.Formularios.Rubros;
using ADBISYS.Entidades;

namespace ADBISYS.Formularios.Articulos
{
    public partial class frmActMasivaArticulo : Form
    {
        String rubroAnterior = "";
        Dictionary<int, string> colRubros = new Dictionary<int, string>();

        public frmActMasivaArticulo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void salir()
        {
            try
            {
                Boolean estaSeguro = (MessageBox.Show("¿Está seguro que desea cancelar la actualización masiva de artículos?", "Actualización Masiva de Artículos.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                if (estaSeguro) this.Close();
            }

            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosPrincipal frmArticulos = new frmArticulosPrincipal();
            frmArticulos.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!(validarActualizacion())) { return; }

            if (deseaContinuar())
            {
                actualizacionMasiva();
            }
            
        }

        private void actualizacionMasiva()
        {
            try
            {

            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool deseaContinuar()
        {
            try
            {
                Boolean estaSeguro;

                if (cboAumentarDisminuir.Text.ToUpper() == "AUMENTAR")
                {
                    estaSeguro = (MessageBox.Show("A continuación se aumentará $" + txtPrecioPorcentaje.Text + " a todos los artículos pertenecientes al rubro " + cboRubro.Text + ". ¿Desea continuar?", "Actualización Masiva de Artículos.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                }
                else
                {
                    estaSeguro = (MessageBox.Show("A continuación se aumentará un " + txtPrecioPorcentaje.Text + "% a todos los artículos pertenecientes al rubro " + cboRubro.Text + ". ¿Desea continuar?", "Actualización Masiva de Artículos.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                }

                return estaSeguro;
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private Boolean validarActualizacion()
        {
            try
            {
                Boolean resultado = true;

                if (cboRubro.Text == "")
                {
                    MessageBox.Show("Debe seleccionar el Rubro a actualizar.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboRubro.Focus();
                    resultado = false;
                    return resultado;
                }

                if (cboAumentarDisminuir.Text == "")
                {
                    MessageBox.Show("Debe indicar si se debe aumentar o disminuir el precio de los artículos.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboAumentarDisminuir.Focus();
                    resultado = false;
                    return resultado;
                }

                if (txtPrecioPorcentaje.Text == "")
                {
                    MessageBox.Show("Debe indicar el porcentaje/precio a aumentar", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPrecioPorcentaje.Focus();
                    resultado = false;
                    return resultado;
                }

                //if (RBporcentaje.Checked)
                //{
                //    if (int.Parse(txtPrecioPorcentaje.Text) > 100 || int.Parse(txtPrecioPorcentaje.Text) < 0)
                //    {
                //        MessageBox.Show("Debe indicar un porcentaje válido entre 0 y 100.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //        txtPrecioPorcentaje.Focus();
                //        resultado = false;
                //        return resultado;
                //    }
                //}

                return resultado;
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            mostrarFormularioNuevoRubro();
        }

        private void mostrarFormularioNuevoRubro()
        {
            try
            {
                frmNuevoRubro nuevoRubro = new frmNuevoRubro();
                nuevoRubro.ShowDialog();
                cargarComboRubro();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarComboRubro()
        {
            try
            {
                DataSet Ds = new DataSet();
                rubroAnterior = cboRubro.Text;
                cboRubro.Items.Clear();
                colRubros.Clear();

                Entidades.Proveedores entProveedores = new Entidades.Proveedores();
                Ds = entProveedores.obtenerInfoRubros();

                foreach (DataRow dataRow in Ds.Tables[0].Rows)
                {
                    cboRubro.Items.Add(dataRow["DESCRIPCION"]);
                    colRubros.Add(int.Parse(dataRow["ID_RUBRO"].ToString()), dataRow["DESCRIPCION"].ToString());
                }
                cboRubro.Text = rubroAnterior;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmActMasivaArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                cargarComboRubro();
                cargarComboAumentarDisminuir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarComboAumentarDisminuir()
        {
            try
            {
                cboAumentarDisminuir.Items.Add("Aumentar");
                cboAumentarDisminuir.Items.Add("Disminuir");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void RBporcentaje_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lblInformacion.Text = "A continuación indique el porcentaje que \ndesea aumentar o disminuir.";
                lblPrecioPorcentaje.Text = "Porcentaje";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RBPrecio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lblInformacion.Text = "A continuación indique la cantidad (pesos)\nque desea aumentar o disminuir.";
                lblPrecioPorcentaje.Text = "Precio";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
