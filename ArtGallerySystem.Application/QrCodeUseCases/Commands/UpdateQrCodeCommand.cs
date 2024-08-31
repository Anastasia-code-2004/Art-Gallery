using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Application.QrCodeUseCases.Commands
{
    public sealed record UpdateQrCodeCommand(QrCode QrCode) : IRequest<QrCode>
    {
    }
}
