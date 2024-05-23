using Microsoft.AspNetCore.Mvc;
using UpSoluctions.Models;
using UpSoluctions.Repository.Interfaces;

namespace UpSoluctions.Controlles
{
    [Route("api/[controller]")]
    [ApiController]
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
            ICollection<CategoryMd> category = await _categoryRepository.GetAllAsync();
            return Ok(category);
        }
    }
}
