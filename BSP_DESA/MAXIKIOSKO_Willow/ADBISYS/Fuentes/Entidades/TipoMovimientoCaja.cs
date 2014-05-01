using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADBISYS.Entidades
{
    public class TipoMovimientoCaja
    {
        private Int32 ID_TipoMovimiento;
        private String Descripcion;
        private Int32 entradaSalida; //1 Ingreso - 0 Salida

        public Int32 m_ID_TipoMovimiento
        {
            get { return ID_TipoMovimiento; }
            set { ID_TipoMovimiento = value; }
        }

        public String m_Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public Int32 m_entradaSalida
        {
            get { return entradaSalida; }
            set { entradaSalida = value; }
        }
    }
}
