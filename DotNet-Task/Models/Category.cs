using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNet_Task.Models;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string CategoryId { get; set; }

    public string CategoryName { get; set; }

    public List<SubCategory> SubCategories { get; set; }
}

