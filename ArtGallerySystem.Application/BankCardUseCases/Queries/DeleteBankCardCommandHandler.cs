using ArtGallerySystem.Application.BankCardUseCases.Commands;
using ArtGallerySystem.Application.PaintingUseCases.Commands;

namespace ArtGallerySystem.Application.BankCardUseCases.Queries;

internal class DeleteBankCardCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteBankCardCommand, bool>
{
    public async Task<bool> Handle(DeleteBankCardCommand request, CancellationToken cancellationToken)
    {
        var bankCard = await unitOfWork.BankCardRepository.GetByIdAsync(request.Id, cancellationToken);
        if(bankCard == null) return false;
        await unitOfWork.BankCardRepository.DeleteAsync(bankCard, cancellationToken);
        await unitOfWork.SaveAllAsync();
        return true;
    }
}