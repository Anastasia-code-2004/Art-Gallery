using ArtGallerySystem.Domain.Services;
using ArtGallerySystem.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;

[QueryProperty(nameof(CategoryMembership), "CategoryMembership")]
public partial class BuyMembershipViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    
    [ObservableProperty]
    CategoryMembership _categoryMembership;
    
    [ObservableProperty]
    Membership _membership;
    
    public BuyMembershipViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    [RelayCommand]
    async Task UpdateInfo() => await UpdateInfoHandleAsync();
    [RelayCommand]
    async Task BuyMembershipAsync() => await BuyMembershipHandleAsync();
    private async Task UpdateInfoHandleAsync()
    {
        Membership membership = new();
        membership.ClientId = UserService.GetCurrentUser().Id;
        membership.CategoryMembershipId = CategoryMembership.Id;
        membership.StartDate = DateTime.Now;
        membership.EndDate = DateTime.Now.AddMonths(CategoryMembership.Duration);
        Membership = membership;
    }
    private async Task BuyMembershipHandleAsync()
    {
        IDictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "Membership", Membership},
            { "Price", CategoryMembership.Price}
        };
        await Shell.Current.GoToAsync(nameof(ChooseCardPage), parameters);
    }
}