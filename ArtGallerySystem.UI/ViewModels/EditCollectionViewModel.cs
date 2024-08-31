using System.Collections.ObjectModel;
using System.Diagnostics;
using ArtGallerySystem.Application.PaintingUseCases.Commands;
using ArtGallerySystem.UI.Pages.Admin;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;

public partial class EditCollectionViewModel : ObservableObject
{
    private readonly IMediator _mediator;

    public EditCollectionViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    public ObservableCollection<Painting> Paintings { get; set; } = [];
    
    [RelayCommand]
    public async Task UpdatePaintingsAsync() => await GetPaintingsAsync();
    
    [RelayCommand]
    async Task AddPaintingAsync() => await GotoAddPaintingPageAsync();
    
    [RelayCommand]
    async Task DeletePaintingAsync(Painting painting) => await DeletePaintingHandleAsync(painting);
    
    [RelayCommand]
    async Task EditPaintingAsync(Painting painting) => await GotoEditPaintingPageAsync(painting);
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
    private async Task GotoAddPaintingPageAsync()
    {
        await Shell.Current.GoToAsync(nameof(AddPaintingPage));
    }
    private async Task DeletePaintingHandleAsync(Painting painting)
    {
        var result = await _mediator.Send(new DeletePaintingCommand(painting.Id));
        if (result)
        {
            await GetPaintingsAsync();
        }
    }
    private async Task GotoEditPaintingPageAsync(Painting painting)
    {
        IDictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "PaintingId", painting.Id}
        };
        await Shell.Current.GoToAsync(nameof(EditPaintingPage), parameters);
        
    }
}