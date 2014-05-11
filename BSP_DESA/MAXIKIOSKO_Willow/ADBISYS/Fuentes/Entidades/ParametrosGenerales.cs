using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADBISYS.Conexion;             //para la conexion a la base.
using ADBISYS.FuncionesGenerales;
namespace ADBISYS.Entidades
{
    class ParametrosGenerales
    {
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();

        public void modificarEstadoGlobalSistema(Int32 EstadoNuevo)
        {
            try
            {
                ConectarBD con = new ConectarBD();
                String sSQL;

                sSQL = "exec adp_actualizar_estado_global @estado = " + EstadoNuevo.ToString();
                con.ejecutarQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] -  [" + e.Message.ToString() + "]");
            }
        }

        public void modificarFechaSistema(DateTime fechaSistema)
        {
            try
            {
                ConectarBD con = new ConectarBD();
                String sSQL;

                sSQL = "exec adp_FecSis @FECHA = " + fg.fcSql(fechaSistema.ToString(),"String");
                con.ejecutarQuery(sSQL);                
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] -  [" + e.Message.ToString() + "]");
            }
        }
    }
}
