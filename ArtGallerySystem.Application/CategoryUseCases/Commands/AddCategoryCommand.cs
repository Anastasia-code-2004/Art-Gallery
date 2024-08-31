namespace ArtGallerySystem.Application.CategoryUseCases.Commands;

public sealed record AddCategoryCommand(string Name, string Description, int Discount) : IRequest<Category>
{
    
}