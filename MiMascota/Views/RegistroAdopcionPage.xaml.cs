using MiMascota.Servicios;

namespace MiMascota.Views;

public partial class RegistroAdopcionPage : ContentPage
{
    private readonly Comun _comun;
    public RegistroAdopcionPage()
	{
        InitializeComponent();
        _comun = new Comun();
        tipoPicker.ItemsSource = new List<string> { "Perro", "Gato", "Conejo", "Tortuga", "Otro" };
        regionPicker.ItemsSource = new List<string>(comunasPorRegion.Keys);   
    }
    Dictionary<string, List<string>> comunasPorRegion = new()
    {
        { "Región Metropolitana", new List<string> { "Santiago", "Maipú", "Puente Alto", "La Florida" } },
        { "Valparaíso", new List<string> { "Valparaíso", "Viña del Mar", "Quilpué" } },
        { "Biobío", new List<string> { "Concepción", "Talcahuano", "Chillán" } },
    };
    private async void OnRegistrarClicked(object sender, EventArgs e)
    {
        string tipo = (string)tipoPicker.SelectedItem;
        string nombreMascota = nombreEntry.Text;
        string raza = razaEntry.Text;
        string chip = chipEntry.Text;
        string direccionMascota = direccionMascotaEntry.Text;
        string telefonoMascota = telefonoMascotaEntry.Text;

        string nombreDueno = nombreDuenoEntry.Text;
        string region = (string)regionPicker.SelectedItem;
        string comuna = (string)comunaPicker.SelectedItem;
        string direccionDueno = direccionDuenoEntry.Text;
        string telefonoDueno = telefonoDuenoEntry.Text;

        if (string.IsNullOrWhiteSpace(nombreMascota) || string.IsNullOrWhiteSpace(nombreDueno) || tipo == null || region == null || comuna == null)
        {
            await DisplayAlert("Error", "Por favor completa todos los campos requeridos.", "OK");
            return;
        }

        // Aquí podrías guardar los datos en una base de datos o enviarlos a una API

        await DisplayAlert("Registro Exitoso", $"Mascota '{nombreMascota}' registrada con dueño '{nombreDueno}'.", "OK");
    }

    private void OnRegionChanged(object sender, EventArgs e)
    {
        if (regionPicker.SelectedItem != null &&
            comunasPorRegion.TryGetValue(regionPicker.SelectedItem.ToString(), out var comunas))
        {
            comunaPicker.ItemsSource = comunas;
            comunaPicker.SelectedIndex = 0;
        }
    }
}