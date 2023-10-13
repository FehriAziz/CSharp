using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginResgisterProj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http; //session 4 


namespace LoginResgisterProj.Controllers;

public class HomeController : Controller
{
    private MyContext _context ;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger , MyContext context)
    {
        _logger = logger;
        _context= context;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost("users/create")]
    public IActionResult Register (User newUser)
    {
        if(ModelState.IsValid)
        {
            // Email exist ?
            if (_context.Users.Any(u =>u.Email == newUser.Email))
            {
                //True
                ModelState.AddModelError("Email", "This email is already in use.");
                return View("Index");
            } else 
            {
                //False
                //1-Hash the password
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                //2- add
                _context.Add(newUser);
                //3-save
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                HttpContext.Session.SetString("Username", newUser.Username);

                return RedirectToAction("Privacy");
            }
        }
        return View("Index");
    }
    public IActionResult Privacy()
    {
        if (HttpContext.Session.GetInt32("UserId") == null)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
