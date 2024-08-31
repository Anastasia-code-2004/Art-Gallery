namespace ArtGallerySystem.Application.ExhibitionUseCases.Commands;

public sealed record EditExhibitionCommand(Exhibition Exhibition) : IRequest<Exhibition>
{
    
}