namespace ArtGallerySystem.Application.ExhibitionUseCases.Commands;

public sealed record AddExhibitionCommand(string Name, string Description, 
    DateTime StartDate, DateTime EndDate, decimal TicketPrice) : IRequest<Exhibition>
{
    
}

