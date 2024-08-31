using System.Collections.ObjectModel;
using ArtGallerySystem.Application.ExhibitionUseCases.Commands;
using ArtGallerySystem.Application.PaintingUseCases.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stripe;

namespace ArtGallerySystem.UI.ViewModels;

[QueryProperty(nameof(ExhibitionId), "ExhibitionId")]
public partial class EditExhibitionViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public int ExhibitionId { get; set; }
    [ObservableProperty]
    Exhibition _exhibition;
    public ObservableCollection<Painting> Paintings { get; set; } = [];

    public EditExhibitionViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    [RelayCommand]
    void UpdateExhibitionInfo() => GetExhibitionInfo();
    [RelayCommand]
    async Task EditExhibitionAsync() => await EditExhibitionHandleAsync();
    private async void GetExhibitionInfo()
    {
        Exhibition = await _mediator.Send(new GetExhibitionByIdRequest(ExhibitionId));
        var paintings = await _mediator.Send(new GetPaintingsByRequest());
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Paintings.Clear();
            foreach (var painting in paintings)
            {
                if(painting.ExhibitionId == 0 || painting.ExhibitionId == ExhibitionId) 
                    Paintings.Add(painting);
            }
        }
        );
    }
    private async Task EditExhibitionHandleAsync()
    {
        if(string.IsNullOrWhiteSpace(Exhibition.Name) || string.IsNullOrWhiteSpace(Exhibition.Description) 
            || string.IsNullOrWhiteSpace(Exhibition.TicketPrice.ToString()))
        {
            await App.Current.MainPage.DisplayAlert("Error", "Please fill all fields", "OK");
            return;
        }
        if(Exhibition.StartDate > Exhibition.EndDate)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Invalid dates", "OK");
            return;
        }
        if (Exhibition.TicketPrice <= 0 || Exhibition.TicketPrice.ToString().Split(',').Length > 1 
            && Exhibition.TicketPrice.ToString().Split(',')[1].Length > 2)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Invalid price", "OK");
            return;
        }
        if (!Paintings.Any(p => p.IsInExhibition))
        {
            await App.Current.MainPage.DisplayAlert("Error", "Please select at least one painting", "OK");
            return;
        }
        var exhibition = await _mediator.Send(new EditExhibitionCommand(Exhibition));
        foreach (var painting in Paintings)
        {
            if (painting.IsInExhibition)
            {
                painting.SetExhibition(exhibition.Id);
                await _mediator.Send(new UpdatePaintingCommand(painting));
            }
            else
            {
                painting.RemoveExhibition();
                await _mediator.Send(new UpdatePaintingCommand(painting));
            }
        }
        await Shell.Current.GoToAsync("..");
    }
    
}