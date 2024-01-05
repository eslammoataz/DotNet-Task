using DotNet_Task.Models;


public interface ISubCategoryService
{
    public List<SubCategory> GetAllSubCategories();
    public SubCategory GetSubCategoryById(string id);
    public SubCategory AddSubCategory(SubCategory subCategory);
    public SubCategory UpdateSubCategory(SubCategory subCategory);
    public SubCategory DeleteSubCategory(string id);
}
