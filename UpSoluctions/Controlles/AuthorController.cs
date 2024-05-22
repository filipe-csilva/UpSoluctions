using Microsoft.AspNetCore.Mvc;
using UpSoluctions.Data.Dtos;
using UpSoluctions.Models;
using UpSoluctions.Repository.Interfaces;

namespace UpSoluctions.Controlles
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            this._authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ReadAuthorDto>>> SearchAllAuthor()
        { 
            ICollection<AuthorMd> authors = await _authorRepository.GetAllAsync();
            return Ok(authors);
        }
    }
}
