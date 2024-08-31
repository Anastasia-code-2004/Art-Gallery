using ArtGallerySystem.Persistense.Data;

namespace ArtGallerySystem.Persistense.Repository
{
    public class EfUnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private readonly Lazy<IRepository<Client>> _ClientRepository = new(() => new EfRepository<Client>(context));
        private readonly Lazy<IRepository<Admin>> _AdminRepository = new(() => new EfRepository<Admin>(context));
        private readonly Lazy<IRepository<Painting>> _PaintingRepository = new(() => new EfRepository<Painting>(context));
        private readonly Lazy<IRepository<Exhibition>> _ExhibitionRepository = new(() => new EfRepository<Exhibition>(context));
        private readonly Lazy<IRepository<BankCard>> _BankCardRepository = new(() => new EfRepository<BankCard>(context));
        private readonly Lazy<IRepository<Category>> _CategoryRepository = new(() => new EfRepository<Category>(context));
        private readonly Lazy<IRepository<Ticket>> _TicketRepository = new(() => new EfRepository<Ticket>(context));
        private readonly Lazy<IRepository<CategoryMembership>> _CategoryMembershipRepository = new(() => new EfRepository<CategoryMembership>(context));
        private readonly Lazy<IRepository<Membership>> _MembershipRepository = new(() => new EfRepository<Membership>(context));
        private readonly Lazy<IRepository<QrCode>> _QrCodeRepository = new(() => new EfRepository<QrCode>(context));
        public IRepository<Client> ClientRepository => _ClientRepository.Value;

        public IRepository<Admin> AdminRepository => _AdminRepository.Value;

        public IRepository<Painting> PaintingRepository => _PaintingRepository.Value;

        public IRepository<Exhibition> ExhibitionRepository => _ExhibitionRepository.Value;

        public IRepository<BankCard> BankCardRepository => _BankCardRepository.Value;
        public IRepository<Category> CategoryRepository => _CategoryRepository.Value;
        
        public IRepository<Ticket> TicketRepository => _TicketRepository.Value;
        public IRepository<CategoryMembership> CategoryMembershipRepository => _CategoryMembershipRepository.Value;
        
        public IRepository<Membership> MembershipRepository => _MembershipRepository.Value;
        
        public IRepository<QrCode> QrCodeRepository => _QrCodeRepository.Value;
        public async Task CreateDataBaseAsync() => await context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync() => await context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync() => await context.SaveChangesAsync();
    }
}
