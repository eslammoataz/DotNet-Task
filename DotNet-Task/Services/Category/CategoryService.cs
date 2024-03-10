using DotNet_Task.Data;
using DotNet_Task.Helpers;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext context;
    private readonly ILogger<CategoryService> logger;

    public CategoryService(AppDbContext context, ILogger<CategoryService> logger)
    {
        this.context = context;
        this.logger = logger;
    }
    public Category AddCategory(CategoryDto categoryDto)
    {
        var newCategory = new Category()
        {
            CategoryName = categoryDto.CategoryName
        };

        try
        {
            context.Categories.Add(newCategory);

            context.SaveChanges();


        }
        catch (Exception ex)
        {
            logger.LogError("Exception", ex);
            throw;
        }

        return newCategory;

    }


    public Category DeleteCategory(string id)
    {
        var deleted = context.Categories.FirstOrDefault(c => c.CategoryId == id);

        if (deleted == null)
        {
            return null;
        }

        context.Categories.Remove(deleted);
        try
        {
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            logger.LogError("Exception", ex);
            throw;
        }

        return deleted;
    }

    public List<Category> GetAllCategories()
    {
        return context.Categories.ToList();
    }


    public Category GetCategoryById(string id)
    {
        return context.Categories.FirstOrDefault(c => c.CategoryId == id);
    }

    public Category UpdateCategory(string id, CategoryDto categoryDto)
    {
        var existingCategory = context.Categories.FirstOrDefault(c => c.CategoryId == id);

        if (existingCategory == null)
        {
            return existingCategory;
        }

        existingCategory.CategoryName = categoryDto.CategoryName;

        context.SaveChanges();
        return existingCategory;

    }

}
