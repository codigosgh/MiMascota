using MiMascota.Servicios;

namespace MiMascota.Views;

public partial class LoginPage : ContentPage
{
    private bool isPasswordVisible = false;
    private readonly Comun _comun;

    public LoginPage()
	{
		InitializeComponent();
        _comun = new Comun();   
	}

    private void TogglePasswordButton_Clicked(object sender, EventArgs e)
    {
        isPasswordVisible = !isPasswordVisible;
        PasswordEntry.IsPassword = !isPasswordVisible;
        TogglePasswordButton.Source = isPasswordVisible ? "eye_open.png" : "eye_closed.png";
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var username = UsernameEntry.Text;
        var password = PasswordEntry.Text;

        if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
        {
            int userId = username == "admin" ? 1 : 0;
            _comun.setSession(userId);

            _comun.CambiarVisibilidadFlyouts(true);
            await Shell.Current.GoToAsync("///MainTabBar/Perfil", true);
        }
        else
        {
            await DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
        }
    }



    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("/RegistroPage");
    }


    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("/RecuperarPassPage");
    }



}