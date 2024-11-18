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
            List<clsPersona> listadoPersonas;

            // TODO get from DB

            return listadoPersonas;
        }

    }
}
