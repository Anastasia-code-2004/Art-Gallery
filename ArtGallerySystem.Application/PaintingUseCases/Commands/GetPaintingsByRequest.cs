namespace ArtGallerySystem.Application.PaintingUseCases.Commands;

public sealed record GetPaintingsByRequest : IRequest<IEnumerable<Painting>>
{
}
