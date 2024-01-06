using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet_Task.Models
{
    public class SubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SubCategoryId { get; set; }

        public string SubCategoryName { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public List<Product> Products { get; set; }
    }
}
