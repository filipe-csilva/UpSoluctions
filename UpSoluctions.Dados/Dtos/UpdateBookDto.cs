using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSoluctions.Data.Entities;

namespace UpSoluctions.Data.Dtos
{
    public record UpdateBookDto(int Id, string Title, string Description, Category Category, Author Author, PublishingCompany PublishingCompany);
}
