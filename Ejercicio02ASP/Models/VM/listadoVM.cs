using DAL_EJ01;
using ENT;

namespace Ejercicio02ASP.Models.VM
{
    public class listadoVM : clsPersona
    {

        public List<clsPersona> personas { get; }

        public listadoVM()
        {
            personas = ListadoDAL.listadoCompletoPersonasDAL();
        }

    }
}
