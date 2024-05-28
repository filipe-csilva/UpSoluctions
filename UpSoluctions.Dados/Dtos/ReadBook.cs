using UpSoluctions.Data.Entities;

namespace UpSoluctions.Data.Dtos
{
    public record ReadBook(int Id, string Title, string Description, Category Category, Author Author, PublishingCompany PublishingCompany, Prohibited Prohibited);
}
