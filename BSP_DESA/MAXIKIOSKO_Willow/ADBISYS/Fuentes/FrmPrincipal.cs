using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.FuncionesGenerales;
using ADBISYS.Formularios.Ingresar;
using ADBISYS.Formularios.Caja;
using ADBISYS.Formularios.Ayuda;
using ADBISYS.Formularios.Proveedores;
using ADBISYS.Formularios.Rubros;
using ADBISYS.Formularios.Compras;

// RR 2014-03-22: Comienzo del sistema ADBISYS.

namespace ADBISYS
{
    public partial class FrmPrincipal : Form
    {
        frmIniciarSesion iniciarSesion = new frmIniciarSesion(); //FU 2014-04-04 Hago público el inicio de sesión ya que para controlar si está o no conectado debe haber una sola instancia
        public string user = "";

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void mostrarFormularioCajaInicial()
        {
            if (validarInicioCaja()) 
            {
                frmCajaInicial cajaIni = new frmCajaInicial();
                cajaIni.ShowDialog();
            }
        }

        private bool validarInicioCaja()
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                Entidades.Caja caja = new Entidades.Caja();
                DateTime fechaSistema = fg.appFechaSistema();
                if (caja.obtenerEstado() != 0)
                {
                    MessageBox.Show("No se puede iniciar la caja debido a que no se cerró la caja del día " + caja.obtenerFechaCajaAbierta().ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            IniciarPrograma(); // RR 2014-03-22.
        }

        private void IniciarPrograma()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                if (Properties.Settings.Default.UsuarioLogueado == "")
                {
                    mostrarFormularioIniciarSesion();
                }
                else
                {
                    MessageBox.Show("Ya existe una sesión iniciada.", "Inicio de Sesión.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cerrarSesiónTSMI_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.UsuarioLogueado == "")
                {
                    MessageBox.Show("Aún no ha iniciado sesión.", "Cerrar Sesión.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Cerrar Sesión.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Properties.Settings.Default.UsuarioLogueado = "";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminUsuarioTSMI_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarFormularioAdministrarUser()
        {
            try
            {
                frmAdministrarUsuario administrarUsuario = new frmAdministrarUsuario();
                administrarUsuario.ShowDialog();
                if (Properties.Settings.Default.UsuarioLogueado != "")
                {
                    usuarioTSS.Text = "Usuario: " + Properties.Settings.Default.UsuarioLogueado;
                    usuarioTSS.BackColor = Color.Black;
                    usuarioTSS.ForeColor = Color.Yellow;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarFormularioIniciarSesion()
        {
            try
            {
                frmIniciarSesion iniciarSesion = new frmIniciarSesion();
                iniciarSesion.ShowDialog();
                if (Properties.Settings.Default.UsuarioLogueado != "")
                {
                    usuarioTSS.Text = "Usuario: " + Properties.Settings.Default.UsuarioLogueado;
                    usuarioTSS.BackColor = Color.Black;
                    usuarioTSS.ForeColor = Color.Yellow;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void acercaDeWillowTSMI_Click(object sender, EventArgs e)
        {
            mostrarFormularioAcercaDeWillow();
        }

        private void mostrarFormularioAcercaDeWillow()
        {
            frmAcercaDeWillow acercaDeWillow = new frmAcercaDeWillow();
            acercaDeWillow.ShowDialog();
        }

        private void mostrarFormularioAcercaDeBSP()
        {
            frmAcercaDeBSP acercaDeBSP = new frmAcercaDeBSP();
            acercaDeBSP.ShowDialog();
        }

        private void acercaDeBSPTSMI_Click(object sender, EventArgs e)
        {
            mostrarFormularioAcercaDeBSP();
        }

        private void modifProveedoresTSMI_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProveedoresPrincipal);

                if (frm != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    return;
                }
                else
                {
                    mostrarFormularioProveedores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarFormularioProveedores()
        {
            frmProveedoresPrincipal proveedores = new frmProveedoresPrincipal();
            proveedores.Show(); // RR: Se hace un punto Show en lugar de ShowDialog, para que me permita utilizar otras funcionalidades, dejando este formulario abierto.
        }

        private void finalizarTSMI_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(cajaIniciada())) { return; }
                frmCerrarCaja cerrarCaja = new frmCerrarCaja();
                cerrarCaja.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarCajaTSMI_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(cajaIniciada())) { return; }

                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCaja);

                if (frm != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    return;
                }
                else
                {
                    mostrarFormularioCaja();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool cajaIniciada()
        {
            try
            {
                //Estado de la caja: [0 no está iniciada] / [1 está iniciada]
                Entidades.Caja caj = new ADBISYS.Entidades.Caja();
                if (caj.obtenerEstado() == 0) 
                {
                    MessageBox.Show("Aún no se ha iniciado la caja del día de hoy.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false; 
                } 
                else 
                { 
                    return true; 
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void mostrarFormularioCaja()
        {
            frmCaja MovsCaja = new frmCaja();
            MovsCaja.Show();
        }

        private void modifRubrosTSMI_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmRubrosPrincipal);

                if (frm != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    return;
                }
                else
                {
                    mostrarFormularioRubros();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarFormularioRubros()
        {
            frmRubrosPrincipal rubros = new frmRubrosPrincipal();
            rubros.Show();
        }

        private void agregarModificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmComprasPrincipal);

                if (frm != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    return;
                }
                else
                {
                    mostrarFormularioCompras();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarFormularioCompras()
        {
            frmComprasPrincipal compras = new frmComprasPrincipal();
            compras.Show();
        }

        private void agregarModificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {

                if (!(cajaIniciada())) { return; }

                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTipoMovCaja);

                if (frm != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    return;
                }
                else
                {
                    mostrarFormularioTipoMovCaja();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarFormularioTipoMovCaja()
        {
            frmTipoMovCaja TipoMovCaja = new frmTipoMovCaja();
            TipoMovCaja.Show();
        }

    }
}
