using DAL_EJ01;
using Ejercicio01T10.VM.Utils;
using ENT;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ejercicio02Maui.VM
{
    public class listadoVM : INotifyPropertyChanged
    {
        #region Atributos
        private ObservableCollection<clsPersona> listaPersonas;
        private DelegateCommand mostrarLista;
        private DelegateCommand ocultarLista;
        private String errorDB;
        private Boolean muestraError;
        private Boolean muestraLista;
        #endregion

        #region Propiedades
        public ObservableCollection<clsPersona> ListaPersonas { get { return listaPersonas; } }

        public DelegateCommand MostrarLista { get { return mostrarLista; } }

        public DelegateCommand OcultarLista { get { return ocultarLista; } }

        public String ErrorDB { get { return errorDB; } }

        public Boolean MuestraError
        {
            get;
        }

        public Boolean MuestraLista
        {
            get { return muestraLista; }
            set
            {
                if (muestraLista != value)
                {
                    muestraLista = value;
                    NotifyPropertyChanged();
                }
                mostrarLista.RaiseCanExecuteChanged();
                ocultarLista.RaiseCanExecuteChanged();
            }
        }
        #endregion

        #region Constructores
        public listadoVM()
        {
            try
            {
                listaPersonas = new ObservableCollection<clsPersona>(ListadoDAL.listadoCompletoPersonasDAL());
            }
            catch (Exception ex)
            {
                errorDB = "Error con la BD";
                muestraError = true;
                NotifyPropertyChanged("ErrorDB");
                NotifyPropertyChanged("MuestraError");
            }

            mostrarLista = new DelegateCommand(MostrarCommand_Executed, MostrarCommand_CanExecute);
            ocultarLista = new DelegateCommand(OcultarCommand_Executed, OcultarCommand_CanExecute);
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Función que muestra la lista
        /// </summary>
        private void MostrarCommand_Executed()
        {
            // Cambiar el valor de muestraLista cuando se ejecuta el comando
            MuestraLista = true;
            NotifyPropertyChanged("MuestraLista");
        }

        /// <summary>
        /// Función que devuelve si el botón mostrar esta habilitado o deshabilitado
        /// </summary>
        /// <returns>Devuelve si está habilitado o deshabilitado</returns>
        public bool MostrarCommand_CanExecute()
        {
            return !muestraLista;
        }

        /// <summary>
        /// Función que oculta la lista
        /// </summary>
        private void OcultarCommand_Executed()
        {
            MuestraLista = false;
            NotifyPropertyChanged("MuestraLista");
        }

        /// <summary>
        /// Función que devuelve si el botón ocultar esta habilitado o deshabilitado
        /// </summary>
        /// <returns>Devuelve si está habilitado o deshabilitado</returns>
        public bool OcultarCommand_CanExecute()
        {
            return muestraLista;
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
