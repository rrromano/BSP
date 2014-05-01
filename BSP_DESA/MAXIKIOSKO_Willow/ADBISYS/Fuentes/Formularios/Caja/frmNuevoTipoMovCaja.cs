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

namespace ADBISYS.Formularios.Caja
{
    public partial class frmNuevoMovimientoCaja : Form
    {
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

        public frmNuevoMovimientoCaja()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                //txtCodigo.Text = String.Empty;
                txtTipoMovimiento.Text = String.Empty;
                cboEntradaSalida.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoMovimientoCaja_Load(object sender, EventArgs e)
        {
            try
            {
                obtenerCodigoNuevoMovimiento();
                cargarComboEntradaSalida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void obtenerCodigoNuevoMovimiento()
        {
            try
            {
                String cadenaSql = "EXEC adp_maximo_TipoMovimiento_Caja";
                ConectarBD Conex = new ConectarBD();
                DataSet Ds = new DataSet();
                Ds = Conex.ejecutarQuerySelect(cadenaSql);

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    txtCodigo.Text = Ds.Tables[0].Rows[0]["MAXIMO"].ToString();
                }
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
                cboEntradaSalida.Items.Clear();
                cboEntradaSalida.Items.Add("ENTRADA");
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
                if (!validoCampos()) return;
                if (existeTipoMovimientoCaja()) return;
                altaMovimientoCaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void altaMovimientoCaja()
        {
            try
            {
                String Usuario = Properties.Settings.Default.UsuarioLogueado.ToString();
                ConectarBD Conex = new ConectarBD();
                TimeSpan hora = System.DateTime.Now.TimeOfDay;
                String Hora = hora.ToString().Substring(0, 8);

                String CadenaSql = "EXEC adp_nuevo_TipoMovCaja";
                CadenaSql = CadenaSql + " @TIPOMOVCAJA_ID       = " + txtCodigo.Text.ToString() ;
                CadenaSql = CadenaSql + " ,@TIPOMOVCAJA_DESC    = " + fg.fcSql(txtTipoMovimiento.Text, "STRING");
                CadenaSql = CadenaSql + " ,@TIPOMOVCAJA_FECHA   = " + fg.fcSql(fg.appFechaSistema().ToString(), "STRING");
                CadenaSql = CadenaSql + " ,@TIPOMOVCAJA_HORA    = " + fg.fcSql(Hora, "STRING");
                CadenaSql = CadenaSql + " ,@TIPOMOVCAJA_LOGIN   = " + fg.fcSql(Usuario, "STRING");
                
                switch (cboEntradaSalida.Text)
                {
                    case "ENTRADA":
                        CadenaSql = CadenaSql + " ,@TIPOMOVCAJA_ES = 1";
                        break;
                    case "SALIDA":
                        CadenaSql = CadenaSql + " ,@TIPOMOVCAJA_ES = 0";
                        break;
                    default:
                        throw new System.ArgumentException("Error alta Tipo Movimiento Caja - Entrada/Salida");
                }

                Conex.ejecutarQuery(CadenaSql);
                this.Close();
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
                CadenaSql = CadenaSql + " @Descripcion = " + fg.fcSql(txtTipoMovimiento.Text, "STRING");
                Ds = Conex.ejecutarQuerySelect(CadenaSql);

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Ya existe un Tipo de Movimiento " + fg.fcSql(txtTipoMovimiento.Text, "STRING"), "Alta de Tipo de Movimiento Caja.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTipoMovimiento.Focus();
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

        private bool validoCampos()
        {
            try
            {
                if (txtTipoMovimiento.Text.Trim().Length == 0)
                {
                    MessageBox.Show("El campo Tipo de Movimiento es obligatorio", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTipoMovimiento.Focus();
                    return false;
                }

                if (cboEntradaSalida.Text.Length == 0)
                {
                    MessageBox.Show("Debe indicar si el tipo de movimiento es de Entrada o Salida.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboEntradaSalida.Focus();
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

        private void txtTipoMovimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = fg.keyPressMayusculas(e);
        }
    }
}
