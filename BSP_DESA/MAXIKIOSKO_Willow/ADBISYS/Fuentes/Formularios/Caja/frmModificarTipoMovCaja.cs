using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.Entidades;
using ADBISYS.FuncionesGenerales;
using ADBISYS.Conexion;

namespace ADBISYS.Formularios.Caja
{
    public partial class frmModificarTipoMovCaja : Form
    {

        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        Dictionary<int, string> EntradaSalida = new Dictionary<int, string>();
        TipoMovimientoCaja TipoMovCaja = new TipoMovimientoCaja();

        public frmModificarTipoMovCaja()
        {
            InitializeComponent();
        }

        public frmModificarTipoMovCaja(TipoMovimientoCaja tipoMovCaja)
        {
            try
            {
                TipoMovCaja = tipoMovCaja;
                InitializeComponent();
                cargarComboEntradaSalida();
                cargarTipoMovimientoCaja();
                habilitarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void habilitarCampos()
        {
            try
            {

                if (int.Parse(txtCodigo.Text) > 6)
                {
                    cboEntradaSalida.Enabled = true;
                    txtDescripcion.Enabled = true;
                    btnAceptar.Enabled = true;
                    btnLimpiar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarTipoMovimientoCaja()
        {
            try
            {
                txtCodigo.Text = TipoMovCaja.m_ID_TipoMovimiento.ToString();
                txtDescripcion.Text = TipoMovCaja.m_Descripcion;
                if (TipoMovCaja.m_entradaSalida == 1) { cboEntradaSalida.Text = "INGRESO"; } else { cboEntradaSalida.Text = "SALIDA"; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarComboEntradaSalida()
        {
            try
            {
                cboEntradaSalida.Items.Add("INGRESO");
                cboEntradaSalida.Items.Add("SALIDA");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fiValidarModificacion())
                {
                    if (existeTipoMovimientoCaja()) return;
                    actualizarTipoMovimientoCaja();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool existeTipoMovimientoCaja()
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                DataSet Ds = new DataSet();
                String CadenaSql;

                CadenaSql = "EXEC adp_verificoExistencia_TipoMovCaja";
                CadenaSql = CadenaSql + " @Codigo = " + fg.fcSql(txtCodigo.Text, "INTEGER");
                CadenaSql = CadenaSql + ",@Descripcion = " + fg.fcSql(txtDescripcion.Text, "STRING");

                Ds = Conex.ejecutarQuerySelect(CadenaSql);

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Ya existe un Tipo de Movimiento " + fg.fcSql(txtDescripcion.Text, "STRING") + ".", "Alta de Tipo de Movimiento Caja.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescripcion.Focus();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private void actualizarTipoMovimientoCaja()
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                String Usuario = Properties.Settings.Default.UsuarioLogueado.ToString();
                String sSQL;

                sSQL = "EXEC dbo.adp_actualizar_TipoMovCaja ";
                sSQL = sSQL + " @ID_TIPOMOVIMIENTO = " + TipoMovCaja.m_ID_TipoMovimiento;
                sSQL = sSQL + " ,@DESCRIPCION = " + fg.fcSql(txtDescripcion.Text.Trim(), "STRING");
                if (cboEntradaSalida.Text == "INGRESO") { sSQL = sSQL + " ,@INGRESO_SALIDA = 1"; } else { sSQL = sSQL + " ,@INGRESO_SALIDA = 0"; }
                sSQL = sSQL + " ,@LOGIN_MODIF = " + fg.fcSql(Usuario, "STRING");

                Conex.ejecutarQuery(sSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool fiValidarModificacion()
        {
            try
            {
                if (cboEntradaSalida.Text == "")
                {
                    MessageBox.Show("Debe seleccionar si el Tipo de Movimiento es de Ingreso o Salida.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescripcion.Focus();
                    return false;
                }
                
                if (txtDescripcion.Text.Trim() == "")
                {
                    MessageBox.Show("La descripción del Tipo de Movimiento es obligatoria.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescripcion.Focus();
                    return false;
                }
                
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Enabled) { txtDescripcion.Text = String.Empty; }
            if (cboEntradaSalida.Enabled) { cboEntradaSalida.Text = null; cboEntradaSalida.Focus(); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = fg.keyPressMayusculas(e);
        }
    }
}
