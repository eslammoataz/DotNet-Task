namespace DotNet_Task.Models;

public class Category
{
    public string CategoryId { get; set; }

    public string CategoryName { get; set; }

    public List<SubCategory> SubCategories { get; set; }
}

