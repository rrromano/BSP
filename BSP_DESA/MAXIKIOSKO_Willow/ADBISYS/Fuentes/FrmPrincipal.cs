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
using ADBISYS.Formularios.Articulos;
using ADBISYS.Formularios.Reportes;
using ADBISYS.Formularios.Ventas;

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
                if (hayMovimientosHoy())
                {
                    if (!(preguntoSiEliminarMovimientosHoy()))
                    {
                        return;
                    }
                    else
                    {
                        eliminarMovimientosHoy();
                    }
                }

                frmCajaInicial cajaIni = new frmCajaInicial();
                cajaIni.ShowDialog();
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                Entidades.Caja caja = new Entidades.Caja();
                string fechaSistema = fg.appFechaSistema().ToString().Substring(0, 10);
                if (caja.obtenerEstado() != 0)
                {
                    cajaTTS.Text = "Caja Iniciada: " + fechaSistema;
                    cajaTTS.BackColor = Color.Black;
                    cajaTTS.ForeColor = Color.White;
                }
            }
        }

        private bool validarInicioCaja()
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                Entidades.Caja caja = new Entidades.Caja();
                if (caja.obtenerEstado() != 0)
                {
                    MessageBox.Show("No se puede iniciar la caja debido a que no se cerró la correspondiente al día " + caja.obtenerFechaCajaAbierta() + ".", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
            Entidades.Caja caja = new Entidades.Caja();
            string fechaSistema = fg.appFechaSistema().ToString().Substring(0,10);
            if (caja.obtenerEstado() != 0)
            {
                cajaTTS.Text = "Caja Iniciada: " + fechaSistema;
                cajaTTS.BackColor = Color.Black;
                cajaTTS.ForeColor = Color.White;
            }
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
            try
            {
                //Estado de la caja: [0 no está iniciada] / [1 está iniciada]
                Entidades.Caja caj = new ADBISYS.Entidades.Caja();
                if (caj.obtenerEstado() == 1)
                {
                    MessageBox.Show("Para salir de AdbisyS debe realizar el cierre de caja correspondiente.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (Application.OpenForms.Count > 1)
                {
                    MessageBox.Show("Para salir de AdbisyS debe cerrar todos los formularios.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

        private void eliminarMovimientosHoy()
        {
            try
            {
                Entidades.Caja caja = new Entidades.Caja();
                caja.eliminarMovCajaPorFecha(DateTime.Now.Date);
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean preguntoSiEliminarMovimientosHoy()
        {
            try
            {
                if (MessageBox.Show("No se puede iniciar la caja del día de hoy, ya que existen movimientos correspondientes a la fecha. Si inicia la caja, se eliminarán todos los movimientos actuales. \n¿Está seguro que desa continuar?", "¿Está Seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool hayMovimientosHoy()
        {
            try
            {
                Entidades.Caja caja = new Entidades.Caja();
                return caja.verificarExistenciaMovCajaSegunFecha(DateTime.Now.Date);
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
                    usuarioTSS.ForeColor = Color.White;
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
                    usuarioTSS.ForeColor = Color.White;
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

                if ((Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCaja) != null) || (Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTipoMovCaja) != null) || (Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmComprasPrincipal) != null))
                {
                    MessageBox.Show("Para realizar el Cierre de Caja, debe cerrar los formularios de Caja, Compras y Ventas.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                frmCerrarCaja cerrarCaja = new frmCerrarCaja();
                cerrarCaja.ShowDialog();

                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                Entidades.Caja caja = new Entidades.Caja();
                string fechaSistema = fg.appFechaSistema().ToString().Substring(0, 10);
                if (caja.obtenerEstado() == 0)
                {
                    cajaTTS.Text = "Caja Cerrada";
                    cajaTTS.BackColor = Color.White;
                    cajaTTS.ForeColor = Color.Black;
                }
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
            if (!(cajaIniciada())) { return; }
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

        private void actPrecioArticuloTSMI_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.UsuarioLogueado == "")
                {
                    MessageBox.Show("Debe iniciar sesión.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Formularios.Articulos.frmActMasivaArticulo);

                if (frm != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    return;
                }
                else
                {
                    mostrarFormlarioActMasivaArticulo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarFormlarioActMasivaArticulo()
        {
            Formularios.Articulos.frmActMasivaArticulo frmActMasivaArt = new Formularios.Articulos.frmActMasivaArticulo();
            frmActMasivaArt.ShowDialog();
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Estado de la caja: [0 no está iniciada] / [1 está iniciada]
                Entidades.Caja caj = new ADBISYS.Entidades.Caja();
                if (caj.obtenerEstado() == 1)
                {
                    MessageBox.Show("Para cerrar AdbisyS debe realizar el cierre de caja correspondiente.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void nuevaVentaTSMI_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVentasPrincipal);

                if (frm != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    return;
                }
                else
                {
                    mostrarFormularioVentas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarFormularioVentas()
        {
            if (!(cajaIniciada())) { return; }
            Formularios.Ventas.frmVentasPrincipal ventas = new ADBISYS.Formularios.Ventas.frmVentasPrincipal();
            ventas.Show();
        }

        private void modifArticuloTSMI_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmArticulosPrincipal);

                if (frm != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    return;
                }
                else
                {
                    mostrarFormularioArticulos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarFormularioArticulos()
        {
            frmArticulosPrincipal articulos = new frmArticulosPrincipal();
            articulos.Show();
        }

        private void cajaDiariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.UsuarioLogueado == "")
                {
                    MessageBox.Show("Debe iniciar sesión.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteCajaDiaria);
                if (frm != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    return;
                }
                
                mostrarFormularioReporteCajaDiaria();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarFormularioReporteCajaDiaria()
        {
            frmReporteCajaDiaria repoCajaDiaria = new frmReporteCajaDiaria();
            repoCajaDiaria.Show();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.UsuarioLogueado == "")
                {
                    MessageBox.Show("Debe iniciar sesión.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteCompras);
                if (frm != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    return;
                }

                mostrarFormularioReporteCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarFormularioReporteCompras()
        {
            frmReporteCompras repoCompras = new frmReporteCompras();
            repoCompras.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.UsuarioLogueado == "")
                {
                    MessageBox.Show("Debe iniciar sesión.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmReporteVentas);
                if (frm != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    return;
                }

                mostrarFormularioReporteVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarFormularioReporteVentas()
        {
            frmReporteVentas repoVentas = new frmReporteVentas();
            repoVentas.Show();
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmNuevaVenta);

                if (frm != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    return;
                }
                else
                {
                    mostrarFormularioNuevaVenta();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mostrarFormularioNuevaVenta()
        {
            if (!(cajaIniciada())) { return; }
            frmNuevaVenta nuevaVenta = new frmNuevaVenta();
            nuevaVenta.Show();
        }
    }
}
