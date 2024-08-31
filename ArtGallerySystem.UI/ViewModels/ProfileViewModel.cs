using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallerySystem.UI.Pages;
using CommunityToolkit.Mvvm.Input;
using QRCoder;
using ArtGallerySystem.Domain.Services;

namespace ArtGallerySystem.UI.ViewModels
{
    [QueryProperty(nameof(Client), "Client")]
    public partial class ProfileViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public ProfileViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        Client _client;

        [RelayCommand]
        async Task GetBankCardsAsync() => await GetBankCardsHandleAsync();

        [RelayCommand]
        async Task GetTicketsAsync() => await GotoTicketsForClientPage();

        [RelayCommand]
        async Task GetQrCodeAsync() => await GetQrCodeHandleAsync();
        [RelayCommand]
        async Task LogOutAsync() => await LogOutHandleAsync();
        private async Task GetBankCardsHandleAsync()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "ClientId", Client.Id}
            };
            await Shell.Current.GoToAsync(nameof(BankCardPage), parameters);
        }
        private async Task GotoTicketsForClientPage()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "ClientId", Client.Id}
            };
            await Shell.Current.GoToAsync(nameof(TicketsForClientPage), parameters);
        }
        private async Task GetQrCodeHandleAsync()
        {
            await Shell.Current.GoToAsync(nameof(QrCodePage));
        }
        private async Task LogOutHandleAsync()
        {
            UserService.SetCurrentUser(null);
            await Shell.Current.GoToAsync($"//{nameof(LogInPage)}");
        }
    }
}
