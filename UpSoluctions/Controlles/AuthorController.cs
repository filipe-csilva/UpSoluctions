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

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadAuthorDto>> SearchUserById(int id)
        {
            AuthorMd? author = await _authorRepository.SearchByIdAsync(id);

            if (author == null) return NotFound();

            ReadAuthorDto userReturn = new ReadAuthorDto()
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography
            };

            return userReturn;
        }

        [HttpPost]
        public async Task<ReadAuthorDto> AddAuthor(CreateAuthorDto authorDto)
        {
            AuthorMd author = new AuthorMd()
            {
                Name = authorDto.Name,
                Biography = authorDto.Biography
            };

            await _authorRepository.CreateAsync(author);

            ReadAuthorDto autorReturn = new ReadAuthorDto()
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography
            };

            return autorReturn;
        }

        [HttpPut("id")]
        public async Task<ReadAuthorDto> UpdateUserById(UpdateAuthorDto auth, int id)
        {
            AuthorMd author = new AuthorMd()
            {
                Id = id,
                Name = auth.Name,
                Biography = auth.Biography
            };

            await _authorRepository.UpdateAsync(author, id);

            ReadAuthorDto authorReturn = new ReadAuthorDto()
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography
            };

            return authorReturn;
        }

        [HttpDelete("id")]
        public async Task<AuthorMd> DropUser(int id)
        {
            AuthorMd author = await _authorRepository.DeleteAsync(id);
            return author;
        }
    }
}
