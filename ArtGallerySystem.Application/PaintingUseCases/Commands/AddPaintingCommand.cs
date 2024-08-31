namespace ArtGallerySystem.Application.PaintingUseCases.Commands;

public sealed record AddPaintingCommand(string Name, string Author, string Description, int YearOfCreation, byte [] Photo) : IRequest<Painting>
{
    
}
