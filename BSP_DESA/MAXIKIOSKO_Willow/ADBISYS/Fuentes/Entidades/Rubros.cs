using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADBISYS.Conexion;

namespace ADBISYS.Entidades
{
    class Rubros
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql,usuario = "";

        public void nuevoRubro(string descripcion)
        {
            try
            {
                usuario = Properties.Settings.Default.UsuarioLogueado.ToString();

                cadenaSql = "EXEC adp_nuevo_rubro";
                cadenaSql = cadenaSql + " @Rubro_Descripcion = " + fg.fcSql(descripcion, "String");
                cadenaSql = cadenaSql + ",@Rubro_Login = " + fg.fcSql(usuario, "String");

                objConect.ejecutarQuery(cadenaSql);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }

        public DataSet obtenerMaximoRubro()
        {
            try
            {
                cadenaSql = "EXEC adp_maximo_rubro";
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public DataSet verificarRubro(string codigo, string descripcion)
        {
            try
            {
                cadenaSql = "EXEC adp_verifico_rubro_existente @Rubro_Descripcion = " + fg.fcSql(descripcion, "String");
                cadenaSql = cadenaSql + ",@ID_RUBRO = " + fg.fcSql(codigo, "String");
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public DataSet obtenerRubros()
        {
            try
            {
                cadenaSql = "EXEC adp_obtener_rubros";
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }

        public void modificarRubro(string codigo_rubro,string descripcion)
        {
            try
            {
                usuario = Properties.Settings.Default.UsuarioLogueado.ToString();

                cadenaSql = "EXEC adp_modificar_rubro";
                cadenaSql = cadenaSql + " @ID_RUBRO = " + fg.fcSql(codigo_rubro, "String");
                cadenaSql = cadenaSql + ",@RUBRO_DESCRIPCION = " + fg.fcSql(descripcion, "String");
                if (usuario != "")
                { cadenaSql = cadenaSql + ",@RUBRO_LOGIN = " + fg.fcSql(usuario, "String"); }
                objConect.ejecutarQuery(cadenaSql); 
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public void eliminarRubro(string id_Rubro)
        {
            try
            {
                cadenaSql = "EXEC adp_eliminar_rubro @Id_Rubro = " + id_Rubro;
                objConect.ejecutarQuery(cadenaSql);

                cadenaSql = "EXEC adp_reseteoCampoIdentity_rubros";
                objConect.ejecutarQuery(cadenaSql);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public DataSet verificoRubroDelProveedor(string id_Rubro)
        {
            try
            {
                cadenaSql = "EXEC adp_verificar_rubro_proveedor @Id_Rubro = " + id_Rubro;
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public DataSet obtenerCamposRubros()
        {
            try
            {
                cadenaSql = "EXEC adp_cboBusqueda_rubros";
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
