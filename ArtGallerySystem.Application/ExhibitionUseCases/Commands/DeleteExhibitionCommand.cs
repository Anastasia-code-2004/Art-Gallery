namespace ArtGallerySystem.Application.ExhibitionUseCases.Commands;

public sealed record DeleteExhibitionCommand(int Id) : IRequest<bool>
{
    
}
