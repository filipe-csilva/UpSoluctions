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

            if (category == null) return NotFound();

            ReadCategoryDto categoryReturn = new ReadCategoryDto(category.Id, category.Name, category.Books);

            return Ok(categoryReturn);
        }
        [HttpPost]
        public async Task<ActionResult<ReadCategoryDto>> AddAsync(CreateCategoryDto categoryDto)
        {
            try
            {
                Category category = new Category()
                {
                    Name = categoryDto.Name
                };
                await _categoryRepository.CreateAsync(category);

                ReadCategoryDto categoryReturn = new ReadCategoryDto(category.Id, category.Name, category.Books);

                return Ok(categoryReturn);
            }
            catch
            {
                return BadRequest("Já existe Item com este nome!");
            }
            
        }

        [HttpPut("id")]
        public async Task<ReadCategoryDto> UpdateByIdAsync(UpdateCategoryDto categ, int id)
        {
            Category category = new Category()
            {
                Id = id,
                Name = categ.Name
            };

            await _categoryRepository.UpdateAsync(category, id);

            ReadCategoryDto categoryReturn = new ReadCategoryDto(category.Id, category.Name, category.Books);

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
