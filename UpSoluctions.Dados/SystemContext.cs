using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UpSoluctions.Data.Entities;
using UpSoluctions.Data.Map;

namespace UpSoluctions.Data
{
    public class SystemContext : IdentityDbContext<PessoaComAcesso, PerfilDeAcesso, int>
    {
        public SystemContext(DbContextOptions<SystemContext> options) : base(options)
        {
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ClientCompany> Client_Company { get; set; }
        public DbSet<ClientPerson> Client_Person { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Prohibited> Prohibited { get; set; }
        public DbSet<PublishingCompany> Publishing_Company { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorTypeConfig());
            modelBuilder.ApplyConfiguration(new BookTypeConfig());
            modelBuilder.ApplyConfiguration(new CategoryTypeConfig());
            modelBuilder.ApplyConfiguration(new EmployeeTypeConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
