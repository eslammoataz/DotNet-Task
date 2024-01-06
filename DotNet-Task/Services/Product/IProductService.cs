
using DotNet_Task.Helpers;
using DotNet_Task.Models;

public interface IProductService
{
    public List<Product> GetAllProducts();
    public Product GetProductById(string id);
    public Product AddProduct(ProductDto productdto);
    public Product UpdateProduct(string id, ProductDto productdto);
    public Product DeleteProduct(string id);


}
