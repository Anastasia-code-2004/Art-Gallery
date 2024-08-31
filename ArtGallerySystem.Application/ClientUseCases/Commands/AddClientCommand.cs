using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Application.ClientUseCases.Commands
{
    public sealed record AddClientCommand(string Name, string Surname, string Email, string Phone, string Password) : IRequest<Client>
    {
    }
}
