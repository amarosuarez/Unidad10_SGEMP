using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DAL_EJ01;
using Ejercicio01T10.VM.Utils;
using Microsoft.Data.SqlClient;

namespace Ejercicio01_Maui.VM
{
    public class conexionVM : INotifyPropertyChanged
    {
        #region Atributos
        private SqlConnection _connection;
        private DelegateCommand abrirCommand;
        private String errorConnection;
        private String conexionMessage;
        #endregion

        #region Propiedades
        public SqlConnection Connection { get { return _connection; } }

        public DelegateCommand AbrirCommand
        {
            get
            {
                return abrirCommand;
            }
        }

        public String ErrorConnection {  get { return errorConnection; } }
        #endregion

        #region Constructores
        public conexionVM()
        {
            // Commands
            abrirCommand = new DelegateCommand(AbrirCommand_Executed);
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Función que intenta abrir una conexión a la base de datos
        /// </summary>
        private void AbrirCommand_Executed()
        {
            // Conexión
            _connection = new SqlConnection();
            try
            {
                _connection = clsConexionDB.getConexion();
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    conexionMessage = "Conexión exitosa";
                }
                else
                {
                    conexionMessage = "Error: la conexión no pudo establecerse";
                }
                NotifyPropertyChanged("ConexionMessage");
            }
            catch (Exception e)
            {
                errorConnection = "Error al conectar";
                NotifyPropertyChanged("ErrorConnection");
            }
            finally
            {
                _connection.Close();
            }
        }
        #endregion

        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
