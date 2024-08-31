using ArtGallerySystem.Application.BankCardUseCases.Commands;

namespace ArtGallerySystem.Application.BankCardUseCases.Queries;

internal class GetBankCardsByClientIdRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetBankCardsByClientIdRequest, IEnumerable<BankCard>>
{
    public async Task<IEnumerable<BankCard>> Handle(GetBankCardsByClientIdRequest request, CancellationToken cancellationToken)
    {
        return await unitOfWork.BankCardRepository.ListAsync(t => t.ClientId == request.Id, cancellationToken);
    }
}