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
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> AddProduct(ProductDto productDto)
        {
            var newProduct = _productService.AddProduct(productDto);

            if (newProduct == null)
            {
                return BadRequest("Product not added");
            }

            return Ok(newProduct);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromQuery] string id, [FromBody] ProductDto productDto)
        {

            var updatedProduct = _productService.UpdateProduct(id, productDto);
            if (updatedProduct == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(string id)
        {
            var deletedProduct = _productService.DeleteProduct(id);
            if (deletedProduct == null)
            {
                return NotFound();
            }

            return Ok(deletedProduct);
        }
    }
}
