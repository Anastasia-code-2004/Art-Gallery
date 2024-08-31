using ArtGallerySystem.Application.PaintingUseCases.Commands;

namespace ArtGallerySystem.Application.PaintingUseCases.Queries;

internal class GetPaintingsByRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPaintingsByRequest, IEnumerable<Painting>>
{
    public async Task<IEnumerable<Painting>> Handle(GetPaintingsByRequest request, CancellationToken cancellationToken)
    {
        
        return await unitOfWork.PaintingRepository.ListAllAsync(cancellationToken);
    }
}