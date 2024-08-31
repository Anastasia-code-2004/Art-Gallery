using ArtGallerySystem.Application.CategoryMembershipUseCases.Commands;

namespace ArtGallerySystem.Application.CategoryMembershipUseCases.Queries;

internal class AddCategoryMembershipCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddCategoryMembershipCommand, CategoryMembership>
{
    public async Task<CategoryMembership> Handle(AddCategoryMembershipCommand request, CancellationToken cancellationToken)
    {
        var categoryMembership = new CategoryMembership(request.Name, request.Description, request.Price, request.Duration);
        await unitOfWork.CategoryMembershipRepository.AddAsync(categoryMembership, cancellationToken);
        await unitOfWork.SaveAllAsync();
        categoryMembership = await unitOfWork.CategoryMembershipRepository.GetByIdAsync(categoryMembership.Id, cancellationToken);
        return categoryMembership;
    }
}