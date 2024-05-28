using UpSoluctions.Data.Entities;

namespace UpSoluctions.Data.Dtos
{
    public record ReadBookDto(int Id, string Title, string Description, Category Category, Author Author, PublishingCompany PublishingCompany, List<Prohibited> Prohibited);
}
