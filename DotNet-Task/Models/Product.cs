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

        public double Price { get; set; }

        public string size { get; set; }

        public List<Image> images { get; set; } = new List<Image>();

        public string color { get; set; }

        public string CategoryID { get; set; }

        public Category Category { get; set; }
    }
}
