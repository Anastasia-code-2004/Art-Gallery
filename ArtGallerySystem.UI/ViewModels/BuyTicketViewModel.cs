using System.Collections.ObjectModel;
using ArtGallerySystem.Application.CategoryUseCases.Commands;
using ArtGallerySystem.Application.TicketUseCases.Commands;
using ArtGallerySystem.Domain.Services;
using ArtGallerySystem.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;

[QueryProperty(nameof(Exhibition), "Exhibition")]
public partial class BuyTicketViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public BuyTicketViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    public ObservableCollection<Category> Categories { get; set; } = [];
    [ObservableProperty] private Exhibition _exhibition;
    [ObservableProperty] private Category _selectedCategory;
    [ObservableProperty] private decimal _discountedPrice;
    
    [RelayCommand]
    async Task UpdateCategoriesAsync() => await UpdateCategoriesHandleAsync();
    
    [RelayCommand]
    async Task UpdatePriceAsync() =>  await UpdatePriceHandleAsync();
    
    [RelayCommand]
    async Task ChooseCardAsync() => await ChooseCardHandleAsync();
    
    private async Task UpdateCategoriesHandleAsync()
    {
        var categories = await _mediator.Send(new GetCategoriesByRequest());
        await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Categories.Clear();
                foreach (var category in categories)
                {
                    Categories.Add(category);
                }
            }
        );
        DiscountedPrice = Exhibition.TicketPrice;
    }
    private async Task UpdatePriceHandleAsync()
    {
        if (SelectedCategory != null)
        {
            DiscountedPrice = Exhibition.TicketPrice - (Exhibition.TicketPrice * SelectedCategory.Discount / 100);
            
        }
    }

    private async Task ChooseCardHandleAsync()
    {
        if (SelectedCategory == null)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Please select a category", "OK");
            return;
        }

        if (UserService.GetCurrentUser() as Client != null)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "ExhibitionId", Exhibition.Id},
                { "CategoryId", SelectedCategory.Id},
                { "Price", DiscountedPrice}
            };
            await Shell.Current.GoToAsync(nameof(ChooseCardPage), parameters);
        }
    }
}


