using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpSoluctions.Models;

namespace UpSoluctions.Data.Map
{
    public class CategoryMap : IEntityTypeConfiguration<CategoryMd>
    {
        public void Configure(EntityTypeBuilder<CategoryMd> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
