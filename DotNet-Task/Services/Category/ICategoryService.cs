namespace DotNet_Task.Models.Category
{
    public interface ICategoryService
    {
        public List<Category> GetAllCategories();
        public Category GetCategoryById(string id);
        public Category AddCategory(Category category);
        public Category UpdateCategory(Category category);
        public Category DeleteCategory(string id);

    }
}
