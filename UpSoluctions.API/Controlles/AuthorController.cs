using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpSoluctions.API.Repository.Interfaces;
using UpSoluctions.Data.Dtos;
using UpSoluctions.Data.Entities;

namespace UpSoluctions.API.Controlles
{
    [Authorize]
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
        public async Task<ActionResult<ICollection<ReadAuthorDto>>> SearchAllAsync()
        { 
            ICollection<Author> authors = await _authorRepository.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadAuthorDto>> SearchByIdAsync(int id)
        {
            Author? author = await _authorRepository.SearchByIdAsync(id);

            if (author == null) return NotFound();
            
            ReadAuthorDto authorReturn = new ReadAuthorDto( author.Id, author.Name, author.Biography );

            return authorReturn;
        }

        [HttpPost]
        public async Task<ActionResult<ReadAuthorDto>> AddAsync(CreateAuthorDto authorDto)
        {
            try
            {
                Author author = new Author()
                {
                    Name = authorDto.Name,
                    Biography = authorDto.Biography
                };

                await _authorRepository.CreateAsync(author);

                ReadAuthorDto authorReturn = new ReadAuthorDto(author.Id, author.Name, author.Biography);

                return Ok(authorReturn);
            }
            catch
            {
                return BadRequest("Já existe Item com este nome!");
            }
        }

        [HttpPut("id")]
        public async Task<ReadAuthorDto> UpdateByIdAsync(UpdateAuthorDto auth, int id)
        {
            Author author = new Author()
            {
                Id = id,
                Name = auth.Name,
                Biography = auth.Biography
            };

            await _authorRepository.UpdateAsync(author, id);

            ReadAuthorDto authorReturn = new ReadAuthorDto(author.Id, author.Name, author.Biography);

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
