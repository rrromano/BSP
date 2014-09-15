using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ADBISYS.Conexion;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ADBISYS.Entidades
{
    class Venta
    {
        #region propiedades

        private Int32 id;
        private long cantidad_Articulos;
        private double importe;
        private int estado;
        private DateTime fecha_Venta;
        private String hora_Venta;

        #endregion

        #region Getters&Setters

        public Int32 m_Id_Venta
        {
            get { return id; }
            set { id = value; }
        }

        public long m_Cantidad_Articulos
        {
            get { return cantidad_Articulos; }
            set { cantidad_Articulos = value; }
        }

        public double m_importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public int m_estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public DateTime m_Fecha_Venta
        {
            get { return fecha_Venta; }
            set { fecha_Venta = value; }
        }

        public String m_Hora_Venta
        {
            get { return hora_Venta; }
            set { hora_Venta = value; }
        }

        #endregion

        #region Metodos públicos
        //internal List<Venta> obtenerVentas(DateTime Fecha)
        internal DataSet obtenerVentas (DateTime Fecha)
        {
            try
            {
                String cadenaSql = "";
                DataSet Ds = new DataSet();
                ConectarBD objConect = new ConectarBD();
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                
                //List<Venta> VentasDelDia = new List<Venta>();

                cadenaSql = "EXEC dbo.adp_obtener_ventas @d_16_fecha = " + fg.fcSql(Fecha.ToString(), "DATETIME");
                Ds = objConect.ejecutarQuerySelect(cadenaSql);

                return Ds;

                //foreach(DataRow dataRow in Ds.Tables[0].Rows)
                //{
                //    Venta venta = new Venta();
                //
                //    venta.id = Int32.Parse(dataRow["ID_VENTA"].ToString());
                //    venta.cantidad_Articulos = Int32.Parse(dataRow["CANTIDAD_ARTICULOS"].ToString());
                //    venta.importe = double.Parse(dataRow["IMPORTE"].ToString());
                //    venta.fecha_Venta = DateTime.Parse(dataRow["FECHA_VENTA"].ToString());
                //    venta.hora_Venta = dataRow["HORA_VENTA"].ToString();
                //
                //    VentasDelDia.Add(venta);
                //}
                //return VentasDelDia;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }
        
        public void guardarVentaYSusArticulos ()
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new ADBISYS.FuncionesGenerales.FuncionesGenerales();
                ConectarBD Conex = new ConectarBD();
                String Hora = System.DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
                String sSQL;
                String login = Properties.Settings.Default.UsuarioLogueado.ToString();

                sSQL = "EXEC dbo.adp_insertarVentaYArticulos ";
                sSQL = sSQL + " @FECHA_VENTA = " + fg.fcSql(fg.appFechaSistema().ToString(), "DATETIME");
                sSQL = sSQL + " ,@HORA_VENTA = " + fg.fcSql(Hora, "STRING");
                if (login != "")
                { sSQL = sSQL + " ,@USUARIO_VENTA = " + fg.fcSql(login, "String"); }

                Conex.ejecutarQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public void borrarArticulosVenta_Temporal()
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                String sSQL;
                sSQL = "EXEC dbo.adp_BorrarArticulosVenta_Temporal";
                Conex.ejecutarQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public void eliminarVenta(string codigo)
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new ADBISYS.FuncionesGenerales.FuncionesGenerales();
                ConectarBD Conex = new ConectarBD();
                String sSQL = "";
                String login = Properties.Settings.Default.UsuarioLogueado.ToString();

                sSQL = "EXEC dbo.adp_eliminarVenta ";
                sSQL = sSQL + " @Id_Venta = " + fg.fcSql(codigo,"INTEGER");
                if (login != "")
                { sSQL = sSQL + " ,@LOGIN = " + fg.fcSql(login, "String"); }

                Conex.ejecutarQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public void actualizaMovimientoVentas(DateTime Fecha)
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new ADBISYS.FuncionesGenerales.FuncionesGenerales();
                ConectarBD Conex = new ConectarBD();
                String sSQL = "";

                sSQL = "EXEC dbo.adp_ActualizarMovimientosCaja_Venta ";
                sSQL = sSQL + " @FECHA = " + fg.fcSql(Fecha.ToString(), "Datetime");
                Conex.ejecutarQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        #endregion

    }
}
