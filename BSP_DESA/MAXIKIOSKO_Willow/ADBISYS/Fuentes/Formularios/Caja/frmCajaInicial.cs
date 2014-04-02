using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.Conexion;
using ADBISYS.Entidades;
using ADBISYS.FuncionesGenerales;

namespace ADBISYS.Formularios
{
    public partial class frmCajaInicial : Form
    {
        public frmCajaInicial()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                registrarCajaInicial();
            }
        }

        private bool validar()
        {
            return true;
        }

        private void registrarCajaInicial()
        {
            ConectarBD con = new ConectarBD();
            string sSQL;

            sSQL = "exec adp_registrar_mov_caja ";
            sSQL = sSQL + "@parametro";
            con.ejecutarQuery(sSQL);
        }

    }
}
