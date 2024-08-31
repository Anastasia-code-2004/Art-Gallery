using ArtGallerySystem.Application.CategoryMembershipUseCases.Commands;

namespace ArtGallerySystem.Application.CategoryMembershipUseCases.Queries;

internal class DeleteCategoryMembershipCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryMembershipCommand, bool>
{
    public async Task<bool> Handle(DeleteCategoryMembershipCommand request, CancellationToken cancellationToken)
    {
        var categoryMembership = await unitOfWork.CategoryMembershipRepository.GetByIdAsync(request.Id, cancellationToken);
        if (categoryMembership == null) return false;
        await unitOfWork.CategoryMembershipRepository.DeleteAsync(categoryMembership, cancellationToken);
        await unitOfWork.SaveAllAsync();
        return true;
    }
}
