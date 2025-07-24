using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Diagnostics;
using Location = Microsoft.Maui.Devices.Sensors.Location;

namespace MiMascota.Views
{
    public partial class MapPublicaciones : ContentPage
    {
        private Location currentLocation;
        private readonly Random random = new Random();
        private Pin marcadorActual;
        private bool modoMarcador = false;

        public MapPublicaciones()
        {
            InitializeComponent();
            btnRecargar.Clicked += async (s, e) => await LoadMap();
            btnUbicacion.Clicked += MoveToCurrentLocation;
            Loaded += async (s, e) => await LoadMap();
        }

        private async Task LoadMap()
        {
            try
            {
                modoMarcador = false;
                lblMarcador.IsVisible = false;

                // Solicitar permiso de ubicación
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }

                if (status == PermissionStatus.Granted)
                {
                    await GetCurrentLocation();
                    AddRandomPins(5);
                }
                else
                {
                    await DisplayAlert("Permiso requerido", "Se necesita acceso a la ubicación", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }

        private async Task GetCurrentLocation()
        {
            try
            {
                currentLocation = await Geolocation.Default.GetLocationAsync();
                if (currentLocation != null)
                {
                    MoveToCurrentLocation(null, null);

                    // Añadir marcador de posición actual
                    var pin = new Pin
                    {
                        Label = "Tú estás aquí",
                        Type = PinType.Generic,
                        Location = new Location(currentLocation.Latitude, currentLocation.Longitude)
                    };
                    myMap.Pins.Add(pin);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error GPS: {ex.Message}");
                await DisplayAlert("Error", "No se pudo obtener la ubicación", "OK");
            }
        }

        private void MoveToCurrentLocation(object sender, EventArgs e)
        {
            if (currentLocation != null)
            {
                myMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Location(currentLocation.Latitude, currentLocation.Longitude),
                    Distance.FromKilometers(0.5)));
            }
        }

        private void AddRandomPins(int count)
        {
            if (currentLocation == null) return;

            for (int i = 0; i < count; i++)
            {
                double latOffset = (random.NextDouble() - 0.5) * 0.02;
                double lonOffset = (random.NextDouble() - 0.5) * 0.02;

                var randomPosition = new Location(
                    currentLocation.Latitude + latOffset,
                    currentLocation.Longitude + lonOffset
                );

                var pin = new Pin
                {
                    Label = $"Mascota {i + 1}",
                    Type = PinType.Place,
                    Location = randomPosition
                };
                myMap.Pins.Add(pin);
            }
        }

        private void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            if (!modoMarcador) return;

            // Eliminar marcador anterior si existe
            if (marcadorActual != null)
            {
                myMap.Pins.Remove(marcadorActual);
            }

            // Crear nuevo marcador
            marcadorActual = new Pin
            {
                Label = "Ubicación marcada",
                Type = PinType.SavedPin,
                Location = e.Location
            };

            myMap.Pins.Add(marcadorActual);

            // Mostrar mensaje con coordenadas
            DisplayAlert("Ubicación marcada",
                         $"Lat: {e.Location.Latitude:F6}\nLon: {e.Location.Longitude:F6}",
                         "OK");
        }

        private void BtnRecargar_Clicked(object sender, EventArgs e)
        {
            // Cambiar a modo marcador
            modoMarcador = !modoMarcador;
            lblMarcador.IsVisible = modoMarcador;

            if (modoMarcador)
            {
                // Cambiar color del botón para indicar modo activo
                btnRecargar.BackgroundColor = Color.FromArgb("#3498db");
                btnRecargar.TextColor = Colors.White;
                DisplayAlert("Modo Marcador", "Toca en el mapa para marcar una ubicación", "OK");
            }
            else
            {
                // Restaurar colores normales
                btnRecargar.BackgroundColor = Colors.White;
                btnRecargar.TextColor = Color.FromArgb("#2c3e50");

                // Eliminar marcador si existe
                if (marcadorActual != null)
                {
                    myMap.Pins.Remove(marcadorActual);
                    marcadorActual = null;
                }
            }
        }

        private void BtnUbicacion_Clicked(object sender, EventArgs e)
        {
            MoveToCurrentLocation(null, null);
        }
    }
}