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
    public partial class frmModificarMovimientoCaja : Form
    {
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        Dictionary<int, string> EntradaSalida = new Dictionary<int, string>();
        MovimientoCaja MovimientoCaja = new MovimientoCaja();
        
        public frmModificarMovimientoCaja()
        {
            InitializeComponent();
        }

        public frmModificarMovimientoCaja(MovimientoCaja MovCaja)
        {
            try
            {
                MovimientoCaja = MovCaja;
                InitializeComponent();
                cargarComboEntradaSalida();
                cargarMovimientoCaja();
                habilitarCampos();
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

        private void habilitarCampos()
        {
            try
            {
                if (int.Parse(txtCodigo.Text) >= 4 && int.Parse(txtCodigo.Text) <= 6)
                {
                    txtImporte.Enabled = true;
                }

                if (int.Parse(txtCodigo.Text) > 6)
                {
                    cboEntradaSalida.Enabled = true;
                    txtDescripcion.Enabled   = true;
                    txtImporte.Enabled       = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarMovimientoCaja()
        {
            try
            {
                txtCodigo.Text = MovimientoCaja.m_Id.ToString();
                txtDescripcion.Text = MovimientoCaja.m_descripcion;
                txtImporte.Text = MovimientoCaja.m_valor.ToString().Replace(",", "."); 
                if (MovimientoCaja.m_entradaSalida == 1) { cboEntradaSalida.Text = "INGRESO"; } else { cboEntradaSalida.Text = "SALIDA"; }
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
                    actualizarMovimientoCaja();
                    this.Hide();
                }
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
                if (txtImporte.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Debe ingresar un importe.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtImporte.Focus();
                    return false; 
                }

                if (!(fg.esUnNumeroDecimal(txtImporte.Text))) 
                {
                    MessageBox.Show("El importe ingresado es inválido.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtImporte.Focus();
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

        private void actualizarMovimientoCaja()
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                TimeSpan hora = System.DateTime.Now.TimeOfDay;
                DateTime Dia = fg.appFechaSistema();
                String Hora = hora.ToString().Substring(0, 8);
                String sSQL;

                sSQL = "EXEC dbo.adp_actualizar_MovCaja ";
                sSQL = sSQL + " @ID_MOVIMIENTO = " + fg.fcSql(txtCodigo.Text, "STRING");
                sSQL = sSQL + " ,@VALOR = " + fg.fcSql(txtImporte.Text, "STRING");
                sSQL = sSQL + " ,@FECHA = " + fg.fcSql(Dia.ToString(), "DATETIME");
                sSQL = sSQL + " ,@HORA = " + fg.fcSql(Hora, "STRING");

                Conex.ejecutarQuery(sSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressNumerosDecimales(e, txtImporte);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (txtImporte.Enabled) { txtImporte.Text = String.Empty; }
            if (txtDescripcion.Enabled) { txtDescripcion.Text = String.Empty; }
            if (cboEntradaSalida.Enabled) { cboEntradaSalida.Text = String.Empty; }
        }
    }
}
