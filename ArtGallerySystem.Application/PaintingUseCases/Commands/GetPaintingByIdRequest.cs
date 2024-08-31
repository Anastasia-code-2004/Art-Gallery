namespace ArtGallerySystem.Application.PaintingUseCases.Commands;

public sealed record GetPaintingByIdRequest(int Id) : IRequest<Painting>
{
}
