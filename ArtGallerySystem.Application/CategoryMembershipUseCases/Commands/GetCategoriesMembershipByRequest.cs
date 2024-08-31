namespace ArtGallerySystem.Application.CategoryMembershipUseCases.Commands;

public sealed record GetCategoriesMembershipByRequest : IRequest<IEnumerable<CategoryMembership>>
{
    
}