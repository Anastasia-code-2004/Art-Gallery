using ArtGallerySystem.Application.TicketUseCases.Commands;

namespace ArtGallerySystem.Application.TicketUseCases.Queries;

internal class AddTicketCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddTicketCommand, Ticket>
{
    public async Task<Ticket> Handle(AddTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket(request.ExhibitionId, request.ClientId, request.CategoryId, request.Price, request.PurchaseTime);
        await unitOfWork.TicketRepository.AddAsync(ticket, cancellationToken);
        await unitOfWork.SaveAllAsync();
        ticket = await unitOfWork.TicketRepository.GetByIdAsync(ticket.Id, cancellationToken);

        return ticket;
    }
}