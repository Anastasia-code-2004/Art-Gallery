using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Application.AdminUseCases.Commands
{
    public sealed record GetAdminsByRequest : IRequest<IEnumerable<Admin>>
    {
    }
}
