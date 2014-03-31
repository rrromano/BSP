using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADBISYS.Entidades
{
    class ArticuloVenta
    {
        private long id_venta;
        private long id_item;
        private long id_articulo;
        private int cantidad;
        private double precio_venta;

        public long m_id_venta
        {
            get { return id_venta; }
            set { id_venta = value; }
        }

        public long m_id_item
        {
            get { return id_item; }
            set { id_item = value; }
        }

        public long m_id_articulo
        {
            get { return id_articulo; }
            set { id_articulo = value; }
        }

        public int m_cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public double m_precio_venta
        {
            get { return precio_venta; }
            set { precio_venta = value; }
        }
    }
}
