using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CruDelicious.Models;

namespace CruDelicious.Controllers;

public class HomeController : Controller
{
    private MyContext _context; //5
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context) //6
    {
        _logger = logger;
        _context = context; //7
    }

    public IActionResult Index()
    {
        List<Dish> AllDishs = _context.Dishs.OrderByDescending(d => d.CreatedAt).ToList();
        return View(AllDishs);
    }

    [HttpGet("dishs/{dishId}")]
    public IActionResult Show(int dishId)
    {
        Dish? DishToShow = _context.Dishs.FirstOrDefault(q => q.DishId == dishId);
        return View(DishToShow);
    }

    [HttpPost("dishs/destroy")]
    public IActionResult DeleteDish(int dishId)
    {
        Dish? DishToDelete = _context.Dishs.FirstOrDefault(s => s.DishId == dishId);
        _context.Dishs.Remove(DishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("dishs/{dishId}/edit")]
    public IActionResult Edit(int dishId)
    {
        Dish? DishToEdit = _context.Dishs.FirstOrDefault(q => q.DishId == dishId);
        return View(DishToEdit);
    }

    [HttpPost("")]
    public IActionResult UpdateDish(Dish editedDish)
    {
        Dish? DishToUpdate = _context.Dishs.FirstOrDefault(q => q.DishId == editedDish.DishId);
        if (ModelState.IsValid)
        {
            DishToUpdate.DishName = editedDish.DishName;
            DishToUpdate.ChefName = editedDish.ChefName;
            DishToUpdate.CaloriesNumber = editedDish.CaloriesNumber;
            DishToUpdate.Tastiness = editedDish.Tastiness;
            DishToUpdate.Description = editedDish.Description;
            DishToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Show", new {dishId = DishToUpdate.DishId});
        }
        return View("Edit", DishToUpdate);
    }
    
    public IActionResult Privacy()
    {
        return View();
    }
    [HttpPost("dish/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Privacy");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
