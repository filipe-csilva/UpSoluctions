using Microsoft.AspNetCore.Mvc;
using UpSoluctions.API.Repository.Interfaces;
using UpSoluctions.Data.Dtos;
using UpSoluctions.Data.Entities;

namespace UpSoluctions.API.Controlles
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ReadCategoryDto>>> GetResultAsync()
        {
            ICollection<Category> category = await _categoryRepository.GetAllAsync();
            return Ok(category);
        }
 
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadCategoryDto>> SearchById(int id)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id);

            if (book == null) return NotFound();

            ReadCategoryDto xategoryReturn = new ReadCategoryDto(category.Id, category.Name);

            return Ok(BookReturn);
        }
        [HttpPost]
        public async Task<ReadCategoryDto> AddAsync(CreateCategoryDto categoryDto)
        {
            Category category = new Category()
            {
                Name = categoryDto.Name
            };
            await _categoryRepository.CreateAsync(category);

            ReadCategoryDto categoryReturn = new ReadCategoryDto(category.Id, category.Name);

            return categoryReturn;
        }

        [HttpPut("id")]
        public async Task<ReadCategryDto> UpdateByIdAsync(UpdateCategoryDto categ, int id)
        {
            Category category = new Category()
            {
                Id = id,
                Name = categ.Name
            };

            await _categoryRepository.UpdateAsync(category, id);

            ReadCategoryDto categoryReturn = new ReadCategoryDto(category.Id, category.Name);

            return categoryReturn;
        }

        [HttpDelete("id")]
        public async Task<Category> DropUser(int id)
        {
            Category category = await _categoryRepository.DeleteAsync(id);
            return category;
        }
    }
}
