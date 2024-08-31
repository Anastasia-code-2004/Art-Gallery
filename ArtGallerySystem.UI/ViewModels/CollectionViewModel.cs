using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.Application.PaintingUseCases.Commands;
using ArtGallerySystem.UI.Pages;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels
{
    public partial class CollectionViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public CollectionViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public ObservableCollection<Painting> Paintings { get; set; } = [];

        [ObservableProperty]
        bool _isRefreshing;

        [RelayCommand]
        async Task UpdatePaintingsAsync() => await GetPaintingsAsync();
        
        [RelayCommand]
        async Task DetailsPaintingAsync(Painting painting) => await GotoDetailsPaintingPageAsync(painting);

        [RelayCommand]
        async Task RefreshAsync() => await UpdateAsync();
        public async Task GetPaintingsAsync()
        {
            var paintings = await _mediator.Send(new GetPaintingsByRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Paintings.Clear();
                    foreach (var painting in paintings)
                    {
                        Paintings.Add(painting);
                    }
                }
            );
        }
        private async Task GotoDetailsPaintingPageAsync(Painting painting)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "Painting", painting}
            };
            await Shell.Current.GoToAsync(nameof(DetailsPaintingPage), parameters);
        }
        private async Task UpdateAsync()
        {
            IsRefreshing = true;
            await GetPaintingsAsync();
            IsRefreshing = false;
        }
    }
}
