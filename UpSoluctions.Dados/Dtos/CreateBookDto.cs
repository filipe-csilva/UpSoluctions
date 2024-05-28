using UpSoluctions.Data.Entities;

namespace UpSoluctions.Data.Dtos
{
    public record CreateBookDto( string Title, string Description, Category Category, Author Author, PublishingCompany PublishingCompany);
}
