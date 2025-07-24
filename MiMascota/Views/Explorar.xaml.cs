// Explorar.xaml.cs
#if ANDROID
using AndroidX.Lifecycle;
#elif IOS
#endif

using CommunityToolkit.Maui.Views;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using MiMascota.Models;
using MiMascota.ViewModels;
using System;
using System.Linq;

namespace MiMascota.Views
{
    public partial class Explorar : ContentPage
    {
        public ExplorarViewModel ViewModel => (ExplorarViewModel)BindingContext;
        public Explorar()
        {
            InitializeComponent();
        }

        private void CarouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            var currentItem = e.CurrentItem;
            foreach (var kvp in ViewModel.MediaElementsByItem)
            {
                if (kvp.Value == null) continue;
                if (Equals(kvp.Key, currentItem))
                {
                    kvp.Value.SeekTo(TimeSpan.Zero);
                    kvp.Value.Play();
                    ViewModel.CurrentMedia = kvp.Value;
                }
                else
                {
                    kvp.Value.Pause();
                }
            }
        }

        private void OnMediaElementLoaded(object sender, EventArgs e)
        {
            if (sender is MediaElement mediaElement && mediaElement.BindingContext != null)
            {
                ViewModel.MediaElementsByItem[mediaElement.BindingContext] = mediaElement;
            }
        }


        private void CarouselView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            if (e.VerticalDelta != 0)
            {
                var direction = e.VerticalDelta > 0 ? 1 : -1;
                AnimateTransition(direction);
            }
        }
        private void OnReactionClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.BindingContext is VideoItem video)
            {
                if (Enum.TryParse<Reaction>(btn.CommandParameter?.ToString(), out var reaction))
                {

                     
                    ViewModel.React((video, reaction)); // ? Correcto

                }
            }
        }

        private async void OnShareClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.BindingContext is VideoItem video)
            {
                await Share.RequestAsync(new ShareTextRequest
                {
                    Title = "Compartir video",
                    Text = video.VideoUrl
                });
            }
        }
        private async void AnimateTransition(int direction)
        {
            if (carouselView.VisibleViews.Count > 0)
            {
                var nextView = carouselView.VisibleViews[0];
                nextView.Opacity = 0;
                nextView.TranslationY = 100 * direction;
                await Task.WhenAll(
                    nextView.FadeTo(1, 300),
                    nextView.TranslateTo(0, 0, 300, Easing.CubicOut)
                );
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // Pausar todos los videos cuando se abandona la página
            ViewModel.CurrentMedia = null;
        }
    }
}