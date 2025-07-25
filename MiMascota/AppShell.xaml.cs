using MiMascota.Views;

namespace MiMascota
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RegistroPage), typeof(RegistroPage));
            Routing.RegisterRoute(nameof(RecuperarPassPage), typeof(RecuperarPassPage));
            Routing.RegisterRoute(nameof(EditarPerfil), typeof(EditarPerfil));

        }





    }
}
