using MiMascota.Servicios;

namespace MiMascota.Views;

public partial class PerfilPage : ContentPage
{
	private readonly Comun _comun;
	public PerfilPage()
	{
		InitializeComponent();
		_comun = new Comun();

		_comun.validaSesion();

	}

    private void BtnCerrarSesion_Clicked(object sender, EventArgs e)
    {
		_comun.logout();

    }

    private void Editar_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("/EditarPerfil");

    }

    private void AddMascota_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("/RegistroMascotaPage");
    }
}