using ArtGallerySystem.Application.TicketUseCases.Commands;

namespace ArtGallerySystem.Application.TicketUseCases.Queries;

internal class GetTicketsByClientIdRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetTicketsByClientIdRequest, IEnumerable<Ticket>>
{
    public async Task<IEnumerable<Ticket>> Handle(GetTicketsByClientIdRequest request, CancellationToken cancellationToken)
    {
        return await unitOfWork.TicketRepository.ListAsync(t => t.ClientId == request.Id, cancellationToken,
            t => t.Exhibition,
            t => t.Client,
            t => t.Category);
    }
}

    