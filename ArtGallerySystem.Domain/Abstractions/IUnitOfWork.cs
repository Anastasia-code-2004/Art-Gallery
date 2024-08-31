using ArtGallerySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Client> ClientRepository { get; }
        IRepository<Admin> AdminRepository { get; }
        IRepository<Painting> PaintingRepository { get; }
        IRepository<Exhibition> ExhibitionRepository { get; }
        IRepository<BankCard> BankCardRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        IRepository<Ticket> TicketRepository { get; }
        IRepository<CategoryMembership> CategoryMembershipRepository { get; }
        IRepository<Membership> MembershipRepository { get; }
        IRepository<QrCode> QrCodeRepository { get; }
        public Task SaveAllAsync();
        public Task DeleteDataBaseAsync();
        public Task CreateDataBaseAsync();
    }
}
