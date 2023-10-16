using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OneToManyRelationShip.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http; //- Session 4 

namespace LoginRegisterProj.Controllers;

public class HomeController : Controller
{
    private MyContext _context; // 5 -
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context) //6 - 
    {
        _logger = logger;
        _context = context; // 7 - 
    }


    // ****************************************** USER ********************************************

    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32("userId") is not null)
        {
            return RedirectToAction ("Dashboard");
        }
        return View();
    }
    // ---------------------Profile----------------------
    public IActionResult Profile()
    {
                if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        int userId = (int)HttpContext.Session.GetInt32("userId");
        User? user = _context.Users.Include(u => u.MyPosts).FirstOrDefault(u => u.UserId == userId);
        return View(user);
    }
    //-------------------- Register ---------------------

    [HttpPost("users/create")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            // Email Exist ?
            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                // True
                ModelState.AddModelError("Email", "Email already in use .");
                return View("Index");
            }
            else
            {
                // False
                // 1 - Hash Password
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                // 2 - Add 
                _context.Add(newUser);
                // 3 - Save
                _context.SaveChanges();
                HttpContext.Session.SetInt32("userId", newUser.UserId);
                HttpContext.Session.SetString("username", newUser.Username);
                // HttpContext.Session.
                return RedirectToAction("Dashboard");
            }
        }
        return View("Index");
    }
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        int? userId = (int)HttpContext.Session.GetInt32("userId");
        User? user = _context.Users.FirstOrDefault(u => u.UserId == userId);
        List<Post> AllPosts = _context.Posts.Where(p => p.UserId == userId).ToList();
        ViewBag.AllPosts = AllPosts;
        return View();
    }
    //-------------------- Login ---------------------
    [HttpPost("users/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid)
        {
            // User Registered ?
            User? userFromDb = _context.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);
            if (userFromDb is null)
            {
                ModelState.AddModelError("LoginEmail", "Email dose not exist !");
                return View("Index");
            }
            else
            {
                // Initialize hasher object
                var hasher = new PasswordHasher<LoginUser>();

                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(loginUser, userFromDb.Password, loginUser.LoginPassword);

                // result can be compared to 0 for failure
                if (result == 0)
                {
                    // handle failure (this should be similar to how "existing email" is handled)
                    ModelState.AddModelError("LoginPassword", "Wrong Password !");
                    return View("Index");
                }
                else
                {
                    HttpContext.Session.SetInt32("userId", userFromDb.UserId);
                    HttpContext.Session.SetString("username", userFromDb.Username);
                    return RedirectToAction("Dashboard");
                }
            }
        }
        return View("Index");

    }

    //----------------------------- Logout ----------------------------------

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
    // ****************************************** END *************************************

                    // !                                                              

    // ******************************************* POST *****************************************
[HttpPost("posts/create")]
    public IActionResult CreatePost(Post newPost)
    {
        if (ModelState.IsValid)
        {
            // 1-Add
            _context.Add(newPost);
            // 2-Save
            _context.SaveChanges();
            return RedirectToAction("Dashboard");

        }
        List<Post> AllPosts = _context.Posts.Where(p => p.UserId == newPost.UserId).ToList();
        ViewBag.AllPosts = AllPosts;
        return View("Dashboard");
    }


    // ******************************************* LIKE *****************************************
[HttpPost("likes/create")]
    public IActionResult Like(Like newLike)
    {
        if (ModelState.IsValid)
        {
            // 1-Add
            _context.Add(newLike);
            // 2-Save
            _context.SaveChanges();
            return RedirectToAction("AllPosts");
        }
        return RedirectToAction("AllPosts");
    
    }
    //----------------- Display all posts-------------------------

    public IActionResult AllPosts()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        List<Post> AllPostsWithPoster = _context.Posts.Include(p => p.Poster).ToList();
        AllPostsView allPostsView = new AllPostsView(){
            AllPosts = AllPostsWithPoster
        };
        
        return View(AllPostsWithPoster);
    }
    // ********************************************** END ******************************************



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


