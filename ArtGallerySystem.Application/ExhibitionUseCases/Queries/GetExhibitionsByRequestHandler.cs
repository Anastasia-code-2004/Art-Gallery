using ArtGallerySystem.Application.ExhibitionUseCases.Commands;

namespace ArtGallerySystem.Application.ExhibitionUseCases.Queries;

internal class GetExhibitionsByRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetExhibitionsByRequest, IEnumerable<Exhibition>>
{
    public async Task<IEnumerable<Exhibition>> Handle(GetExhibitionsByRequest request, CancellationToken cancellationToken)
    {
        return await unitOfWork.ExhibitionRepository.ListAllAsync(cancellationToken);
    }
}
