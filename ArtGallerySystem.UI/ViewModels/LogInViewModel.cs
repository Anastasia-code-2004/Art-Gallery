using System.Collections.ObjectModel;
using ArtGallerySystem.Application.AdminUseCases.Commands;
using ArtGallerySystem.Application.ClientUseCases.Commands;
using ArtGallerySystem.Domain.Services;
using ArtGallerySystem.UI.Pages;
using ArtGallerySystem.UI.Pages.Admin;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;

public partial class LogInViewModel : ObservableObject
{
    private readonly IMediator _mediator;

    public LogInViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    [ObservableProperty] private string _emailPhone;
    [ObservableProperty] private string _password;
    
    [RelayCommand]
    async Task LogInAsync() => await LogInUserAsync();

    [RelayCommand]
    async Task RegisterAsync() => await Shell.Current.GoToAsync(nameof(RegisterPage));
    private async Task LogInUserAsync()
    {
        var admin = await _mediator.Send(new Application.AdminUseCases.Commands.LogInUserCommand(EmailPhone, Password));
        var client = await _mediator.Send(new Application.ClientUseCases.Commands.LogInUserCommand(EmailPhone, Password));
        if (admin != null)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "Admin", admin}
            };
            UserService.SetCurrentUser(admin);
            await Shell.Current.GoToAsync(nameof(AdminProfilePage), parameters);
        }
        else if (client != null)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "Client", client}
            };
            UserService.SetCurrentUser(client);
            await Shell.Current.GoToAsync(nameof(ProfilePage), parameters);
        }
        else
        {
            UserService.SetCurrentUser(null);
            await App.Current.MainPage.DisplayAlert("Error", "Invalid email/phone or password", "OK");
        }
    }
}