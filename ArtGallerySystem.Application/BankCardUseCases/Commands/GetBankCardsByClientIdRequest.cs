namespace ArtGallerySystem.Application.BankCardUseCases.Commands;

public sealed record GetBankCardsByClientIdRequest(int Id) : IRequest<IEnumerable<BankCard>>
{
    
}