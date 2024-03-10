using DotNet_Task.Data;
using DotNet_Task.Helpers;

namespace DotNet_Task.Models;

public class ProductService : IProductService
{
    private readonly AppDbContext context;
    private readonly ILogger<ProductService> logger;

    public ProductService(AppDbContext context, ILogger<ProductService> logger)
    {
        this.context = context;
        this.logger = logger;
    }
    public Product AddProduct(ProductDto productDto)
    {


        var newProduct = new Product()
        {

            ProductName = productDto.ProductName,
            Price = productDto.Price,
            size = productDto.size,
            color = productDto.color,
            CategoryID = productDto.CategoryID
        };

        try
        {

            context.Products.Add(newProduct);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            logger.LogError("Exception", ex);
            throw;
        }

        return newProduct;
    }


    public Product DeleteProduct(string id)
    {
        var deletedProduct = context.Products.FirstOrDefault(p => p.ProductId == id);

        if (deletedProduct == null)
        {
            return null; // Product not found
        }

        context.Products.Remove(deletedProduct);
        try
        {
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            logger.LogError("Exception", ex);
            throw;
        }

        return deletedProduct;
    }


    public List<Product> GetAllProducts()
    {
        return context.Products.ToList();
    }


    public Product GetProductById(string id)
    {
        return context.Products.FirstOrDefault(p => p.ProductId == id);
    }


    public Product UpdateProduct(string id, ProductDto productDto)
    {
        var existingProduct = context.Products.FirstOrDefault(p => p.ProductId == id);

        if (existingProduct != null)
        {
            existingProduct.ProductName = productDto.ProductName;
            existingProduct.Price = productDto.Price;
            existingProduct.size = productDto.size;
            existingProduct.color = productDto.color;

            context.SaveChanges();
        }

        return existingProduct;
    }

}
