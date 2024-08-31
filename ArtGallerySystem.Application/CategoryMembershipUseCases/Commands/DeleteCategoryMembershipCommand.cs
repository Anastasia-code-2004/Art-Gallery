namespace ArtGallerySystem.Application.CategoryMembershipUseCases.Commands;

public sealed record DeleteCategoryMembershipCommand(int Id) : IRequest<bool>
{
    
}