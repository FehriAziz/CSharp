#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // New import for ****
namespace OneToManyRelationShip.Models;

public class Post
{
    // Post Id
    [Key]
    public int PostId { get; set; }
    //! Foreign Key (userId) 
    [Required]
    public int UserId { get; set; }


    // Title
    [Required(ErrorMessage = "Please enter your Title.")]
    [MinLength(3, ErrorMessage = "Please enter a valid Title .")]
    public string Title { get; set; }
    // Subject
    [Required(ErrorMessage = "Please enter your Subject.")]
    [MinLength(3, ErrorMessage = "Please enter a valid Subject .")]
    public string Subject { get; set; }
    // Content
    [Required(ErrorMessage = "Please enter your Content.")]
    [MinLength(3, ErrorMessage = "Please enter a valid Content .")]
    public string Content { get; set; }


    // Created At
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Updated At
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // ! Navigation Property 
    public User? Poster { get; set; }
    public List<Like> PostLikes {get; set; } = new List<Like>();
}