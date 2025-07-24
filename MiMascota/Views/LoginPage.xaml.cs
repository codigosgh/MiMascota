namespace MiMascota.Views;

public partial class LoginPage : ContentPage
{
    private bool isPasswordVisible = false;

    public LoginPage()
	{
		InitializeComponent();
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

        // Aquí iría la validación o llamada al backend
        if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Login", $"Bienvenido, {username}", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
        }
    }
}