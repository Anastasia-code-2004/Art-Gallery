namespace ArtGallerySystem.Application.PaintingUseCases.Commands;

public sealed record DeletePaintingCommand(int Id) : IRequest<bool>
{
    
}