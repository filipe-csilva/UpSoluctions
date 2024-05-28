using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpSoluctions.API.Repository.Interfaces;
using UpSoluctions.Data.Dtos;
using UpSoluctions.Data.Entities;

namespace UpSoluctions.API.Controlles
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ReadBookDto>>> SearchAllBook()
        {
            ICollection<Book> books = await _bookRepository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadBookDto>> SearchBookById(int id)
        {
            Book? book = await _bookRepository.GetByIdAsync(id);

            if (book == null) return NotFound();

            ReadBookDto BookReturn = new ReadBookDto(book.Id, book.Title, book.Description, book.Category, book.Author, book.PublishingCompany, book.Prohibited);

            return Ok(BookReturn);
        }

        [HttpPost]
        public async Task<ReadBookDto> AddBook(CreateBookDto bookDto)
        {
            Book book = new Book()
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                Category = bookDto.Category,
                Author = bookDto.Author
            };

            await _bookRepository.CreateAsync(book);

            ReadBookDto bookReturn = new ReadBookDto(book.Id, book.Title, book.Description, book.Category, book.Author, book.PublishingCompany, book.Prohibited);

            return bookReturn;
        }
    }
}
