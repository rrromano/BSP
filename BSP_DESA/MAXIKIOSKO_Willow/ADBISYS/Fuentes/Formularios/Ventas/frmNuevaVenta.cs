using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADBISYS.Formularios.Ventas
{
    public partial class frmNuevaVenta : Form
    {
        public frmNuevaVenta()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            //va a abrir un formulario nuevo donde vas a buscar al articulo 
            //una vez que lo encuentres se debe generar una nueva instancia de ese nuevo articulo
            //se llama a la funcion cargarArticuloEnGrilla(articulo) pasandole por parametro la nueva instancia
        }

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Venta Ok");
        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //SI APRETO ENTER EJECUTO ESTE CODIGO

                //Entidades.Articulo articulo = new ADBISYS.Entidades.Articulo();
                //articulo = generarArticulo(txtCodigoArticulo.Text);
                //cargarArticuloEnGrilla(articulo);
            }
        }

        private void cargarArticuloEnGrilla(ADBISYS.Entidades.Articulo articulo)
        {
            //GUARDO EN LA GRILLA EL ARTICULO QUE RECIBO POR PARAMETRO
            throw new NotImplementedException();
        }

        private ADBISYS.Entidades.Articulo generarArticulo(String codigo)
        {
            //ACA GENERO UNA INSTANCIA DE ARTICULO BUSCANDO LOS DATOS DEL ARTICULO EN LA BD POR EL CODIGO RECIBIDO POR PARAMETRO
            throw new NotImplementedException();
        }
    }
}
