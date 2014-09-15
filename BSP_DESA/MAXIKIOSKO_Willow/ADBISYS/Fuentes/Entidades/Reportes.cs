using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADBISYS.Conexion;
using System.Data;
using ADBISYS.Entidades;
using ADBISYS.FuncionesGenerales;

namespace ADBISYS.Entidades
{
    class Reportes
    {
       public DataSet obtenerItemsEliminados(DateTime fecha, string tabla) 
        {
            try
            {
                ConectarBD con = new ConectarBD();
                DataSet Ds = new DataSet();
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

                String sSQL = "";
                sSQL = "EXEC dbo.adp_items_eliminados @Fecha = " + fg.fcSql(fecha.ToString(), "DATETIME");
                if (tabla != "")
                { sSQL = sSQL + ", @tabla = " + fg.fcSql(tabla, "STRING"); }
                Ds = con.ejecutarQuerySelect(sSQL);

                return Ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }
    }
}
