namespace ArtGallerySystem.Application.ExhibitionUseCases.Commands;

public sealed record GetExhibitionsByRequest : IRequest<IEnumerable<Exhibition>>
{
    
}