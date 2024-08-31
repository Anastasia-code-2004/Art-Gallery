using System.Collections.ObjectModel;
using ArtGallerySystem.Application.BankCardUseCases.Commands;
using ArtGallerySystem.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ArtGallerySystem.UI.ViewModels;

[QueryProperty(nameof(ClientId), "ClientId")]
public partial class BankCardViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public int ClientId { get; set; }
    public BankCardViewModel(IMediator mediator)
    {
        _mediator = mediator;
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
    async Task DeleteBankCardAsync(int bankCardId) => await DeleteBankCardHandleAsync(bankCardId);
    [RelayCommand]
    async Task SelectBankCardAsync(BankCard selectedCard) => await SelectBankCardHandleAsync(selectedCard);
    public async Task UpdateBankCardsHandleAsync()
    {
        var bankCards = await _mediator.Send(new GetBankCardsByClientIdRequest(ClientId));
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
            { "ClientId", ClientId}
        };
        await Shell.Current.GoToAsync(nameof(AddBankCardPage), parameters);
    }
    private async Task DeleteBankCardHandleAsync(int bankCardId)
    {
        var result = await _mediator.Send(new DeleteBankCardCommand(bankCardId));
        if (result)
        {
            await UpdateBankCardsHandleAsync();
        }
    }
    private async Task SelectBankCardHandleAsync(BankCard selectedCard)
    {
        SelectedBankCard = selectedCard;
    }
}