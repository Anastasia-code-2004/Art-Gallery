namespace ArtGallerySystem.Application.PaintingUseCases.Commands;

public sealed record GetPaintingsByExhibitionIdRequest(int Id) : IRequest<IEnumerable<Painting>>
{
    
}