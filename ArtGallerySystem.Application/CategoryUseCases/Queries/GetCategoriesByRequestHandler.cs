using ArtGallerySystem.Application.CategoryUseCases.Commands;
using ArtGallerySystem.Application.PaintingUseCases.Commands;

namespace ArtGallerySystem.Application.CategoryUseCases.Queries;

internal class GetCategoriesByRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCategoriesByRequest, IEnumerable<Category>>
{
    public async Task<IEnumerable<Category>> Handle(GetCategoriesByRequest request, CancellationToken cancellationToken)
    {
        return await unitOfWork.CategoryRepository.ListAllAsync(cancellationToken);
    }
}
