using MiMascota.ViewModels;

namespace MiMascota.Views;

public partial class DashboardAdopcionesPage : ContentPage
{
    DashboardAdopcionesViewModel vm;
    public DashboardAdopcionesPage()
	{
		InitializeComponent();
        vm = new DashboardAdopcionesViewModel();
        BindingContext = vm;

        PremiumCV.SelectionChanged += OnUserSelected;
    }
    async void OnUserSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is DatosPublicacion user)
        {
            // Deseleccionamos para poder volver a seleccionar el mismo después
            ((CollectionView)sender).SelectedItem = null;

            // Navegamos a la página de detalle
            await Navigation.PushAsync(new DetallesAdopcion(new DetallesAdopcionViewModel(user)));
        }
    }
}