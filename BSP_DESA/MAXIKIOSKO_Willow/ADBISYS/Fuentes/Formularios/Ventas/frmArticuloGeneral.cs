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

namespace ADBISYS.Formularios.Ventas
{
    public partial class frmArticuloGeneral : Form
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        public string cantidad = "";
        
        public frmArticuloGeneral()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtImporte.Text == "")
            {
                MessageBox.Show("Debe indicar el Importe.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtImporte.Focus();
                return;
            }

            if (fg.esUnNumeroDecimal(txtImporte.Text) == false)
            {
                MessageBox.Show("El importe ingresado es inválido.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtImporte.Focus();
                return;
            }
            if (double.Parse(txtImporte.Text.ToString()) == 0)
            {
                MessageBox.Show("El importe ingresado es inválido.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtImporte.Focus();
                return;
            }
            guardarArticuloVentaTemporal();
            this.Close();
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            fg.keyPressNumerosDecimales(e, txtImporte);
            fg.keyPressNumericoDiezDosDecimales(e, txtImporte.Text.Length, txtImporte.Text);
        }

        public void guardarArticuloVentaTemporal()
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                String sSQL;
                sSQL = "EXEC dbo.adp_insertarArticuloVenta_Temporal ";
                sSQL = sSQL + " @Id_Articulo = 1";
                sSQL = sSQL + " ,@Cantidad = " + fg.fcSql(cantidad.ToString(), "INTEGER");
                sSQL = sSQL + " ,@Importe = " + txtImporte.Text;

                Conex.ejecutarQuery(sSQL);
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }
    }
}
