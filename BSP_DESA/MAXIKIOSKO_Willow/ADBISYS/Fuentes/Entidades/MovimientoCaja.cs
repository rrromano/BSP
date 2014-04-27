using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADBISYS.Conexion;
using ADBISYS.Entidades;
using ADBISYS.FuncionesGenerales;
using System.Data;

namespace ADBISYS.Entidades
{
    public class MovimientoCaja
    {
        private Int32 Id;
        private Int32 Id_tipoMovimiento;
        private String descripcion;
        private Double valor;
        private DateTime fecha;
        private String hora;
        private Int32 entradaSalida; //1 Ingreso - 0 Salida

        public Int32 m_Id 
        {
            get { return Id;  }
            set { Id = value; }
        }

        public Int32 m_entradaSalida
        {
            get { return entradaSalida; }
            set { entradaSalida = value; }
        }

        public Int32 m_Id_tipoMovimiento
        {
            get { return Id_tipoMovimiento; }
            set { Id_tipoMovimiento = value; }
        }

        public String m_descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public double m_valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public DateTime m_fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public String m_hora
        {
            get { return hora; }
            set { hora = value; }
        }

        public void modificarCajaInicial(DateTime Fecha,  String Valor)
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                ConectarBD con = new ConectarBD();
                String sSQL;

                sSQL = "exec adp_modificarCajaInicial ";
                sSQL = sSQL + " @fecha = " + fg.fcSql(Fecha.ToString(), "DATETIME");
                sSQL = sSQL + " ,@Valor = " + fg.fcSql(Valor, "DOUBLE");
                con.ejecutarQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException(e.Message.ToString());
            }

        }

        public void registrarMovimientosCaja(DateTime Fecha, String Hora)
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                ConectarBD con = new ConectarBD();
                String sSQL;

                sSQL = "exec adp_registrar_movimientosCaja ";
                sSQL = sSQL + " @fecha = " + fg.fcSql(Fecha.ToString(), "DATETIME");
                sSQL = sSQL + ",@hora  = " + fg.fcSql(Hora, "STRING");
                con.ejecutarQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException(e.Message.ToString());
            }


        }

        public void registrarMovimientoCaja(int tipoMovimiento, String descripcion, Double valor, DateTime fecha, String hora)
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                ConectarBD con = new ConectarBD();
                String sSQL;

                sSQL = "exec adp_registrar_mov_caja ";
                sSQL = sSQL + "  @Tipo_Movimiento = " + fg.fcSql(tipoMovimiento.ToString(), "STRING");
                sSQL = sSQL + " ,@Descripcion     = " + fg.fcSql(descripcion, "STRING");
                sSQL = sSQL + " ,@Valor           = " + fg.fcSql(valor.ToString(), "DOUBLE");
                sSQL = sSQL + " ,@fecha           = " + fg.fcSql(fecha.ToString(), "DATETIME");
                sSQL = sSQL + " ,@hora            = " + fg.fcSql(hora, "STRING");

                con.ejecutarQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new System.ArgumentException(e.Message.ToString());
            }

        }

        internal int ObtenerId_TipoMovimiento(int Id_Movimiento)
        {
            try
            {
                FuncionesGenerales.FuncionesGenerales fg = new FuncionesGenerales.FuncionesGenerales();
                ConectarBD con = new ConectarBD();
                DataSet Ds = new DataSet();
                String sSQL;
                int ID;

                sSQL = "exec dbo.adp_obtenerId_TipoMovimientoCaja ";
                sSQL = sSQL + "  @ID_Movimiento = " + Id_Movimiento;

                Ds.Reset();
                Ds = con.ejecutarQuerySelect(sSQL);

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    ID = int.Parse(Ds.Tables[0].Rows[0]["ID_TipoMovimiento"].ToString());
                }
                else
                {
                    throw new System.ArgumentException("Error al intentar obtener el ID tipo Movimiento Caja");
                }

                return ID;
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message.ToString());
            }
        }
    }
}
