namespace MiMascota.Views;

public partial class RegistroPage : ContentPage
{
    private bool isPasswordVisible = false;

    public RegistroPage()
	{
		InitializeComponent();
	}

    private void TogglePasswordButton_Clicked(object sender, EventArgs e)
    {
        isPasswordVisible = !isPasswordVisible;
        PasswordEntry.IsPassword = !isPasswordVisible;
        TogglePasswordButton.Source = isPasswordVisible ? "eye_open.png" : "eye_closed.png";
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        var rut = RutEntry.Text;
        var nombre = NombreEntry.Text;
        var correo = CorreoEntry.Text;
        var telefono = TelefonoEntry.Text;
        var password = PasswordEntry.Text;

        // Validaciones simples
        if (string.IsNullOrWhiteSpace(rut) || string.IsNullOrWhiteSpace(nombre) ||
            string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Por favor, completa los campos obligatorios.", "OK");
            return;
        }

        // Aquí puedes conectar con tu backend o guardar localmente
        await DisplayAlert("Registro", $"Usuario {nombre} registrado con éxito.", "OK");

        // Opcional: navegación post-registro
        // await Navigation.PushAsync(new LoginPage());
    }



}