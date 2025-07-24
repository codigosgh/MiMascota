using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using MiMascota.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MiMascota.ViewModels
{
    public class ExplorarViewModel : INotifyPropertyChanged
    {
        private string _positionIndicator;
        private int _currentPosition;
        public Dictionary<object, MediaElement> MediaElementsByItem { get; } = new();
        public ICommand ReactCommand { get; }

        public ObservableCollection<VideoItem> Videos { get; } = new ObservableCollection<VideoItem>();
        public ICommand LikeCommand { get; }
        private MediaElement _currentMedia;
        public ICommand ToggleDescriptionCommand => new Command<VideoItem>(item =>
        {
            if (item != null)
            {
                item.IsDescriptionExpanded = !item.IsDescriptionExpanded;

            }
        });

        public ExplorarViewModel()
        {
            // Comandos
            ReactCommand = new Command<(VideoItem, Reaction)>(React);
            LoadVideos();
            CurrentPosition = 0;
        }
        public string PositionIndicator
        {
            get => _positionIndicator;
            set { _positionIndicator = value; OnPropertyChanged(); }
        }

        public int CurrentPosition
        {
            get => _currentPosition;
            set { _currentPosition = value; PositionIndicator = $"{value + 1}/{Videos.Count}"; }

        }
        public MediaElement CurrentMedia
        {
            get => _currentMedia;
            set
            {
                if (_currentMedia != null) _currentMedia.Pause();
                _currentMedia = value;
                if (_currentMedia != null) _currentMedia.Play();
            }
        }
        
       
        private void LoadVideos()
        {

            Videos.Add(new VideoItem
            {
                VideoUrl = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4",
                UserName = "@mascotalover",
                Description = "Mi perro jugando en el parque asd asda sdas dasd asdasdas dasd asd as d asd asd  asd  asd asd asd sad ada 🐶❤️ #perros #juegos"
            });

            Videos.Add(new VideoItem
            {
                VideoUrl = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4",
                UserName = "@gatitosworld",
                Description = "Gatito aprendiendo trucos nuevos asd ada dasd asda das dasdas das sadasdas dasd sdas dasds ds das dada 😺✨ #gatos #mascotas"
            });

            Videos.Add(new VideoItem
            {
                VideoUrl = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerBlazes.mp4",
                UserName = "@exoticpets",
                Description = "Mi loro cantando una canción asdasd asdasd asdasd asdasd  asdasda sdas dasd a asda d asdas dad a🦜🎵 #loros #avesexoticas"
            });

            Videos.Add(new VideoItem
            {
                VideoUrl = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4",
                UserName = "@acuario_magico",
                Description = "Peces tropicales en mi acuario asdas da asda sdas dasd asd asda sdas d🐠🌊 #peces #acuario"
            });

            CurrentPosition = 0;
        }
        public void React((VideoItem video, Reaction reaction) input)
        {
            input.video.SelectedReaction = input.reaction;

            // Opcional: notificar el cambio si quieres que se actualice visualmente
            OnPropertyChanged(nameof(Videos));
        }

        private void LikeVideo(VideoItem video)
        {
            //video.Likes++;
            //video.IsLiked = k!video.IsLiked;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}