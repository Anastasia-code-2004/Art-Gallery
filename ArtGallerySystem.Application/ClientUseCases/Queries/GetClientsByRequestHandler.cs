using ArtGallerySystem.Application.AdminUseCases.Commands;
using ArtGallerySystem.Application.ClientUseCases.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Application.ClientUseCases.Queries
{
    internal class GetClientsByRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetClientsByRequest, IEnumerable<Client>>
    {
        public async Task<IEnumerable<Client>> Handle(GetClientsByRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.ClientRepository.ListAllAsync(cancellationToken);
        }
    }
}