using ArtGallerySystem.Application.ExhibitionUseCases.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.UI.Pages;

namespace ArtGallerySystem.UI.ViewModels
{
    public partial class ExhibitionsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public ExhibitionsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public ObservableCollection<Exhibition> Exhibitions { get; set; } = [];

        [RelayCommand]
        async Task UpdateExhibitionsAsync() => await GetExhibitionsAsync();

        [RelayCommand]
        async Task ViewExhibitionAsync(Exhibition exhibition) => await GotoDetailsExhibitionPageAsync(exhibition);
        public async Task GetExhibitionsAsync()
        {
            var exhibitions = await _mediator.Send(new GetExhibitionsByRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                    Exhibitions.Clear();
                    foreach (var exhibition in exhibitions)
                    {
                        if(exhibition.EndDate >= DateTime.Now) Exhibitions.Add(exhibition);

                    }
            }
            );
        }
        private async Task GotoDetailsExhibitionPageAsync(Exhibition exhibition)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "Exhibition", exhibition}
            };
            await Shell.Current.GoToAsync(nameof(DetailsExhibitionPage), parameters);
        }
    }
}
