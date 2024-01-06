using DotNet_Task.Data;
using DotNet_Task.Helpers;

namespace DotNet_Task.Models
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly AppDbContext context;
        private readonly ILogger<SubCategory> logger;

        public SubCategoryService(AppDbContext context, ILogger<SubCategory> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public List<Product> AddProductsToSubCategory(string subCategoryId, List<string> productsIDs)
        {
            var subCategory = context.SubCategories.FirstOrDefault(s => s.SubCategoryId == subCategoryId);
            var products = new List<Product>();
            if (subCategory != null)
            {
                foreach (var productId in productsIDs)
                {
                    var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
                    if (product != null)
                    {
                        products.Add(product);
                        product.SubCategoryId = subCategoryId;
                        subCategory.Products.Add(product);
                    }
                }
            }
            return products;
        }

        public SubCategory AddSubCategory(SubCategoryDto subCategoryDto)
        {
            var newSubCategory = new SubCategory()
            {

                CategoryId = subCategoryDto.CategoryId,
                SubCategoryName = subCategoryDto.SubCategoryName,
                Products = new List<Product>() { }
            };

            try
            {
                context.SubCategories.Add(newSubCategory);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Exception", ex);

                throw;
            }

            return newSubCategory;
        }


        public SubCategory DeleteSubCategory(string id)
        {
            var deletedSubCategory = context.SubCategories.FirstOrDefault(s => s.SubCategoryId == id);

            if (deletedSubCategory == null)
            {
                return null;
            }

            context.SubCategories.Remove(deletedSubCategory);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Exception", ex);
                throw;
            }

            return deletedSubCategory;
        }


        public List<SubCategory> GetAllSubCategories()
        {
            return context.SubCategories.ToList();
        }


        public SubCategory GetSubCategoryById(string id)
        {
            return context.SubCategories.FirstOrDefault(s => s.SubCategoryId == id);
        }


        public SubCategory UpdateSubCategory(string id, SubCategoryDto subCategoryDto)
        {
            var existingSubCategory = context.SubCategories.FirstOrDefault(s => s.SubCategoryId == id);

            if (existingSubCategory == null)
            {
                return null; // not a good behaviour 
            }

            existingSubCategory.CategoryId = subCategoryDto.CategoryId;
            existingSubCategory.SubCategoryName = subCategoryDto.SubCategoryName;
            context.SaveChanges();

            return existingSubCategory;
        }

    }
}
