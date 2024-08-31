using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Persistense.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Painting> Paintings { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<CategoryMembership> CategoryMemberships { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<QrCode> QrCodes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
            .OwnsOne<User>(t => t.PersonalData);
            modelBuilder.Entity<Admin>()
                .OwnsOne<User>(t => t.PersonalData);
        }
    }
}
