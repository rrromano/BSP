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

        public DateTime obtenerFechaCajaAbierta()
        {
            try
            {
                ConectarBD con = new ConectarBD();
                DataSet dataSet = new DataSet();
                string ssQL;

                ssQL = "SELECT ISNULL(MAX(FECHA),'19000101') FechaCajaAbierta FROM MOVIMIENTOS_CAJA ";
                dataSet.Reset();
                dataSet = con.ejecutarQuerySelect(ssQL);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    throw new System.ArgumentException("No se pudo obtener la última fecha de caja abierta. Consulte con el administrador.", "Estado del sistema");
                }

                return DateTime.Parse(dataSet.Tables[0].Rows[0]["FechaCajaAbierta"].ToString());
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] -  [" + e.Message.ToString() + "]");
            }
        }

        public DataSet obtenerMovimientosCaja(DateTime fecha) 
        {
            try
            {
                ConectarBD con = new ConectarBD();
                DataSet Ds = new DataSet();

                String sSQL = "";
                sSQL = "EXEC dbo.ObtenerMovimientosCaja ";
                sSQL = sSQL + " @fecha_mov = '" + fecha + "'";
                Ds.Reset();
                Ds = con.ejecutarQuerySelect(sSQL);

                return Ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] -  [" + e.Message.ToString() + "]");
            }

        }

        public Double obtenerImporteCajaActual(DateTime fecha)
        {
            try
            {
                ConectarBD con = new ConectarBD();
                DataSet Ds = new DataSet();
                Double importe = 0.00;
                String sSQL = "";

                sSQL = "EXEC dbo.ObtenerImporteCajaActual ";
                sSQL = sSQL + " @fecha_mov = '" + fecha + "'";
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
                throw new System.ArgumentException("[Error] -  [" + e.Message.ToString() + "]");
            }
        }

        public Double obtenerCajaActual (DateTime fecha)
        {
            try
            {
                ConectarBD con = new ConectarBD();
                DataSet Ds = new DataSet();
                Double importe = 0.00;
                String sSQL = "";

                sSQL = "EXEC dbo.ObtenerCajaActual";
                sSQL = sSQL + " @fecha_mov = '" + fecha + "'";
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
                throw new System.ArgumentException("[Error] -  [" + e.Message.ToString() + "]");
            }

        }

        public Double obtenerTotalesDia (DateTime fecha, int TipoMovimiento)
        {
            try
            {
                ConectarBD con = new ConectarBD();
                DataSet Ds = new DataSet();
                Double importe = 0.00;
                String sSQL = "";

                sSQL = "EXEC dbo.ObtenerTotales ";
                sSQL = sSQL + " @fecha_mov = '" + fecha + "'";
                sSQL = sSQL + " @TipoMovimiento = " + TipoMovimiento;
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
                throw new System.ArgumentException("[Error] -  [" + e.Message.ToString() + "]");
            }

        }

        public int obtenerEstado()
        {
            try
            {
                ConectarBD con = new ConectarBD();
                DataSet dataSet = new DataSet();
                string ssQL;

                ssQL = "SELECT Estado_Caja FROM PARAMETROS_GENERALES";
                dataSet.Reset();
                dataSet = con.ejecutarQuerySelect(ssQL);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    throw new System.ArgumentException("No se pudo obtener el estado actual del Sistema. Consulte con el administrador.", "Estado del sistema");
                }

                return int.Parse(dataSet.Tables[0].Rows[0]["Estado_Caja"].ToString());

            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] -  [" + e.Message.ToString() + "]");
            }

        }


    }
}
