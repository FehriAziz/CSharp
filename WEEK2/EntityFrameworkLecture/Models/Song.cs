#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace EntityFrameworkLecture.Models;
public class Song
{
    [Key]
    public int SongId { get; set; }


    [Required(ErrorMessage = "Please add a Title .")]
    [MinLength(3, ErrorMessage = "Title must be at least 3 .")]
    public string Title { get; set; }


    [Required]
    [Range(1900, 2024, ErrorMessage = "Please enter a valid year .")]
    public int ReleaseYear { get; set; }


    [Required]
    [MinLength(3, ErrorMessage = "Singer Name must be at least 3 .")]
    public string Singer { get; set; }


    [Required]
    public bool IsExplicit { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}