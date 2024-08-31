namespace ArtGallerySystem.Application.ExhibitionUseCases.Commands;

public sealed record GetExhibitionByIdRequest(int Id) : IRequest<Exhibition>
{
    
}
