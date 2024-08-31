using ArtGallerySystem.Application.BankCardUseCases.Commands;
using ArtGallerySystem.Application.PaintingUseCases.Commands;

namespace ArtGallerySystem.Application.BankCardUseCases.Queries;

internal class AddBankCardCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddBankCardCommand, BankCard>
{
    public async Task<BankCard> Handle(AddBankCardCommand request, CancellationToken cancellationToken)
    {
        var bankCard = new BankCard(request.CardNumber, request.CVV, request.ExpiryDate);
        bankCard.SetClient(request.ClientId);
        await unitOfWork.BankCardRepository.AddAsync(bankCard, cancellationToken);
        await unitOfWork.SaveAllAsync();
        bankCard = await unitOfWork.BankCardRepository.GetByIdAsync(bankCard.Id, cancellationToken);
        return bankCard;
    }
}

