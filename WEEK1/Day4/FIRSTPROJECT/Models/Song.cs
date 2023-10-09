#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;


namespace FIRSTPROJECT.Models;

public class Song 
{
    [Required(ErrorMessage ="Please add the Title .")]
    [MinLength(3, ErrorMessage ="Title must be at least 3 . ")]
    public string Title { get; set; }
    [Required]
    [Range (1900,2024 , ErrorMessage ="Please enter a valid year" ) ]
    public int ReleaseYear { get; set; }
    [Required]
    public string Singer { get; set; }
    [Required]
    public bool IsExplicit { get; set; }
}