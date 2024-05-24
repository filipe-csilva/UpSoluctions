﻿using Microsoft.AspNetCore.Mvc;
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
    }
}