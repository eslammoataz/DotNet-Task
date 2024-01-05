namespace DotNet_Task.Models
{
    public class SubCategory
    {
        public string SubCategoryId { get; set; }

        public string SubCategoryName { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Product> Products { get; set; }
    }
}
