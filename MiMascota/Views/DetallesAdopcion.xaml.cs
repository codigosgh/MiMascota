namespace MiMascota.Views;

public partial class DetallesAdopcion : ContentPage
{
	public DetallesAdopcion(ViewModels.DetallesAdopcionViewModel detallesAdopcionViewModel)
	{
		InitializeComponent();
		BindingContext = detallesAdopcionViewModel;

    }
}