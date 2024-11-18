using Ejercicio01_Maui.Views;

namespace Ej01M
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new Conexion();
        }
    }
}
