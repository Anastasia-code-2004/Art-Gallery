using System.Collections.ObjectModel;
using ArtGallerySystem.Application.BankCardUseCases.Commands;
using ArtGallerySystem.Application.MembershipUseCases.Commands;
using ArtGallerySystem.Application.TicketUseCases.Commands;
using ArtGallerySystem.Domain.Services;
using ArtGallerySystem.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ArtGallerySystem.Application.ExhibitionUseCases.Commands;
using ArtGallerySystem.Application.QrCodeUseCases.Commands;
using ArtGallerySystem.Domain.Abstractions;

namespace ArtGallerySystem.UI.ViewModels;

[QueryProperty(nameof(ExhibitionId), "ExhibitionId")]
[QueryProperty(nameof(CategoryId), "CategoryId")]
[QueryProperty(nameof(Price), "Price")]
[QueryProperty(nameof(Membership), "Membership")]
public partial class ChooseCardViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    private readonly IPaymentService _paymentService;
    public int ExhibitionId { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }

    [ObservableProperty]
    private bool _isProcessingPayment = false;

    [ObservableProperty]
    private Membership _membership;
    
    public ChooseCardViewModel(IMediator mediator, IPaymentService paymentService)
    {
        _mediator = mediator;
        _paymentService = paymentService;
    }
    public ObservableCollection<BankCard> BankCards { get; set; } = [];
    [ObservableProperty]
    BankCard _selectedBankCard;
    [ObservableProperty]
    private string _cardNumber;
    [ObservableProperty]
    private string _expirationDate;
    [ObservableProperty]
    private string _cvv;
    [RelayCommand]
    async Task UpdateBankCardsAsync() => await UpdateBankCardsHandleAsync();
    [RelayCommand]
    async Task AddBankCardAsync() => await AddBankCardHandleAsync();
    [RelayCommand]
    async Task CompletePaymentAsync() => await CompletePaymentHandleAsync();
    [RelayCommand]
    async Task SelectBankCardAsync(BankCard selectedBankCard) => await SelectBankCardHandleAsync(selectedBankCard);
    public async Task UpdateBankCardsHandleAsync()
    {
        var bankCards = await _mediator.Send(new GetBankCardsByClientIdRequest(UserService.GetCurrentUser().Id));
        await MainThread.InvokeOnMainThreadAsync(() =>
            {
                BankCards.Clear();
                foreach (var bankCard in bankCards)
                {
                    BankCards.Add(bankCard);
                }
            }
        );
    }
    private async Task AddBankCardHandleAsync()
    {
        IDictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "ClientId", UserService.GetCurrentUser().Id}
        };
        await Shell.Current.GoToAsync(nameof(AddBankCardPage), parameters);
    }
    private async Task CompletePaymentHandleAsync()
    {
        if(Membership != null)
        {
            if(SelectedBankCard != null)
            {
                long amount = (long)(Price * 100);
                var res = await Pay(amount);
                if (!res)
                {
                    await Shell.Current.GoToAsync("//MembershipPage");
                    return;
                }
                
                var membership = await _mediator.Send(new AddMembershipCommand(Membership.ClientId, Membership.CategoryMembershipId, Membership.StartDate, Membership.EndDate));
                var exhibitions = await _mediator.Send(new GetExhibitionsByRequest());
                if (exhibitions != null)
                {
                    foreach (var exhibition in exhibitions)
                    {
                        if (exhibition.EndDate >= DateTime.Now)
                        {
                            await _mediator.Send(new AddQrCodeCommand(exhibition.Id, UserService.GetCurrentUser().Id, membership.Id));
                        }
                    }
                }
                await Shell.Current.GoToAsync("//MembershipPage");
            }
        }
        else
        {
            if (SelectedBankCard != null)
            {
                var amount = (long)(Price * 100);
                var res = await Pay(amount);
                if (!res)
                {
                    await Shell.Current.GoToAsync("//ExhibitionsPage");
                    return;
                }
                await _mediator.Send(new AddTicketCommand(ExhibitionId, UserService.GetCurrentUser().Id, CategoryId, Price, DateTime.Now));
                await Shell.Current.GoToAsync("//ExhibitionsPage");
            }
        }
        
    }
    private async Task SelectBankCardHandleAsync(BankCard selectedBankCard)
    {
        SelectedBankCard = selectedBankCard;
        CompletePaymentHandleAsync();
    }
    private async Task<bool> Pay(long amount)
    {
        try
        {
            IsProcessingPayment = true;
            string testToken = "pm_card_by";
            string currency = "byn";

            string paymentStatus = await _paymentService.CreateAndConfirmPaymentIntent(testToken, amount, currency);

            if (paymentStatus == "succeeded")
            {
                IsProcessingPayment = false;
                string message = "Payment completed successfully";
                ToastDuration duration = ToastDuration.Short;
                double fontSize = 14;
                var toast = Toast.Make(message, duration, fontSize);
                await toast.Show();
                return true;
            }
            else if (paymentStatus == "requires_action")
            {
                IsProcessingPayment = false;
                await App.Current.MainPage.DisplayAlert("Action Required", "Additional action is required to complete the payment.", "OK");
            }
            else
            {
                IsProcessingPayment = false;
                await App.Current.MainPage.DisplayAlert("Error", $"Payment failed with status: {paymentStatus}", "OK");
            }
        }
        catch (Exception ex)
        {
            IsProcessingPayment = false;
            await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
        return false;
    }
}