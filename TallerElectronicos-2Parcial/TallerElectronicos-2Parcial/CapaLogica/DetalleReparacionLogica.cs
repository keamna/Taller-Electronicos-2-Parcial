using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TallerElectronicos_2Parcial.CapaLogica
{
    public class DetalleReparacionLogica
    {
        public static int AgregarDetalleReparacion(int reparacionID, string descripcionReparacion, string fechaInicio, string fechaFin)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ingresarDetalleReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ReparacionID", reparacionID));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", descripcionReparacion));
                    cmd.Parameters.Add(new SqlParameter("@FechaInicio", fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@FechaFin", fechaFin));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = 0;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int BorrarDetalleReparacion(int detalleID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("borrarDetalleReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@DetalleID", detalleID));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = 0;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }


        public static int ModificarDetalleReparacion(int detalleID, int reparacionID, string descripcionDetalleReparacion, string fechaInicio, string fechaFin)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("modificarDetalleReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@DetalleID", detalleID));
                    cmd.Parameters.Add(new SqlParameter("@ReparacionID", reparacionID));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", descripcionDetalleReparacion));
                    cmd.Parameters.Add(new SqlParameter("@FechaInicio", fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@FechaFin", fechaFin));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = 0;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
    }
}
