using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADBISYS.Entidades
{
    public class Articulo_Venta
    {
        private UInt64 id_venta;
        private UInt64 id_item_venta;
        private UInt64 id_articulo;
        private Int32 cantidad;
        private Double precio_venta;


        public UInt64 m_id_venta
        {
            get { return id_venta; }
            set { id_venta = value; }
        }

        public UInt64 m_id_item_venta
        {
            get { return id_item_venta; }
            set { id_item_venta = value; }
        }

        public UInt64 m_id_articulo
        {
            get { return id_articulo; }
            set { id_articulo = value; }
        }

        public Int32 m_cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public Double m_precio_venta
        {
            get { return precio_venta; }
            set { precio_venta = value; }
        }
    }
}
