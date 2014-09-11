using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ADBISYS.Conexion;

namespace ADBISYS.Entidades
{
    class Venta
    {
        internal System.Data.DataSet obtenerVentas(DateTime Fecha)
        {
            try
            {
                String cadenaSql = "";
                DataSet ds = new DataSet();
                ConectarBD objConect = new ConectarBD();
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

                cadenaSql = "EXEC dbo.adp_obtener_ventas @d_16_fecha = " + fg.fcSql(Fecha.ToString(), "DATETIME");
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }
    }
}
