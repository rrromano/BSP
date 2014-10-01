using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADBISYS.Conexion;
using System.Data;

namespace ADBISYS.Entidades
{
    public class Caja
    {
        private DateTime fechaCaja;
        private double cajaInicial;
        private double cajaFinal;
        private double importe_Final;

        public DateTime m_fecha
        {
            get { return fechaCaja; }
            set { fechaCaja = value; }
        }

        public double m_cajaInicial
        {
            get { return cajaInicial; }
            set { cajaInicial = value; }
        }

        public double m_cajaFinal
        {
            get { return cajaFinal; }
            set { cajaFinal = value; }
        }

        public double m_importe_Final
        {
            get { return importe_Final; }
            set { importe_Final = value; }
        }

        public string obtenerFechaCajaAbierta()
        {
            try
            {
                ConectarBD con = new ConectarBD();
                DataSet dataSet = new DataSet();
                string ssQL;

                ssQL = "exec adp_obtener_ultimaFechaCajaAbierta";
                dataSet.Reset();
                dataSet = con.ejecutarQuerySelect(ssQL);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    throw new System.ArgumentException("No se pudo obtener la última fecha de caja abierta. Consulte con el administrador.", "Estado del sistema");
                }

                return (dataSet.Tables[0].Rows[0]["FechaCajaAbierta"].ToString());
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public DataSet obtenerMovimientosCaja(DateTime fecha) 
        {
            try
            {
                ConectarBD con = new ConectarBD();
                DataSet Ds = new DataSet();
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

                String sSQL = "";
                sSQL = "EXEC dbo.adp_ObtenerMovimientosCaja @fecha_mov = " + fg.fcSql(fecha.ToString(),"DATETIME");
                Ds.Reset();
                Ds = con.ejecutarQuerySelect(sSQL);

                return Ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public Double obtenerImporteCajaActual(DateTime fecha)
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                ConectarBD con = new ConectarBD();
                DataSet Ds = new DataSet();
                Double importe = 0.00;
                String sSQL = "";

                sSQL = "EXEC dbo.ObtenerImporteCajaActual ";
                sSQL = sSQL + " @fecha_mov = " + fg.fcSql(fecha.ToString(), "DATETIME");
                Ds.Reset();
                Ds = con.ejecutarQuerySelect(sSQL);

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    importe = Double.Parse(Ds.Tables[0].Rows[0]["TOTAL"].ToString());
                }

                return importe;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public Double obtenerCajaActual (DateTime fecha)
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                ConectarBD con = new ConectarBD();
                DataSet Ds = new DataSet();
                Double importe = 0.00;
                String sSQL = "";

                sSQL = "EXEC dbo.adp_ObtenerCajaActual";
                sSQL = sSQL + " @fecha_mov = " + fg.fcSql(fecha.ToString(), "DATETIME");
                Ds.Reset();
                Ds = con.ejecutarQuerySelect(sSQL);

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    importe = Double.Parse(Ds.Tables[0].Rows[0]["TOTAL"].ToString());
                }

                return importe;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }

        public Double obtenerTotalesDia (DateTime fecha, int TipoMovimiento)
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                ConectarBD con = new ConectarBD();
                DataSet Ds = new DataSet();
                Double importe = 0.00;
                String sSQL = "";

                sSQL = "EXEC dbo.adp_ObtenerTotales ";
                sSQL = sSQL + " @fecha_mov = " + fg.fcSql(fecha.ToString(), "DATETIME");
                sSQL = sSQL + " ,@TipoMovimiento = " + TipoMovimiento;
                Ds.Reset();
                Ds = con.ejecutarQuerySelect(sSQL);

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    importe = Double.Parse(Ds.Tables[0].Rows[0]["TOTAL"].ToString());
                }

                return importe;

            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }

        public int obtenerEstado()
        {
            try
            {
                ConectarBD Conex = new ConectarBD();
                DataSet Ds = new DataSet();
                string ssQL;

                ssQL = "SELECT Estado_Caja FROM PARAMETROS_GENERALES";
                Ds.Reset();
                Ds = Conex.ejecutarQuerySelect(ssQL);

                if (Ds.Tables[0].Rows.Count == 0)
                {
                    throw new System.ArgumentException("No se pudo obtener el estado actual del Sistema. Consulte con el administrador.", "Estado del sistema");
                }

                return int.Parse(Ds.Tables[0].Rows[0]["Estado_Caja"].ToString());

            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }

        internal bool verificarExistenciaMovCajaSegunFecha(DateTime fecha_mov)
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                ConectarBD Conex = new ConectarBD();
                DataSet Ds = new DataSet();
                String sSQL = "EXEC dbo.adp_VerificoExistenciaMovCaja @fecha_mov = " + fg.fcSql(fecha_mov.ToString(),"DATETIME");
                Ds = Conex.ejecutarQuerySelect(sSQL);
                if (Ds.Tables[0].Rows.Count == 0) { return false; } else { return true; }
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        internal void eliminarMovCajaPorFecha(DateTime fecha_mov)
        {
            try
            {
                string usuario = Properties.Settings.Default.UsuarioLogueado.ToString();
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                ConectarBD Conex = new ConectarBD();
                String sSQL = "EXEC dbo.adp_eliminarTodosMovCajaDeHoy @fecha_mov = " + fg.fcSql(fecha_mov.ToString(), "DATETIME");
                if (usuario != "")
                { sSQL = sSQL + ",@Login = " + fg.fcSql(usuario, "String"); }

                Conex.ejecutarQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        internal DataSet obtenerMovimientosCierreCaja(DateTime fechaCierre)
        {
            try
            {
                ConectarBD con = new ConectarBD();
                DataSet Ds = new DataSet();
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

                String sSQL = "";
                sSQL = "EXEC dbo.adp_ObtenerMovimientosCierreCaja @fecha_mov = " + fg.fcSql(fechaCierre.ToString(), "DATETIME");
                Ds.Reset();
                Ds = con.ejecutarQuerySelect(sSQL);

                return Ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public DataSet obtenerCamposMovimientosCaja()
        {
            try
            {
                ConectarBD con = new ConectarBD();
                DataSet ds = new DataSet();
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                String cadenaSql = "";

                cadenaSql = "EXEC adp_cbobusqueda_movimientos_caja";
                ds = con.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public DataSet obtenerCierreParcialCaja(DateTime fecha)
        {
            try
            {
                ConectarBD con = new ConectarBD();
                DataSet ds = new DataSet();
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                String cadenaSql = "";

                cadenaSql = "EXEC adp_cierre_parcial @FECHA = " + fg.fcSql(fecha.ToString(), "DATETIME");
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
