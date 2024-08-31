using ArtGallerySystem.Application.CategoryUseCases.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;

public partial class AddCategoryViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public AddCategoryViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ObservableProperty] private string _name;
    [ObservableProperty] private string _description;
    [ObservableProperty] private string _discount;
    [RelayCommand]
    async Task AddCategoryAsync() => await AddCategoryHandleAsync();
    private async Task AddCategoryHandleAsync()
    {
        if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Description) || string.IsNullOrWhiteSpace(Discount))
        {
            await App.Current.MainPage.DisplayAlert("Error", "Please fill all fields", "OK");
            return;
        }
        
        
        if (!int.TryParse(Discount, out var discountValue) || discountValue < 0 || discountValue > 100)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Invalid discount", "OK");
            return;
        }
        await _mediator.Send(new AddCategoryCommand(Name, Description, int.Parse(Discount)));
        await Shell.Current.Navigation.PopAsync();
    }
}