using MiMascota.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMascota.Servicios
{
    public class Comun
    {

        public int ObtenerIdUser()
        {
            int idUser = 0;
            idUser = Preferences.Get("idUser", default(int));
            return idUser;
        }

        public void setSession(int idUser)
        {
            Preferences.Set("idUser", idUser);
        }

        public void logout()
        {
            Preferences.Clear();
            Application.Current.MainPage = new AppShell();
            Shell.Current.GoToAsync($"//{nameof(LoginPage)}", true);
        }

        public void validaSesion()
        {            
            if (ObtenerIdUser()==0)
            {
                Preferences.Clear();
                Application.Current.MainPage = new AppShell();
                Shell.Current.GoToAsync($"//{nameof(LoginPage)}", true);
            }
        }



        public void CambiarVisibilidadFlyouts(bool sesionActiva)
        {
            //LoginPageFlyout.FlyoutItemIsVisible = !sesionActiva;

            //AdoptarMascotaFlyout.FlyoutItemIsVisible = sesionActiva;
            //RegistroMascotalyout.FlyoutItemIsVisible = sesionActiva;
            //RegistroPerdidaFlyout.FlyoutItemIsVisible = sesionActiva;

            //LogoutPageFlyout.FlyoutItemIsVisible = sesionActiva;
        }







    }


}
