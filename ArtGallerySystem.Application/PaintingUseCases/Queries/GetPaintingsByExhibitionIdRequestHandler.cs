using ArtGallerySystem.Application.PaintingUseCases.Commands;

namespace ArtGallerySystem.Application.PaintingUseCases.Queries;

internal class GetPaintingsByExhibitionIdRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPaintingsByExhibitionIdRequest, IEnumerable<Painting>>
{
    public async Task<IEnumerable<Painting>> Handle(GetPaintingsByExhibitionIdRequest request, CancellationToken cancellationToken)
    {
        return await unitOfWork.PaintingRepository.ListAsync(t => t.ExhibitionId == request.Id, cancellationToken);
    }
}