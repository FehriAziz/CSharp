#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // New import for **
namespace OneToManyRelationShip.Models;

public class Like
{
    // Like Id
    [Key]
    public int LikeId { get; set; }
    //! Foreign Key (PostId) 
    [Required]
    public int PostId { get; set; }
    //! Foreign Key (userId) 
    [Required]
    public int UserId { get; set; }



    // Created At
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Updated At
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // ! Navigation Property 
    public Post? Post { get; set; }
    public User? Poster { get; set; }
}