
using DotNet_Task.Helpers;

public interface ICategoryService
{
    public List<Category> GetAllCategories();
    public Category GetCategoryById(string id);
    public Category AddCategory(CategoryDto categoryDto);
    public Category UpdateCategory(string id, CategoryDto categoryDto);
    public Category DeleteCategory(string id);

}

