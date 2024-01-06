using DotNet_Task.Helpers;
using DotNet_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        public ActionResult<List<SubCategory>> GetAllSubCategories()
        {
            var subCategories = _subCategoryService.GetAllSubCategories();
            return Ok(subCategories);
        }

        [HttpGet("{id}")]
        public ActionResult<SubCategory> GetSubCategoryById(string id)
        {
            var subCategory = _subCategoryService.GetSubCategoryById(id);
            if (subCategory == null)
            {
                return NotFound(); // If subcategory not found
            }
            return Ok(subCategory);
        }

        [HttpPost]
        public ActionResult<SubCategory> AddSubCategory(SubCategoryDto subCategoryDto)
        {
            var newSubCategory = _subCategoryService.AddSubCategory(subCategoryDto);
            return CreatedAtAction(nameof(GetSubCategoryById), new { id = newSubCategory.SubCategoryId }, newSubCategory);
        }

        [HttpPut]
        public IActionResult UpdateSubCategory([FromQuery] string id, [FromBody] SubCategoryDto subCategoryDto)
        {


            var updatedSubCategory = _subCategoryService.UpdateSubCategory(id, subCategoryDto);
            if (updatedSubCategory == null)
            {
                return NotFound(); // If subcategory not found
            }

            return NoContent(); // Success, return no content
        }

        [HttpDelete("{id}")]
        public ActionResult<SubCategory> DeleteSubCategory(string id)
        {
            var deletedSubCategory = _subCategoryService.DeleteSubCategory(id);
            if (deletedSubCategory == null)
            {
                return NotFound(); // If subcategory not found
            }

            return Ok(deletedSubCategory); // Return the deleted subcategory
        }

        //[HttpPost]
        //public ActionResult<List<Product>> AddProductsToSubCategory(AddProductsToSubCategory addProductsToSubCategorydto)
        //{
        //    var products = _subCategoryService.AddProductsToSubCategory(addProductsToSubCategorydto.SubCategoryId, addProductsToSubCategorydto.ProductsIDs);
        //    return Ok(products);
        //}
    }
}
