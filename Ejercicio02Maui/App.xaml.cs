using Ejercicio02Maui.Views;

namespace Ejercicio02Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ListaPersonas();
        }
    }
}
