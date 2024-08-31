using ArtGallerySystem.Application.CategoryUseCases.Commands;

namespace ArtGallerySystem.Application.CategoryUseCases.Queries;

internal class GetCategoryByIdRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCategoryByIdRequest, Category>
{
    public async Task<Category> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
    {
        return await unitOfWork.CategoryRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}
