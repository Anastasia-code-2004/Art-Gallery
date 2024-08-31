using ArtGallerySystem.Application.BankCardUseCases.Commands;

namespace ArtGallerySystem.Application.BankCardUseCases.Queries;

internal class AlreadyExistCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AlreadyExistBankCardCommand, bool>
{
    public async Task<bool> Handle(AlreadyExistBankCardCommand request, CancellationToken cancellationToken)
    {
        var bankCard = await unitOfWork.BankCardRepository.FirstOrDefaultAsync(bc => bc.CardNumber == request.CardNumber && 
            bc.ClientId == request.CliendId, cancellationToken);
        return bankCard != null;
    }
}