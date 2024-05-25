using Microsoft.EntityFrameworkCore;
using UpSoluctions.Data.Entities;
using UpSoluctions.Data.Map;

namespace UpSoluctions.Data
{
    public class SystemContext : DbContext
    {
        public SystemContext(DbContextOptions<SystemContext> options) : base(options)
        {
        }

        public DbSet<ClientCompany> Client_Company { get; set; }
        public DbSet<ClientPerson> Client_Person { get; set; }
        public DbSet<PublishingCompany> Publishing_Company { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Prohibited> Prohibited { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorTypeConfig());
            modelBuilder.ApplyConfiguration(new CategoryTypeConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
