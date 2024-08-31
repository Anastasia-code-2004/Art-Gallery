using ArtGallerySystem.Application.CategoryMembershipUseCases.Commands;

namespace ArtGallerySystem.Application.CategoryMembershipUseCases.Queries;

internal class GetCategoriesMembershipByRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCategoriesMembershipByRequest, IEnumerable<CategoryMembership>>
{
    public async Task<IEnumerable<CategoryMembership>> Handle(GetCategoriesMembershipByRequest request, CancellationToken cancellationToken)
    {
        return await unitOfWork.CategoryMembershipRepository.ListAllAsync(cancellationToken);
    }
}
