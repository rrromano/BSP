using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.Formularios.Ingresar;
using ADBISYS.Formularios.Caja;

// RR 2014-03-22: Comienzo del sistema ADBISYS.

namespace ADBISYS
{
    public partial class FrmPrincipal : Form
    {
        frmIniciarSesion iniciarSesion = new frmIniciarSesion(); //FU 2014-04-04 Hago público el inicio de sesión ya que para controlar si está o no conectado debe haber una sola instancia

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void mostrarFormularioCajaInicial()
        {
            frmCajaInicial cajaIni = new frmCajaInicial();
            cajaIni.ShowDialog();
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

        private void articulosTS_Click(object sender, EventArgs e)
        {
            Conexion.ConectarBD conect = new ADBISYS.Conexion.ConectarBD();
            conect.conectar();
        }

        private void iniciarCajaTSMI_Click(object sender, EventArgs e)
        {
            mostrarFormularioCajaInicial();
        }

        private void iniciarSesiónTSMI_Click(object sender, EventArgs e)
        {

            frmIniciarSesion iniciarSesion = new frmIniciarSesion();

            if (iniciarSesion.m_Usuario == "")
            {
                iniciarSesion.ShowDialog();

                if (iniciarSesion.m_Usuario != "")
                {
                    usuarioTSS.Text = "Usuario: " + iniciarSesion.m_Usuario;
                    usuarioTSS.BackColor = Color.Black;
                    usuarioTSS.ForeColor = Color.Yellow;
                }
            }
            else
            {
                MessageBox.Show("Ya existe una sesión iniciada.", "Inicio de Sesión.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        //private void FrmPrincipal_Activated(object sender, EventArgs e)
        //{
        //    if (Properties.Settings.Default.UsuarioLogueado != "")
        //    {
        //        usuarioTSS.Text = "Usuario: " + Properties.Settings.Default.UsuarioLogueado;
        //        usuarioTSS.BackColor = Color.Black;
        //        usuarioTSS.ForeColor = Color.Yellow;
        //    }
        //}

        private void cerrarSesiónTSMI_Click(object sender, EventArgs e)
        {
            //if (Properties.Settings.Default.UsuarioLogueado == "")

            if (iniciarSesion.m_Usuario == "")
            {
                MessageBox.Show("Aún no ha iniciado sesión.", "Cerrar Sesión.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Cerrar Sesión.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Properties.Settings.Default.UsuarioLogueado = ""; //FU 2014-04-04
                    iniciarSesion.m_Usuario = ""; //FU 2014-04-04
                    usuarioTSS.Text = "Usuario Desconectado";
                    usuarioTSS.BackColor = Color.White;
                    usuarioTSS.ForeColor = Color.Black;
                }
                else
                {
                    return;
                }
            }
        }

        private void adminUsuarioTSMI_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UsuarioLogueado == "")
            {
                MessageBox.Show("Debe iniciar sesión.", "Administrar Usuario.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                mostrarFormularioAdministrarUser();
            }
        }

        private void mostrarFormularioAdministrarUser()
        {
            frmAdministrarUsuario administrarUsuario = new frmAdministrarUsuario();
            administrarUsuario.ShowDialog();
        }


    }
}
