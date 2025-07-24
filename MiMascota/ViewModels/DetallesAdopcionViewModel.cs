using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiMascota.ViewModels
{
    public class DetallesAdopcionViewModel : BaseViewModel
    {
   
        public DatosPublicacion PublicacionSeleccionada { get; }
        public ObservableCollection<DatosPublicacion> Friends { get; }
        public ObservableCollection<string> Photos { get; }

        public ICommand EditCommand { get; }

        public DetallesAdopcionViewModel(DatosPublicacion user)
        {
            PublicacionSeleccionada = user;

            //EditCommand = new RelayCommand(() =>
            //{
            //    Application.Current.MainPage.DisplayAlert("Edit", $"Editar {user.Name}", "OK");
            //});

            // Dummy friends (puedes reciclar UserItem)
            Friends = new ObservableCollection<DatosPublicacion>(new[]
            {
                new DatosPublicacion { Name="Amanda Winston", PhotoUrl="https://i.pravatar.cc/100?img=5" }
            });

            // Dummy photos URLs
            Photos = new ObservableCollection<string>(new[]
            {
                "https://picsum.photos/200/200?random=11",
                "https://picsum.photos/200/200?random=12",
                "https://picsum.photos/200/200?random=13",
            });
        }
    }
}
