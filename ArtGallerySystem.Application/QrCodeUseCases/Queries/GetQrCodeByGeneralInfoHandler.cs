using ArtGallerySystem.Application.QrCodeUseCases.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Application.QrCodeUseCases.Queries
{
    internal class GetQrCodeByGeneralInfoHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetQrCodeByGeneralInfo, QrCode>
    {
        public async Task<QrCode> Handle(GetQrCodeByGeneralInfo request, CancellationToken cancellationToken)
        {
            var qc = await unitOfWork.QrCodeRepository.ListAsync(t => t.ClientId == request.ClientId && t.ExhibitionId == request.ExhibitionId &&
            t.MembershipId == request.MembershipId, cancellationToken,
            t => t.Exhibition,
            t => t.Client,
            t => t.Membership);
            return qc.FirstOrDefault();
        }
    }
}
