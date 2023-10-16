#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;
public class Association
{
    [Key]
    public int AssociationId { get; set; }
    [Required]
    public int CategorieId { get; set; }
    [Required]
    public int ProductId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    //* Navigation properties
    public Categorie? Categorie { get; set; }
    public Product? Product { get; set; }
    public Association(int cat, int prod)
    {
        CategorieId = cat;
        ProductId = prod;
    }
    public override string ToString()
    {
        return $@"
CategorieId: {CategorieId}
ProductId: {ProductId}
            ";
    }
}