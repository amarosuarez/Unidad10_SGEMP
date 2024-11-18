using Ejercicio01_Maui.Views;

namespace Ejercicio01_Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new AppShell();
            MainPage = new Conexion();
        }
    }
}
