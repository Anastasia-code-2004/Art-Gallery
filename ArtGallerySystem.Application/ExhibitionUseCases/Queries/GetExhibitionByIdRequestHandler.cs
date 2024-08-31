using ArtGallerySystem.Application.ExhibitionUseCases.Commands;

namespace ArtGallerySystem.Application.ExhibitionUseCases.Queries;

internal class GetExhibitionByIdRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetExhibitionByIdRequest, Exhibition>
{
    public async Task<Exhibition> Handle(GetExhibitionByIdRequest request, CancellationToken cancellationToken)
    {
        return await unitOfWork.ExhibitionRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}


