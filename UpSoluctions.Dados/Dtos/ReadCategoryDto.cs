using UpSoluctions.Data.Entities;

namespace UpSoluctions.Data.Dtos
{
    public record ReadCategoryDto(int Id, string? Name, ICollection<Book> Books);
}
