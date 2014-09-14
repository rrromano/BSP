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
    class Compras
    {
        ConectarBD objConect = new ConectarBD();
        DataSet ds = new DataSet();
        FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
        string cadenaSql = "";

        public DataSet obtenerCompras(DateTime fecha_sistema)
        {
            try
            {
                cadenaSql = "EXEC adp_obtener_compras @fecha_sistema = " + fg.fcSql(fecha_sistema.ToString(),"Datetime");
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public DataSet obtenerMaximaCompra()
        {
            try
            {
                cadenaSql = "EXEC adp_maxima_compra";
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }

        public DataSet obtenerInfoProveedores()
        {
            try
            {
                cadenaSql = "EXEC adp_info_proveedores";
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }

        public void eliminarCompra(string id_compra)
        {
            try
            {
                string usuario = Properties.Settings.Default.UsuarioLogueado.ToString();

                cadenaSql = "EXEC adp_eliminar_compra @Id_Compra = " + id_compra;
                if (usuario != "")
                { cadenaSql = cadenaSql + ",@Compra_Login = " + fg.fcSql(usuario, "String"); }

                objConect.ejecutarQuery(cadenaSql);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

        public DataSet obtenerCamposCompras()
        {
            try
            {
                cadenaSql = "EXEC adp_cboBusqueda_Compras";
                ds = objConect.ejecutarQuerySelect(cadenaSql);
                return ds;
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }

        }

        public void actualizar_movimiento_compras(DateTime fecha_sistema)
        {
            try
            {
                cadenaSql = "EXEC adp_actualiza_mov_compras @fecha_sistema = " + fg.fcSql(fecha_sistema.ToString(), "Datetime");
                objConect.ejecutarQuery(cadenaSql);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException("[Error] - [" + e.Message.ToString() + "]");
            }
        }

    }
}
