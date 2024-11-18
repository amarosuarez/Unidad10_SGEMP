namespace ENT
{
    public class clsPersona
    {
        #region Atributos
        private int id;
        private String nombre;
        private String apellidos;
        private long telefono;
        private String direccion;
        private String foto;
        private DateTime fechaNacimiento;
        private int idDepartamento;
        #endregion

        #region Constructores
        public clsPersona(int id, string nombre, string apellidos, long telefono, string direccion, string foto, DateTime fechaNacimiento, int idDepartamento)
        {
            if (id > 0)
            {
                this.id = id;
            }

            if (!string.IsNullOrEmpty(nombre)) {
                this.nombre = nombre;
            }

            if (!String.IsNullOrEmpty(apellidos))
            {
                this.apellidos = apellidos;
            }

            if (telefono > 0)
            {
                this.telefono = telefono;
            }

            if (!string.IsNullOrEmpty(direccion))
            {
                this.direccion = direccion;
            }

            if (!string.IsNullOrEmpty(foto))
            {
                this.foto = foto;
            }

            this.fechaNacimiento = fechaNacimiento;

            if (idDepartamento > 0) { 
                this.idDepartamento = idDepartamento;
            }
        }
        #endregion
    }
}
