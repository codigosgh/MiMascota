/* ------------------- VideoItem.cs --------------------- */
using System.ComponentModel;

namespace MiMascota.Models
{

    public class VideoItem : INotifyPropertyChanged
    {
        public string VideoUrl { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public Reaction UserReaction { get; set; }


        private Reaction _selectedReaction = Reaction.None;
        public Reaction SelectedReaction
        {
            get => _selectedReaction;
            set
            {
                _selectedReaction = value;
                OnPropertyChanged(nameof(SelectedReaction));
            }
        }
        private bool _isDescriptionExpanded;
        public bool IsDescriptionExpanded
        {
            get => _isDescriptionExpanded;
            set
            {
                if (_isDescriptionExpanded != value)
                {
                    _isDescriptionExpanded = value;
                    OnPropertyChanged(nameof(IsDescriptionExpanded));
                    OnPropertyChanged(nameof(DescriptionLimited));
                }
            }
        }


        public string DescriptionLimited
        {
            get
            {
                if (string.IsNullOrEmpty(Description)) return "";

                if (IsDescriptionExpanded)
                    return Description + " (ver menos)";

                const int maxLength = 140;
                return Description.Length > maxLength
                    ? Description.Substring(0, maxLength).Trim() + "... (ver más)"
                    : Description;
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }


}