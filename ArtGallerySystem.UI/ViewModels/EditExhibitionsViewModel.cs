using System.Collections.ObjectModel;
using ArtGallerySystem.Application.ExhibitionUseCases.Commands;
using ArtGallerySystem.Application.PaintingUseCases.Commands;
using ArtGallerySystem.UI.Pages;
using ArtGallerySystem.UI.Pages.Admin;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;

public partial class EditExhibitionsViewModel : ObservableObject
{
    private readonly IMediator _mediator;

    public EditExhibitionsViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    public ObservableCollection<Exhibition> Exhibitions { get; set; } = [];
    public ObservableCollection<Painting> Paintings { get; set; } = [];
    
    [ObservableProperty]
    Exhibition selectedExhibition;
    
    [RelayCommand]
    async Task UpdateExhibitionsAsync() => await GetExhibitionsAsync();
    
    [RelayCommand]
    async Task UpdatePaintingsAsync() => await GetPaintingsAsync();

    [RelayCommand]
    async Task AddExhibitionAsync() => await GotoAddExhibitionPageAsync();
    
    [RelayCommand]
    async Task DeleteExhibitionAsync(int exhId) => await DeleteExhibitionHandleAsync(exhId);
    
    [RelayCommand]
    async Task EditExhibitionAsync(int exhId) => await GotoEditExhibitionPageAsync(exhId);
    
    [RelayCommand]
    async Task DetailsPaintingAsync(int paintingId) => await GotoDetailsPaintingPageAsync(paintingId);
    public async Task GetExhibitionsAsync()
    {
        var exhibitions = await _mediator.Send(new GetExhibitionsByRequest());
        await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Exhibitions.Clear();
                foreach (var exhibition in exhibitions)
                {
                    Exhibitions.Add(exhibition);
                }
            }
        );
    }
    private async Task GetPaintingsAsync()
    {
        IEnumerable<Painting> paintings = [];
        if (SelectedExhibition != null)
        {
            paintings = await _mediator.Send(new GetPaintingsByExhibitionIdRequest(SelectedExhibition.Id));
        }
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Paintings.Clear();
            foreach (var painting in paintings)
            {
                Paintings.Add(painting);
            }
        });
    }
    private async Task GotoAddExhibitionPageAsync()
    {
        var paintings = await _mediator.Send(new GetPaintingsByRequest());
        if (paintings.All(p => p.ExhibitionId != 0)) 
        {
            await App.Current.MainPage.DisplayAlert("Error", "No available paintings to add to the exhibition", "OK");
            return;
        }
        await Shell.Current.GoToAsync(nameof(AddExhibitionPage));
    }
    private async Task DeleteExhibitionHandleAsync(int exhId)
    {
        await _mediator.Send(new DeleteExhibitionCommand(exhId));
        var paintings = await _mediator.Send(new GetPaintingsByExhibitionIdRequest(exhId));
        foreach (var painting in paintings)
        {
            painting.RemoveExhibition();
            await _mediator.Send(new UpdatePaintingCommand(painting));
        }
        await GetExhibitionsAsync();
        Paintings.Clear();
    }
    private async Task GotoEditExhibitionPageAsync(int exhId)
    {
        await Shell.Current.GoToAsync(nameof(EditExhibitionPage), new Dictionary<string, object>
        {
            { "ExhibitionId", exhId}
        });
    }
    private async Task GotoDetailsPaintingPageAsync(int paintingId)
    {
        var painting = await _mediator.Send(new GetPaintingByIdRequest(paintingId));
        IDictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "Painting", painting}
        };
        await Shell.Current.GoToAsync(nameof(DetailsPaintingPage), parameters);
    }
}