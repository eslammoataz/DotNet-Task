
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet_Task.Models;
public class Image
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ImageId { get; set; }

    public string ImageUrl { get; set; }

    public string ProductId { get; set; }

    public Product Product { get; set; }

}

