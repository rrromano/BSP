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

        #region Declaraciones

        String rubroAnterior = "";
        Dictionary<int, string> colRubros = new Dictionary<int, string>();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

        #endregion

        #region InitializeComponent

        public frmActMasivaArticulo()
        {
            InitializeComponent();
            txtPrecioPorcentaje.Focus();
        }

        #endregion

        #region Load_Form

        private void frmActMasivaArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                cargarComboRubro();
                cargarComboPrecio();
                cargarComboAumentarDisminuir();
                RBporcentaje.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Cargar Combos

        private void cargarComboPrecio()
        {
            try
            {
                cboPrecioCV.Items.Clear();
                cboPrecioCV.Items.Add("Venta");
                cboPrecioCV.Items.Add("Compra");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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

                cboRubro.Items.Add("[TODOS]");

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

        #endregion

        #region Actualizacion Masiva

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(validarActualizacion())) { return; }

                if (deseaContinuar())
                {
                    actualizacionMasiva();
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void actualizacionMasiva()
        {
            try
            {
                ConectarBD objConect = new ConectarBD();
                String usuario = Properties.Settings.Default.UsuarioLogueado.ToString();
                String cadenaSql = "";

                cadenaSql = "exec dbo.adp_actualizacionMasiva_Articulo ";

                //============================================================================================================
                //ID RUBRO - ID RUBRO - ID RUBRO - ID RUBRO - ID RUBRO - ID RUBRO - ID RUBRO - ID RUBRO - ID RUBRO - ID RUBRO 
                //============================================================================================================
                if (cboRubro.Text.ToUpper() == "[TODOS]") { cadenaSql = cadenaSql + " @Articulo_IdRubro = null"; }
                else { cadenaSql = cadenaSql + " @Articulo_IdRubro = " + obtenerIdRubro().ToString(); }
                //============================================================================================================

                //============================================================================================================
                //PRECIOCV - PRECIOCV - PRECIOCV - PRECIOCV - PRECIOCV - PRECIOCV - PRECIOCV - PRECIOCV - PRECIOCV - PRECIOCV 
                //============================================================================================================
                if (cboPrecioCV.Text.ToUpper() == "VENTA") { cadenaSql = cadenaSql + " , @Articulo_Precio_CV = 1"; }
                else { cadenaSql = cadenaSql + " , @Articulo_Precio_CV = 0"; }
                //============================================================================================================

                //============================================================================================================
                //TIPO ACTUALIZACIÓN - TIPO ACTUALIZACIÓN - TIPO ACTUALIZACIÓN - TIPO ACTUALIZACIÓN - TIPO ACTUALIZACIÓN - TIPO 
                //============================================================================================================
                if (RBporcentaje.Checked) { cadenaSql = cadenaSql + " , @Articulo_TipoAct = 1"; } //ACTUALIZACIÓN POR PORCENTAJE
                else { cadenaSql = cadenaSql + " , @Articulo_TipoAct = 0";  } //ACTUALIZACIÓN POR VALOR
                //============================================================================================================

                //============================================================================================================
                //SUMA O RESTA - SUMA O RESTA - SUMA O RESTA - SUMA O RESTA - SUMA O RESTA - SUMA O RESTA - SUMA O RESTA - SUMA
                //============================================================================================================
                if (cboAumentarDisminuir.Text.ToUpper() == "AUMENTAR") { cadenaSql = cadenaSql + " , @Articulo_SumaResta = 1"; }
                else { cadenaSql = cadenaSql + " , @Articulo_SumaResta = 0"; } 
                //============================================================================================================

                //============================================================================================================
                //VALOR - VALOR - VALOR - VALOR - VALOR - VALOR - VALOR - VALOR - VALOR - VALOR - VALOR - VALOR - VALOR - VALOR
                //============================================================================================================
                cadenaSql = cadenaSql + " , @Articulo_Valor = " + txtPrecioPorcentaje.Text;
                //============================================================================================================

                //============================================================================================================
                //USUARIO - USUARIO - USUARIO - USUARIO - USUARIO - USUARIO - USUARIO - USUARIO - USUARIO - USUARIO - USUARIO 
                //============================================================================================================
                if (usuario != "") { cadenaSql = cadenaSql + " , @Articulo_Login = " + fg.fcSql(usuario, "String"); }
                //============================================================================================================

                objConect.ejecutarQuery(cadenaSql);

                MessageBox.Show("Actualización finalizada Correctamente.", "Actualización Masiva Artículos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarCampos();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void limpiarCampos()
        {
            cboRubro.Text = null;
            cboPrecioCV.Text = null;
            cboAumentarDisminuir.Text = null;
            txtPrecioPorcentaje.Text = "";
        }

        private int obtenerIdRubro()
        {
            try
            {
                foreach (KeyValuePair<int, string> rubro in colRubros)
                {
                    if (cboRubro.Text == rubro.Value)
                    {
                        return (rubro.Key);
                    }
                }
                return 0;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private bool deseaContinuar()
        {
            try
            {
                Boolean estaSeguro;

                if (cboAumentarDisminuir.Text.ToUpper() == "AUMENTAR")
                {
                    if (RBporcentaje.Checked)
                    {
                        estaSeguro = (MessageBox.Show("A continuación se aumentará un " + txtPrecioPorcentaje.Text + "% el precio de " + cboPrecioCV.Text + " de todos los artículos pertenecientes al rubro " + cboRubro.Text + ". ¿Desea continuar?", "Actualización Masiva de Artículos.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                    }
                    else
                    {
                        estaSeguro = (MessageBox.Show("A continuación se aumentará $" + txtPrecioPorcentaje.Text + " el precio de " + cboPrecioCV.Text + " de todos los artículos pertenecientes al rubro " + cboRubro.Text + ". ¿Desea continuar?", "Actualización Masiva de Artículos.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);                    
                    }
                }
                else
                {
                    if (RBporcentaje.Checked)
                    {
                        estaSeguro = (MessageBox.Show("A continuación se disminuirá un " + txtPrecioPorcentaje.Text + "% el precio de " + cboPrecioCV.Text + " de todos los artículos pertenecientes al rubro " + cboRubro.Text + ". ¿Desea continuar?", "Actualización Masiva de Artículos.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                    }
                    else
                    {
                        estaSeguro = (MessageBox.Show("A continuación se disminuirá $" + txtPrecioPorcentaje.Text + " el precio de " + cboPrecioCV.Text + " de todos los artículos pertenecientes al rubro " + cboRubro.Text + ". ¿Desea continuar?", "Actualización Masiva de Artículos.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                    }
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
                    MessageBox.Show("Debe seleccionar el Rubro a actualizar.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboRubro.Focus();
                    resultado = false;
                    return resultado;
                }

                if (cboPrecioCV.Text == "")
                {
                    MessageBox.Show("Debe seleccionar el Precio de Venta/Compra a actualizar.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboPrecioCV.Focus();
                    resultado = false;
                    return resultado;
                }

                if (cboAumentarDisminuir.Text == "")
                {
                    MessageBox.Show("Debe indicar si se debe aumentar o disminuir el precio de los artículos.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboAumentarDisminuir.Focus();
                    resultado = false;
                    return resultado;
                }

                if (txtPrecioPorcentaje.Text == "")
                {
                    MessageBox.Show("Debe indicar el Precio/Porcentaje.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPrecioPorcentaje.Focus();
                    resultado = false;
                    return resultado;
                }

                if (fg.esUnNumeroDecimal(txtPrecioPorcentaje.Text) == false)
                {
                    MessageBox.Show("El importe ingresado es inválido.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPrecioPorcentaje.Focus();
                    resultado = false;
                    return resultado;
                }
                if (double.Parse(txtPrecioPorcentaje.Text.ToString()) == 0)
                {
                    MessageBox.Show("El importe ingresado es inválido.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #endregion

        #region Controls KeyPress

        private void txtPrecioPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressNumerosDecimales(e, txtPrecioPorcentaje);
            fg.keyPressNumericoDiezDosDecimales(e, txtPrecioPorcentaje.Text.Length, txtPrecioPorcentaje.Text);
        }

        #endregion

        #region Salir/Cancelar

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}

