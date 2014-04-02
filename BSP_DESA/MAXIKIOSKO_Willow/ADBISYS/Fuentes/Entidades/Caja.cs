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

                ssQL = "SELECT ISNULL(MAX(FECHA),'19000101') FechaCajaAbierta FROM TMP_MOVIMIENTOS_CAJA ";
                dataSet.Reset();
                dataSet = con.ejecutarQuerySelect(ssQL);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    throw new System.ArgumentException("No se pudo obtener la última fecha de caja abierta. Consulte con el administrador.", "Estado del sistema");
                }

                return DateTime.Parse(dataSet.Tables[0].Columns["FechaCajaAbierta"].ToString());
            }
            catch (Exception e)
            {
                throw;
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
                throw;
            }

        }


    }
}
