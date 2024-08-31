namespace ArtGallerySystem.Application.CategoryMembershipUseCases.Commands;

public sealed record AddCategoryMembershipCommand(string Name, string Description, 
    decimal Price, int Duration) : IRequest<CategoryMembership>
{
    
}
