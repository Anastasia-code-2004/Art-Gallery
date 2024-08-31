namespace ArtGallerySystem.Application.TicketUseCases.Commands;

public sealed record GetTicketsByClientIdRequest(int Id) : IRequest<IEnumerable<Ticket>>
{
    
}