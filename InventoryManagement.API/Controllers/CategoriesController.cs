using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoriesController(CategoryService categoryService)  { 
        _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetAll() { 
        return 
        Ok(_categoryService.GetAllCategories());
        }

        [HttpPost]
        public ActionResult Add([FromBody] CreateCategoryDto dto) { 
        _categoryService.AddCategory(dto); 
        return Ok("Category Added!"); 
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] UpdateCategoryDto dto)
        {
            _categoryService.UpdateCategory(id, dto);
            return Ok("Category Updated Successfully!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok("Category Deleted Successfully!");
        }

    }
}
