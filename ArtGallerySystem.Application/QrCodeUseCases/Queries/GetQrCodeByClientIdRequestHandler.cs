using ArtGallerySystem.Application.QrCodeUseCases.Commands;
using ArtGallerySystem.Application.TicketUseCases.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Application.QrCodeUseCases.Queries
{
    internal class GetQrCodeByClientIdRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetQrCodeByClientIdRequest, IEnumerable<QrCode>>
    {
        public async Task<IEnumerable<QrCode>> Handle(GetQrCodeByClientIdRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.QrCodeRepository.ListAsync(t => t.ClientId == request.Id, cancellationToken,
            t => t.Exhibition,
            t => t.Client,
            t => t.Membership);
        }
    }
}
