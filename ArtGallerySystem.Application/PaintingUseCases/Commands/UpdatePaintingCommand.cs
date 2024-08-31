namespace ArtGallerySystem.Application.PaintingUseCases.Commands;

public sealed record UpdatePaintingCommand(Painting Painting) : IRequest<Painting>
{
}
