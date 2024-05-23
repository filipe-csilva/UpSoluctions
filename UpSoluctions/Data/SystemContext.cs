using Microsoft.EntityFrameworkCore;
using UpSoluctions.Data.Map;
using UpSoluctions.Models;

namespace UpSoluctions.Data
{
    public class SystemContext : DbContext
    {
        public SystemContext(DbContextOptions<SystemContext> options) : base(options)
        {
        }

        public DbSet<ClientCompanyMd> Client_Company { get; set; }
        public DbSet<ClientPersonMd> Client_Person { get; set; }
        public DbSet<PublishingCompanyMd> Publishing_Company { get; set; }
        public DbSet<BookMd> Book { get; set; }
        public DbSet<CategoryMd> Category { get; set; }
        public DbSet<AuthorMd> Author { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
