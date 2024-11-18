using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EJ01
{
    public class ListadoDAL
    {
        /// <summary>
        /// Esta función estática devuelve un listado de personas de la base de datos de azure.
        /// </summary>
        /// <returns>Listado de personas</returns>
        public static List<clsPersona> listadoCompletoPersonasDAL()
        {
            List<clsPersona> listadoPersonas = new List<clsPersona>();


            // TODO get from DB
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            try
            {
                sqlConnection = clsConexionDB.getConexion();


            }
            finally {
                sqlConnection.Close();
            }

            return listadoPersonas;
        }

    }
}
