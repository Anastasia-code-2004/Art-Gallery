using System.Collections.ObjectModel;
using ArtGallerySystem.Application.CategoryMembershipUseCases.Commands;
using ArtGallerySystem.Application.MembershipUseCases.Commands;
using ArtGallerySystem.Domain.Services;
using ArtGallerySystem.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;


public partial class MembershipViewModel : ObservableObject
{
    private readonly IMediator _mediator;

    public MembershipViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    public ObservableCollection<CategoryMembership> CategoryMemberships { get; set; } = [];

    [RelayCommand]
    async Task UpdateCategoryMembershipsAsync() => await GetCategoryMembershipsAsync();
    [RelayCommand]
    async Task BuyMembershipAsync(CategoryMembership category) => await GotoBuyMembershipPageAsync(category);
    public async Task GetCategoryMembershipsAsync()
    {
        var categoryMemberships = await _mediator.Send(new GetCategoriesMembershipByRequest());
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            CategoryMemberships.Clear();
            foreach (var categoryMembership in categoryMemberships)
            {
                CategoryMemberships.Add(categoryMembership);
            }
        }
        );
    }
    private async Task GotoBuyMembershipPageAsync(CategoryMembership category)
    {
        if(UserService.GetCurrentUser() as Client != null)
        {
            var membership = await _mediator.Send(new GetMembershipByClientIdRequest(UserService.GetCurrentUser().Id));
            if (membership == null)
            {
                IDictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "CategoryMembership", category }
                };
                await Shell.Current.GoToAsync(nameof(BuyMembershipPage), parameters);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "You already have a membership", "OK");
            }   
        }
    }
}