using ArtGallerySystem.Application.ClientUseCases.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Application.ClientUseCases.Queries
{
    internal class AddClientCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddClientCommand, Client>
    {
        public async Task<Client> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client(new User(request.Name, request.Surname, request.Email, request.Phone, request.Password));
            await unitOfWork.ClientRepository.AddAsync(client, cancellationToken);
            await unitOfWork.SaveAllAsync();
            client = await unitOfWork.ClientRepository.GetByIdAsync(client.Id, cancellationToken);
            return client;
        }
    }
}
