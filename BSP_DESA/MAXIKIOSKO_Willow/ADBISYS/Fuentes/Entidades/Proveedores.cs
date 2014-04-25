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
    class Proveedores
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql = "";

        public DataSet obtenerProveedores()
        {
            try
            {
                cadenaSql = "EXEC adp_obtener_proveedores";
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }

        public DataSet obtenerCamposProveedores()
        {
            try
            {
                cadenaSql = "EXEC adp_cboBusqueda_proveedores";
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }

        public DataSet obtenerInfoRubros()
        {
            try
            {
                cadenaSql = "EXEC adp_info_rubros";
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }

        public DataSet obtenerMaximoProveedor()
        {
            try
            {
                cadenaSql = "EXEC adp_maximo_proveedor";
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }

        public void eliminarProveedor(string id_Proveedor)
        {
            try
            {
                cadenaSql = "EXEC adp_eliminar_proveedor @Id_Proveedor = " + id_Proveedor;
                objConect.ejecutarQuery(cadenaSql);

                cadenaSql = "EXEC adp_reseteoCampoIdentity_proveedores";
                objConect.ejecutarQuery(cadenaSql);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

    }
}
