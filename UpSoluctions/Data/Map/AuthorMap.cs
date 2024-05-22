using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpSoluctions.Models;

namespace UpSoluctions.Data.Map
{
    public class AuthorMap : IEntityTypeConfiguration<AuthorMd>
    {
        public void Configure(EntityTypeBuilder<AuthorMd> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Biography).IsRequired().HasMaxLength(500);
        }
    }
}
