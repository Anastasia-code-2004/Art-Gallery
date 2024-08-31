namespace ArtGallerySystem.Application.CategoryUseCases.Commands;

public sealed record GetCategoryByIdRequest(int Id) : IRequest<Category>
{
    
}