using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
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


            
            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            try
            {
                conexion = clsConexionDB.getConexion();
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    // TODO recorrer la BD

                }
            }
            finally {
                conexion.Close();
            }

            return listadoPersonas;
        }

    }
}
