using DotNet_Task.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(string id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound("Category Not Found"); // If category not found
            }
            return Ok(category);
        }

        [HttpPost]
        public ActionResult<Category> AddCategory(CategoryDto categoryDto)
        {
            var newCategory = _categoryService.AddCategory(categoryDto);
            return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.CategoryId }, newCategory);
        }

        [HttpPut]
        public IActionResult UpdateCategory([FromQuery] string id, [FromBody] CategoryDto categoryDto)
        {

            var updatedCategory = _categoryService.UpdateCategory(id, categoryDto);
            if (updatedCategory == null)
            {
                return NotFound(); // If category not found
            }

            return NoContent(); // Success, return no content
        }


        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategory(string id)
        {
            var deletedCategory = _categoryService.DeleteCategory(id);
            if (deletedCategory == null)
            {
                return NotFound("Category Not Found"); // If category not found
            }

            return Ok(deletedCategory); // Return the deleted category
        }


    }
}
