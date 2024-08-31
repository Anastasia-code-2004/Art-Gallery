using ArtGallerySystem.Domain.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using ArtGallerySystem.UI.Pages;
using ArtGallerySystem.UI.Pages.Admin;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels
{
    [QueryProperty(nameof(Admin), "Admin")]
    public partial class AdminProfileViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public AdminProfileViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        [ObservableProperty]
        Admin _admin;
        
        [RelayCommand]
        async Task GetClientsAsync() => await GotoClientsPageAsync();
        
        [RelayCommand]
        async Task GetPaintingsAsync() => await GotoEditCollectionPageAsync();
        
        [RelayCommand]
        async Task GetExhibitionsAsync() => await GotoExhibitionsPageAsync();
        
        [RelayCommand]
        async Task GotoTicketCategoriesPageAsync() => await Shell.Current.GoToAsync(nameof(TicketCategoriesPage));

        [RelayCommand]
        async Task EditMembershipsAsync() => await Shell.Current.GoToAsync(nameof(EditMembershipsPage));

        [RelayCommand]
        async Task LogOutAsync() => await LogOutHandleAsync();

        [RelayCommand]
        async Task ScanAsync() => await Shell.Current.GoToAsync(nameof(ScanningPage));
        private async Task GotoClientsPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(ClientsPage));
        }
        private async Task GotoEditCollectionPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(EditCollectionPage));
        }
        private async Task GotoExhibitionsPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(EditExhibitionsPage));
        }
        private async Task LogOutHandleAsync()
        {
            UserService.SetCurrentUser(null);
            await Shell.Current.GoToAsync($"//{nameof(LogInPage)}");
        }
    }
}
