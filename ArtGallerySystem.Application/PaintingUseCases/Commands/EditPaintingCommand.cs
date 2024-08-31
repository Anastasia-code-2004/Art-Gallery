namespace ArtGallerySystem.Application.PaintingUseCases.Commands;

public sealed record EditPaintingCommand(Painting Painting) : IRequest<Painting>
{
    
}