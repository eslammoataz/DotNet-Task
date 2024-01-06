using DotNet_Task.Helpers;
using DotNet_Task.Models;


public interface ISubCategoryService
{
    public List<SubCategory> GetAllSubCategories();
    public SubCategory GetSubCategoryById(string id);
    public SubCategory AddSubCategory(SubCategoryDto subCategory);
    public SubCategory UpdateSubCategory(string id, SubCategoryDto subCategory);
    public SubCategory DeleteSubCategory(string id);

    public List<Product> AddProductsToSubCategory(string subCategoryId, List<string> productsIDs);
}
