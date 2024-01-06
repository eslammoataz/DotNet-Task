using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet_Task.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }

        public double Price { get; set; }
    }
}
