using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMascota.ViewModels
{
    public class DashboardAdopcionesViewModel
    {
        public ObservableCollection<DatosPublicacion> PremiumPublicaciones { get; set; }
        public ObservableCollection<DatosPublicacion> NearbyUsers { get; set; }
        public ObservableCollection<DatosPublicacion> TopReactedUsers { get; set; }

        public DashboardAdopcionesViewModel()
        {
            var exampleUsers = new List<DatosPublicacion>
    {
        new DatosPublicacion { Name = "Max", PhotoUrl = "https://placedog.net/200/200", IsPremium = true },
        new DatosPublicacion { Name = "Luna", PhotoUrl = "https://placedog.net/200/200?random=1", IsPremium = true },
        new DatosPublicacion { Name = "Toby", PhotoUrl = "https://placedog.net/200/200?random=2", IsPremium = true },
        new DatosPublicacion { Name = "Bella", PhotoUrl = "https://placedog.net/200/200?random=3", IsPremium = false },
        new DatosPublicacion { Name = "Rocky", PhotoUrl = "https://placedog.net/200/200?random=4", IsPremium = false },
        new DatosPublicacion { Name = "Charlie", PhotoUrl = "https://placekitten.com/200/200", IsPremium = true },
        new DatosPublicacion { Name = "Lucy", PhotoUrl = "https://placekitten.com/201/201", IsPremium = false },
        new DatosPublicacion { Name = "Cooper", PhotoUrl = "https://placebear.com/200/200", IsPremium = true },
        new DatosPublicacion { Name = "Daisy", PhotoUrl = "https://placebear.com/200/201", IsPremium = false },
        new DatosPublicacion { Name = "Buddy", PhotoUrl = "https://baconmockup.com/200/200", IsPremium = true },
        new DatosPublicacion { Name = "Molly", PhotoUrl = "https://www.placecage.com/200/200", IsPremium = false },
        new DatosPublicacion { Name = "Bear", PhotoUrl = "https://www.stevensegallery.com/200/200", IsPremium = true },
        new DatosPublicacion { Name = "Zoe", PhotoUrl = "https://picsum.photos/id/237/200/200", IsPremium = false }, // Imagen de perro
        new DatosPublicacion { Name = "Duke", PhotoUrl = "https://picsum.photos/id/200/200/200", IsPremium = true }, // Imagen de animal
        new DatosPublicacion { Name = "Lola", PhotoUrl = "https://picsum.photos/id/433/200/200", IsPremium = false } // Imagen de animal
    };

        PremiumPublicaciones = new ObservableCollection<DatosPublicacion>(exampleUsers.Take(15));
            NearbyUsers = new ObservableCollection<DatosPublicacion>(exampleUsers.Skip(1).Take(13));
            TopReactedUsers = new ObservableCollection<DatosPublicacion>(exampleUsers.Reverse<DatosPublicacion>().Take(10));
        }
    }

    public class DatosPublicacion
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsPremium { get; set; }
    }

}
