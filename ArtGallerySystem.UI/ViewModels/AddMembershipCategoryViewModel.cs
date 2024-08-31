using ArtGallerySystem.Application.CategoryMembershipUseCases.Commands;
using ArtGallerySystem.Application.CategoryUseCases.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;

public partial class AddMembershipCategoryViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public AddMembershipCategoryViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ObservableProperty] private string _name;
    [ObservableProperty] private string _description;
    [ObservableProperty] private string _price;
    [ObservableProperty] private string _duration;
    
    [RelayCommand]
    async Task AddCategoryAsync() => await AddCategoryHandleAsync();
    private async Task AddCategoryHandleAsync()
    {
        if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Description))
        {
            await App.Current.MainPage.DisplayAlert("Error", "Please fill all fields", "OK");
            return;
        }
        if (!decimal.TryParse(Price, out _))
        {
            await App.Current.MainPage.DisplayAlert("Error", "Invalid price", "OK");
            return;
        }
        if (!int.TryParse(Duration, out _))
        {
            await App.Current.MainPage.DisplayAlert("Error", "Invalid duration", "OK");
            return;
        }
        if(decimal.Parse(Price) < 0 || decimal.Parse(Price) == 0 ||
        Price.Split(',').Length > 1 && Price.Split(',')[1].Length > 2)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Invalid price", "OK");
            return;
        }
        if(int.Parse(Duration) < 0 || int.Parse(Duration) > 12)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Invalid duration", "OK");
            return;
        }
        await _mediator.Send(new AddCategoryMembershipCommand(Name, Description, decimal.Parse(Price), 
            int.Parse(Duration)));
        await Shell.Current.Navigation.PopAsync();
    }
}