using Microsoft.AspNetCore.Mvc;
using UpSoluctions.API.Repository.Interfaces;
using UpSoluctions.Data.Dtos;
using UpSoluctions.Data.Entities;

namespace UpSoluctions.API.Controlles
{
    [ApiController]
    [Route("api/[controller]")]
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
            ICollection<Author> authors = await _authorRepository.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadAuthorDto>> SearchUserById(int id)
        {
            Author? author = await _authorRepository.SearchByIdAsync(id);

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
            try
            {
                Author author = new Author()
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
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding the author.");
            }
        }

        [HttpPut("id")]
        public async Task<ReadAuthorDto> UpdateAuthorById(UpdateAuthorDto auth, int id)
        {
            Author author = new Author()
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
        public async Task<Author> DropUser(int id)
        {
            Author author = await _authorRepository.DeleteAsync(id);
            return author;
        }
    }
}
