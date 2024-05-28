using UpSoluctions.Data.Entities;

namespace UpSoluctions.Data.Dtos
{
    public record CreateBook( string Title, string Description, Category Category, Author Author, PublishingCompany PublishingCompany);
}
