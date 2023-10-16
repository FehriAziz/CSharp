#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // New import for ****
namespace OneToManyRelationShip.Models;

public class User
{
    // User Id
    [Key]
    public int UserId { get; set; }

    // Username
    [Required(ErrorMessage = "Please enter your username.")]
    [MinLength(3, ErrorMessage = "Please enter a valid username .")]
    public string Username { get; set; }

    // Lucky Number 
    [Required(ErrorMessage = "Please enter your lucky number.")]
    [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number.")]
    [Display(Name = "Lucky Number ")]
    public int LuckyNumber { get; set; }

    // Email
    [Required(ErrorMessage = "Please enter your email.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email.")]
    public string Email { get; set; }

    // Password
    [Required(ErrorMessage = "Please enter your password.")]
    [DataType(DataType.Password)] // useful
    [MinLength(6, ErrorMessage = "Please enter a valid Password .")]
    public string Password { get; set; }

    // Confirm Password
    [NotMapped]
    [Required(ErrorMessage = "Please enter your password.")]
    [Compare("Password", ErrorMessage = "Passwords must match.")]
    [DataType(DataType.Password)] // useful
    [Display(Name = "Confirm Password ")]
    public string ConfirmPassword { get; set; }

    // Is Subscribed ?
    [Required]
    [Display(Name = "Do you want to subscribe to our newsletter ?")]

    public bool IsSubscribed { get; set; }

    // Created At
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Updated At
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // ! Navigation Property 

    //------OneToOne------
    // - public Post? MyPost { get; set; } ; 
    public List<Post> MyPosts { get; set; } = new List<Post>();
    public List<Like> MyLikes {get ; set; } = new List<Like>();

}