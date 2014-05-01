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
        MovimientoCaja movCaja = new MovimientoCaja();

        public frmModificarTipoMovCaja()
        {
            InitializeComponent();
        }

        public frmModificarTipoMovCaja(MovimientoCaja movimientoCaja)
        {
            try
            {
                //movCaja = movimientoCaja;
                //InitializeComponent();
                //cargarComboEntradaSalida();
                //cargarMovimientoCaja();
                //habilitarCampos();
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
                    actualizarTipoMovimientoCaja();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarTipoMovimientoCaja()
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                DateTime Dia = fg.appFechaSistema();
                String Usuario = Properties.Settings.Default.UsuarioLogueado.ToString();
                String sSQL;

                movCaja.m_Id_tipoMovimiento = movCaja.ObtenerId_TipoMovimiento(movCaja.m_Id);

                sSQL = "EXEC dbo.adp_actualizar_TipoMovCaja ";
                sSQL = sSQL + " @ID_TIPOMOVIMIENTO = " + movCaja.m_Id_tipoMovimiento;
                sSQL = sSQL + " ,@DESCRIPCION = " + fg.fcSql(txtDescripcion.Text, "STRING");

                if (cboEntradaSalida.Text == "INGRESO") { sSQL = sSQL + " ,@INGRESO_SALIDA = 1"; } else { sSQL = sSQL + " ,@INGRESO_SALIDA = 0"; }

                sSQL = sSQL + " ,@FECHA_MODIF = " + fg.fcSql(Dia.ToString(), "DATETIME");
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
            if (cboEntradaSalida.Enabled) { cboEntradaSalida.Text = String.Empty; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
