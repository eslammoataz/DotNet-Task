namespace DotNet_Task.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }

        public string SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        public double Price { get; set; }

    }
}
