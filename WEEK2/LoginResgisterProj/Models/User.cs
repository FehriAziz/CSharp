#pragma warning disable CS8618 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // new import for ***

namespace LoginResgisterProj.Models;

public class User
{
    [Key]
    public int UserId {get;set;}
    // Username 

    [Required (ErrorMessage ="please enter a username")]
    [MinLength(3,ErrorMessage ="enter a valid username")]
    public string Username { get; set; }

    //Lucky Number
    [Required (ErrorMessage ="enter a number")]
    [Range(0,int.MaxValue , ErrorMessage ="please enter a valid number.")]
    [Display (Name = "Lucky Number")]
    public int LuckyNumber {get;set; }
    
    //Email
    [Required (ErrorMessage ="please enter your Email")]
    [EmailAddress(ErrorMessage ="please enter a valid email")]
    public string Email {get;set;}

    [Required (ErrorMessage ="please enter a Password")]
    [DataType(DataType.Password)]
    [MinLength(6,ErrorMessage ="please enter a valid password")]
    public string Password {get;set;}

    //Confirm Password
    [NotMapped]
    [Required (ErrorMessage ="Password must match")]
    [Compare("Password",ErrorMessage = "password does not match")]
    [DataType(DataType.Password)]

    [Display (Name = "Confirm Password")]

    public string ConfirmPassword {get;set;}

    //IsRequired
    [Required]
    [Display (Name = "Do you want to subscribe to our newsletter?")]

    public bool IsSubscribed {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}