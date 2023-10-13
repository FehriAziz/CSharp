#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CruDelicious.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required(ErrorMessage ="Please add a Name.")]
    [MinLength(3, ErrorMessage ="Name must be at least 3.")]
    public string DishName { get; set; }
    [Required(ErrorMessage ="Please add a Name.")]
    [MinLength(3, ErrorMessage ="Name must be at least 3.")]
    public string ChefName { get; set; }
    [Required]
    [Range(0, Int32.MaxValue)]
    
    public int CaloriesNumber { get; set; }
    [Required]
    [Range(1,5)]
    
    public int Tastiness { get; set; }
    [Required(ErrorMessage ="Please add Description.")]
    [MinLength(3, ErrorMessage ="Description must be at least 10.")]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}