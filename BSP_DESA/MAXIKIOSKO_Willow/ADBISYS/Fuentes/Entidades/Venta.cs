using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ADBISYS.Conexion;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ADBISYS.Entidades
{
    public class Venta
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql = "";
        
        #region propiedades

        private UInt64 id;
        private Int32 cantidad_articulos;
        private Double importe;
        private int estado;
        private DateTime fecha_venta;
        private String hora_venta;
        private List<Articulo_Venta> articulos_venta;

        #endregion

        #region Getters&Setters

        public UInt64 m_Id_Venta
        {
            get { return id; }
            set { id = value; }
        }

        public Int32 m_cantidad_articulos
        {
            get { return cantidad_articulos; }
            set { cantidad_articulos = value; }
        }

        public Double m_importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public int m_estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public DateTime m_fecha_venta
        {
            get { return fecha_venta; }
            set { fecha_venta = value; }
        }

        public String m_hora_venta
        {
            get { return hora_venta; }
            set { hora_venta = value; }
        }

        public List<Articulo_Venta> m_articulos_venta
        {
            get { return articulos_venta; }
            set { articulos_venta = value; }
        }

        #endregion

        #region Metodos públicos
        //internal List<Venta> obtenerVentas(DateTime Fecha)
        internal DataSet obtenerVentas (DateTime fecha)
        {
            try
            {
                String cadenaSql = "";
                DataSet Ds = new DataSet();
                ConectarBD objConect = new ConectarBD();
                
                //List<Venta> VentasDelDia = new List<Venta>();

                cadenaSql = "EXEC dbo.adp_obtener_ventas @fechaDesde = " + fg.fcSql(fecha.ToString(), "DATETIME");
                cadenaSql = cadenaSql + ", @fechaHasta = " + fg.fcSql(fecha.ToString(), "DATETIME");
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

        public void cargarDatosVenta()
        {
            try
            {
                ConectarBD conect = new ConectarBD();
                DataSet dataSet = new DataSet();
                String sSQL;

                sSQL = "EXEC dbo.adp_obtenerDatosVenta ";
                sSQL = sSQL + " @Id_Venta = " + fg.fcSql(this.m_Id_Venta.ToString(), "INTEGER");

                dataSet = conect.ejecutarQuerySelect(sSQL);

                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    Articulo_Venta articulo_venta = new Articulo_Venta();

                    this.m_cantidad_articulos = Int32.Parse(dataRow["CANTIDAD_ARTICULOS"].ToString());
                    this.m_importe = Double.Parse(dataRow["IMPORTE"].ToString());
                    this.m_estado = Int32.Parse(dataRow["ESTADO"].ToString());
                    this.m_fecha_venta = DateTime.Parse(dataRow["FECHA_VENTA"].ToString());
                    this.m_hora_venta = dataRow["HORA_VENTA"].ToString();
                    this.cargarArticulosVenta();
                }

            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public void cargarArticulosVenta()
        {
            try
            {
                ConectarBD conect = new ConectarBD();
                DataSet dataSet = new DataSet();
                String sSQL;

                sSQL = "EXEC dbo.adp_obtenerArticulosVenta2 ";
                sSQL = sSQL + " @Id_Venta = " + fg.fcSql(this.m_Id_Venta.ToString(), "INTEGER");

                dataSet = conect.ejecutarQuerySelect(sSQL);

                this.m_articulos_venta = new List<Articulo_Venta>();

                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    Articulo_Venta articulo_venta = new Articulo_Venta();

                    articulo_venta.m_id_venta = UInt64.Parse(dataRow["ID_VENTA"].ToString());
                    articulo_venta.m_id_item_venta = UInt64.Parse(dataRow["ID_ITEM_VENTA"].ToString());
                    articulo_venta.m_id_articulo = UInt64.Parse(dataRow["ID_ARTICULO"].ToString());
                    articulo_venta.m_cantidad = Int32.Parse(dataRow["CANTIDAD"].ToString());
                    articulo_venta.m_precio_venta = Double.Parse(dataRow["PRECIO_VENTA"].ToString());

                    this.m_articulos_venta.Add(articulo_venta);
                }

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

        public void borrarArticulosVenta_Temporal(UInt64 Id_ItemVenta)
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                String sSQL;
                sSQL = "EXEC dbo.adp_BorrarArticulosVenta_Temporal ";
                sSQL = sSQL + " @Id_ItemVenta = " + fg.fcSql(Id_ItemVenta.ToString(), "INTEGER");
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

        public void guardarArticuloVentaTemporal(UInt64 IdArticulo, Int32 Cantidad)
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                String sSQL;
                sSQL = "EXEC dbo.adp_insertarArticuloVenta_Temporal ";
                sSQL = sSQL + " @Id_Articulo = " + fg.fcSql(IdArticulo.ToString(), "INTEGER");
                sSQL = sSQL + " ,@Cantidad = " + fg.fcSql(Cantidad.ToString(), "INTEGER");

                Conex.ejecutarQuery(sSQL);
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }


        internal void actualizarVenta (UInt64 id_venta)
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                String sSQL;
                String login = Properties.Settings.Default.UsuarioLogueado.ToString();

                sSQL = "EXEC dbo.adp_modificarVenta ";
                sSQL = sSQL + " @Id_Venta = " + fg.fcSql(id_venta.ToString(), "INTEGER");
                if (login != "")
                { sSQL = sSQL + " ,@USUARIO_VENTA = " + fg.fcSql(login, "String"); }

                Conex.ejecutarQuery(sSQL);                
            }
            catch (Exception ex)
            {
                fg.mostrarErrorTryCatch(ex);
            }
        }

        public DataSet obtenerCamposVentas()
        {
            try
            {
                cadenaSql = "EXEC adp_cboBusqueda_Ventas";
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public DataSet obtenerGanancia(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                ConectarBD con = new ConectarBD();
                DataSet ds = new DataSet();
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                String cadenaSql = "";

                cadenaSql = "EXEC adp_obtener_ganancia @FECHA_DESDE = " + fg.fcSql(fechaDesde.ToString(), "DATETIME");
                cadenaSql = cadenaSql + ", @FECHA_HASTA = " + fg.fcSql(fechaHasta.ToString(), "DATETIME");
                ds = con.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }
    }
}
