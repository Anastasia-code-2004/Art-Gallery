using System.Text.RegularExpressions;
using ArtGallerySystem.Application.BankCardUseCases.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;

[QueryProperty(nameof(ClientId), "ClientId")]
public partial class AddBankCardViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public int ClientId { get; set; }
    public AddBankCardViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ObservableProperty] private string _cardNumber;
    [ObservableProperty] private string _expirationDate;
    [ObservableProperty] private string _cvv;
    [RelayCommand]
    async Task AddBankCardAsync() => await AddBankCardHandleAsync();
    private async Task AddBankCardHandleAsync()
    {
        if (string.IsNullOrWhiteSpace(CardNumber) || string.IsNullOrWhiteSpace(ExpirationDate) || string.IsNullOrWhiteSpace(Cvv))
        {
            await App.Current.MainPage.DisplayAlert("Error", "Please fill all fields", "OK");
            return;
        }
        
        var match = Regex.Match(ExpirationDate, @"^(0[1-9]|1[0-2])\/([0-9]{2})$");
        if (!match.Success)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Invalid expiration date format", "OK");
            return;
        }
        if (CardNumber.Length != 16)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Invalid card number, too short", "OK");
            return;
        }
        var year = int.Parse("20" + match.Groups[2].Value);
        var month = int.Parse(match.Groups[1].Value);
        var lastDayOfMonth = DateTime.DaysInMonth(year, month);
        var cardExpirationDate = new DateTime(year, month, lastDayOfMonth);

        if (cardExpirationDate <= DateTime.Now)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Card has already expired", "OK");
            return;
        }
        bool alreadyExist = await _mediator.Send(new AlreadyExistBankCardCommand(CardNumber, ClientId));
        if (alreadyExist)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Card already exists", "OK");
            return;
        }
        await _mediator.Send(new AddBankCardCommand(CardNumber, Cvv, cardExpirationDate.ToString(), ClientId));
        await Shell.Current.Navigation.PopAsync();
    }
}