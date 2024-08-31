using ArtGallerySystem.Application.AdminUseCases.Commands;

namespace ArtGallerySystem.Application.AdminUseCases.Queries
{
    internal class GetAdminsByRequestHandler(IUnitOfWork unitOfWork) :IRequestHandler<GetAdminsByRequest, IEnumerable<Admin>>
    {
        public async Task<IEnumerable<Admin>> Handle(GetAdminsByRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.AdminRepository.ListAllAsync(cancellationToken);
        }
    }
}
