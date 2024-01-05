
using DotNet_Task.Models;

public interface IProductService
{
    public List<Product> GetAllProducts();
    public Product GetProductById(string id);
    public Product AddProduct(Product product);
    public Product UpdateProduct(Product product);
    public Product DeleteProduct(string id);


}
