using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers;

public class FirstController : Controller
{
    //Routes
    [HttpGet]    
    [Route("first")]
    public string FirstRoute()
    {
        return "Hello From First Controller";
    }

    [HttpGet("html")]
    public string Html()
    {
        return "<h1> This is an H1 Tag From First Controller  </h1>"; //cannot render that
    }


    [HttpGet("params/{username}/{age}")]
    public string Params(string username ,int age)
    {
        return $"Username: {username}\n Age:{age}";
    }

    [HttpGet ("")]
    public ViewResult Index()
    {
        return View("Index");
    } 


    [HttpGet("dashboard")]
    public ViewResult Dashboard()
    {
        return View();
    }

    [HttpGet("second/{name}/{favNumber}")]
    public ViewResult Second(string name, int favNumber)
    {
        System.Console.WriteLine($"User name : {name}\nFavorite number : {favNumber}");
        ViewBag.Name = name;
        ViewBag.FavNumber=favNumber;
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(string name , int favNumber)
    {
        if (name =="")
        {
            return RedirectToAction("dashboard");
        }
        System.Console.WriteLine($"From data\nName: {name}\nFavorite Number : {favNumber}");
        ViewBag.Name = name;
        ViewBag.FavNumber = favNumber;
        return View ("Second");
    }

    //garde route - catch all route
    [HttpGet("{anything}")]
    public ViewResult Error ()
    {
        return View();
    }
}