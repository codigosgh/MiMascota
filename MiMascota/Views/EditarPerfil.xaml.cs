using System.Text;
using System.Text.Json;

namespace MiMascota.Views;

public partial class EditarPerfil : ContentPage
{
	public EditarPerfil()
	{
		InitializeComponent();
        CargarDatosUsuario(); // Puedes llamar al backend o usar almacenamiento local
    }


    private void CargarDatosUsuario()
    {
        // Simulado: reemplaza con los datos reales del usuario
        RutEntry.Text = "12345678-9";
        NombreEntry.Text = "Juan Pérez";
        CorreoEntry.Text = "juan@example.com";
        TelefonoEntry.Text = "+56912345678";
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var rut = RutEntry.Text;
        var nombre = NombreEntry.Text;
        var correo = CorreoEntry.Text;
        var telefono = TelefonoEntry.Text;
        var password = PasswordEntry.Text;

        var datos = new
        {
            Rut = rut,
            Nombre = nombre,
            Correo = correo,
            Telefono = telefono,
            NuevaClave = string.IsNullOrWhiteSpace(password) ? null : password
        };

        var json = JsonSerializer.Serialize(datos);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

       // var http = new HttpClient();
      //  var response = await http.PutAsync("https://tuservidor.com/api/usuarios/editar", content);

       // if (response.IsSuccessStatusCode)
      //  {
            await DisplayAlert("Éxito", "Datos actualizados correctamente.", "OK");

     //   }
     //   else
     //   {
     //       await DisplayAlert("Error", "No se pudieron actualizar los datos.", "OK");
     //   }
    }



}