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
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ReadBookDto>>> SearchAll()
        {
            ICollection<Book> books = await _bookRepository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadBookDto>> SearchById(int id)
        {
            Book? book = await _bookRepository.GetByIdAsync(id);

            if (book == null) return NotFound();

            ReadBookDto BookReturn = new ReadBookDto(book.Id, book.Title, book.Description, book.Category.Name, book.Author.Name, book.PublishingCompany.Name);

            return Ok(BookReturn);
        }

        [HttpPost]
        public async Task<ActionResult<ReadBookDto>> AddAsync(CreateBookDto bookDto)
        {
            try
            {
                Book book = new Book()
                {
                    Title = bookDto.Title,
                    Description = bookDto.Description,
                    CategoryId = bookDto.CategoryId,
                    AuthorId = bookDto.AuthorId
                };

                await _bookRepository.CreateAsync(book);

                ReadBookDto bookReturn = new ReadBookDto(book.Id, book.Title, book.Description, book.Category.Name, book.Author.Name, book.PublishingCompany.Name);

                return Ok(bookReturn);
            }
            catch
            {
                return BadRequest("Já existe Item com este nome!");
            }
        }

        [HttpPut("{id}")]
        public async Task<ReadBookDto> UpdateAsync(UpdateBookDto bookDto, int id)
        {
            Book book = new Book()
            {
                Id = id,
                Title = bookDto.Title,
                Description = bookDto.Description,
                Category = bookDto.Category,
                Author = bookDto.Author
            };

            await _bookRepository.UpdateAsync(book, id);

            ReadBookDto bookReturn = new ReadBookDto(book.Id, book.Title, book.Description, book.Category.Name, book.Author.Name, book.PublishingCompany.Name);

            return bookReturn;
        }

        [HttpDelete("{id}")]
        public async Task<Book> DeleteAsync(int id)
        {
            Book book = await _bookRepository.DeleteAsync(id);
            return book;
        }
    }
}
