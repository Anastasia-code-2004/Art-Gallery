namespace ArtGallerySystem.Application.BankCardUseCases.Commands;

public sealed record AlreadyExistBankCardCommand(string CardNumber, int CliendId) : IRequest<bool>
{ }