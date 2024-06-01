using UpSoluctions.Data.Entities;

namespace UpSoluctions.Data.Dtos
{
    public record CreateBookDto( string Title, string Description, int CategoryId, int AuthorId, int PublishingCompanyId);
}
