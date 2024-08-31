using ArtGallerySystem.Application.PaintingUseCases.Commands;

namespace ArtGallerySystem.Application.PaintingUseCases.Queries;

internal class GetPaintingByIdRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPaintingByIdRequest, Painting>
{
    public async Task<Painting> Handle(GetPaintingByIdRequest request, CancellationToken cancellationToken)
    {
        return await unitOfWork.PaintingRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}
