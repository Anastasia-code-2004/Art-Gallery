using System.Collections.ObjectModel;
using System.Diagnostics;
using ArtGallerySystem.Application.PaintingUseCases.Commands;
using ArtGallerySystem.Domain.Services;
using ArtGallerySystem.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;

[QueryProperty(nameof(Exhibition), "Exhibition")]
public partial class DetailsExhibitionViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    [ObservableProperty]
    private Exhibition _exhibition;
    public DetailsExhibitionViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    public ObservableCollection<Painting> Paintings { get; set; } = [];
    
    [RelayCommand]
    async Task UpdatePaintingsAsync() => await GetPaintingsAsync();
    
    [RelayCommand]
    async Task BuyTicketAsync() => await GotoBuyTicketPageAsync();
    
    [RelayCommand]
    async Task DetailsPaintingAsync(Painting painting) => await GotoDetailsPaintingPageAsync(painting);
    private async Task GetPaintingsAsync()
    {
        Debug.WriteLine(Exhibition.Id);
        Debug.WriteLine(Exhibition.Name);
        IEnumerable<Painting> paintings = [];
        if (Exhibition != null)
        {
            paintings = await _mediator.Send(new GetPaintingsByExhibitionIdRequest(Exhibition.Id));
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Paintings.Clear();
                foreach (var painting in paintings)
                {
                    Paintings.Add(painting);
                }
            });
        }
    }   
    private async Task GotoBuyTicketPageAsync()
    {
        if(UserService.GetCurrentUser() != null)
        {
            if(UserService.GetCurrentUser() as Client != null)
            {
                IDictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Exhibition", Exhibition}
                };
                await Shell.Current.GoToAsync(nameof(BuyTicketPage), parameters);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Only clients can buy tickets", "OK");
            }
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Error", "You must be logged in to buy a ticket", "OK");
        }
    }
    private async Task GotoDetailsPaintingPageAsync(Painting painting)
    {
        IDictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "Painting", painting}
        };
        await Shell.Current.GoToAsync(nameof(DetailsPaintingPage), parameters);
    }
}