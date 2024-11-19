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
            clsPersona persona;

            try
            {
                conexion = clsConexionDB.getConexion();
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    miComando.CommandText = "SELECT * FROM personas";
                    miComando.Connection = conexion;
                    miLector = miComando.ExecuteReader();

                    if (miLector.HasRows)
                    {
                        while (miLector.Read())
                        {
                            persona = new clsPersona();
                            persona.Id = (int)miLector["ID"];
                            persona.Nombre = (string) miLector["Nombre"];
                            persona.Apellidos = (string) miLector["Apellidos"];
                            persona.Telefono = (string) miLector["Telefono"];
                            persona.Direccion = (string) miLector["Direccion"];
                            persona.Foto = (string) miLector["Foto"];
                            persona.FechaNacimiento = (DateTime) miLector["FechaNacimiento"];
                            persona.IdDepartamento = (int) miLector["IDDepartamento"];
                            listadoPersonas.Add(persona);
                        }
                    }
                    miLector.Close();
                }
            } catch (SqlException ex) {
                throw ex;
            } finally {
                conexion.Close();
            }

            return listadoPersonas;
        }

    }
}
