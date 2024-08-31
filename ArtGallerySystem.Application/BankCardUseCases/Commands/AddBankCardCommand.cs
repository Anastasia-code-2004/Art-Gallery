namespace ArtGallerySystem.Application.BankCardUseCases.Commands;

public sealed record AddBankCardCommand(string CardNumber, string CVV, string ExpiryDate, int ClientId) : IRequest<BankCard>
{
    
}

