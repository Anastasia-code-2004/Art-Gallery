using ArtGallerySystem.Application.ClientUseCases.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Application.ClientUseCases.Queries
{
    internal class GetClientByEmailPhoneRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetClientByEmailPhoneRequest, Client>
    {
        public async Task<Client> Handle(GetClientByEmailPhoneRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.ClientRepository.FirstOrDefaultAsync(client => client.PersonalData.Email == request.Email 
                                                    || client.PersonalData.Phone == request.Phone, cancellationToken);
        }
    }
}


