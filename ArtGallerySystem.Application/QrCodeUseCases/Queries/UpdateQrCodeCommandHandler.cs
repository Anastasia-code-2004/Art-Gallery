using ArtGallerySystem.Application.PaintingUseCases.Commands;
using ArtGallerySystem.Application.QrCodeUseCases.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Application.QrCodeUseCases.Queries
{
    internal class UpdateQrCodeCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateQrCodeCommand, QrCode>
    {
        public async Task<QrCode> Handle(UpdateQrCodeCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.QrCodeRepository.UpdateAsync(request.QrCode, cancellationToken);
            await unitOfWork.SaveAllAsync();
            var updatedQrCode = await unitOfWork.QrCodeRepository.GetByIdAsync(request.QrCode.Id, cancellationToken);
            return updatedQrCode;
        }
    }
}
