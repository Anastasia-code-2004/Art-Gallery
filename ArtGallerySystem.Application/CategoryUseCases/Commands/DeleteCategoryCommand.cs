namespace ArtGallerySystem.Application.CategoryUseCases.Commands;

public sealed record DeleteCategoryCommand(int Id) : IRequest<bool>
{
    
}