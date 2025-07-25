using System.Text;

namespace MiMascota.Views;

public partial class RecuperarPassPage : ContentPage
{
	public RecuperarPassPage()
	{
		InitializeComponent();
        
    }

    private async void OnSendClicked(object sender, EventArgs e)
    {
        var email = EmailEntry.Text;

        if (string.IsNullOrWhiteSpace(email))
        {
            await DisplayAlert("Error", "Por favor, ingresa un correo válido.", "OK");
            return;
        }

        // Llamada al backend para enviar correo de recuperación
        var httpClient = new HttpClient();
        var content = new StringContent($"{{\"email\":\"{email}\"}}", Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("https://tuservidor.com/api/auth/forgotpassword", content);

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Éxito", "Se ha enviado un correo con las instrucciones.", "OK");
        }
        else
        {
            await DisplayAlert("Error", "No se pudo enviar el correo. Verifica el email.", "OK");
        }
    }


}