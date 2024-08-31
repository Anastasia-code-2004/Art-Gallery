namespace ArtGallerySystem.Application.BankCardUseCases.Commands;

public sealed record DeleteBankCardCommand(int Id) : IRequest<bool>
{
    
}