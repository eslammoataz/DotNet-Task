using DotNet_Task.Helpers;
using DotNet_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(string id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // If product not found
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> AddProduct(ProductDto productDto)
        {
            var newProduct = _productService.AddProduct(productDto);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.ProductId }, newProduct);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromQuery] string id, [FromBody] ProductDto productDto)
        {

            var updatedProduct = _productService.UpdateProduct(id, productDto);
            if (updatedProduct == null)
            {
                return NotFound(); // If product not found
            }

            return NoContent(); // Success, return no content
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(string id)
        {
            var deletedProduct = _productService.DeleteProduct(id);
            if (deletedProduct == null)
            {
                return NotFound(); // If product not found
            }

            return Ok(deletedProduct); // Return the deleted product
        }
    }
}
