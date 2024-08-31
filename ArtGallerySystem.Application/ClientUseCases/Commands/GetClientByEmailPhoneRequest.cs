using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Application.ClientUseCases.Commands
{
    public sealed record GetClientByEmailPhoneRequest(string Email, string Phone) : IRequest<Client>
    {
    }   
}
