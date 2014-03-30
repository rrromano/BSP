using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// RR 2014-03-22: Comienzo del sistema ADBISYS.

namespace ADBISYS
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            IniciarPrograma(); // RR 2014-03-22.
        }

        private void IniciarPrograma()
        {
            // RR 2014-03-22 [INICIO]: Inicializa el programa y las propiedades de los diferentes controles.
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            fechaTSS.Text = DateTime.Today.ToString("D"); 
            timer.Start();
            vacioTSS.Text = "";
            maquinaTSS.Text = Environment.MachineName;
            // RR 2014-03-22 [FIN]: Inicializa el programa y las propiedades de los diferentes controles.
        }

        private void salirTSMI_Click(object sender, EventArgs e)
        {
            Application.Exit(); //RR 2014-03-22
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            horaTSS.Text = DateTime.Now.ToLongTimeString();//RR 2014-03-22.
        }
    }
}
