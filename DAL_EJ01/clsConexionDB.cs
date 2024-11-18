using Microsoft.Data.SqlClient;

namespace DAL_EJ01
{
    public class clsConexionDB
    {
        public static SqlConnection getConexion()
        {
            SqlConnection miConexion = new SqlConnection();

            try
            {

                miConexion.ConnectionString = "server=maro.database.windows.net;database=amaroDB;uid=usuario;pwd=LaCampana123;trustServerCertificate = true;";

                miConexion.Open();

            }
            catch (Exception ex)
            {
                throw;
            }

            return miConexion;
        }


    }
}
