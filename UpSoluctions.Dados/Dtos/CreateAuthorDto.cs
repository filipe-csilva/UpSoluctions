using System.ComponentModel.DataAnnotations;

namespace UpSoluctions.Data.Dtos
{
    public record CreateAuthorDto([Required] string Name, [Required] string Biography);
}
