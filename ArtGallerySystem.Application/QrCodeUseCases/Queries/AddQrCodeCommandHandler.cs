using ArtGallerySystem.Application.QrCodeUseCases.Commands;
using ArtGallerySystem.Application.TicketUseCases.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Application.QrCodeUseCases.Queries
{
    internal class AddQrCodeCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddQrCodeCommand, QrCode>
    {
        public async Task<QrCode> Handle(AddQrCodeCommand request, CancellationToken cancellationToken)
        {
            var qrcode = new QrCode(request.ExhibitionId, request.ClientId, request.MembershipId);
            await unitOfWork.QrCodeRepository.AddAsync(qrcode, cancellationToken);
            await unitOfWork.SaveAllAsync();
            qrcode = await unitOfWork.QrCodeRepository.GetByIdAsync(qrcode.Id, cancellationToken);
            return qrcode;
        }
    }
}

