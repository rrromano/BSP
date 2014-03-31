using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADBISYS.Entidades
{
    public class Ventas
    {
        private long id_venta;
        private int cantidad;
        private double importe;
        private int sino_correcta;
        private DateTime fecha;
        private string hora;

        public long m_id_venta
        {
            get { return id_venta; }
            set { id_venta = value; }
        }

        public int m_cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public double m_importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public int m_sino_correcta
        {
            get { return sino_correcta; }
            set { sino_correcta = value; }
        }

        public DateTime m_fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string m_hora
        {
            get { return hora; }
            set { hora = value; }
        }

    }
}
