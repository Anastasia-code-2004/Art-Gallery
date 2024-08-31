namespace ArtGallerySystem.Application.TicketUseCases.Commands;

public sealed record AddTicketCommand(int ExhibitionId, int ClientId, int CategoryId, decimal Price, DateTime PurchaseTime) : IRequest<Ticket>
{
    
}