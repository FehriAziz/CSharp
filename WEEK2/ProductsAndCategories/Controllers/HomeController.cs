using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext _context;

    //! here we can "inject" our context service into the constructor
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        List<Product> AllProducts = _context.Products.ToList();
        ViewBag.AllProducts = AllProducts;
        return View();
    }

    [HttpPost("/products/create")]
    public IActionResult createProduct(Product newProd)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newProd);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        List<Product> AllProducts = _context.Products.ToList();
        ViewBag.AllProducts = AllProducts;
        return View("Index");
    }

    public IActionResult Privacy()
    {
        List<Categorie> AllCategories = _context.Categories.ToList();
        ViewBag.AllCategories = AllCategories;
        return View();
    }

    [HttpPost("/categories/create")]
    public IActionResult CreateCategorie(Categorie newCategorie)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newCategorie);
            _context.SaveChanges();
            return RedirectToAction("Privacy");
        }
        List<Categorie> AllCategories = _context.Categories.ToList();
        ViewBag.AllCategories = AllCategories;
        return View();
    }

    [HttpGet("/products/{ProductId}")]
    public IActionResult OneProduct(int ProductId)
    {
        Product? ThisProduct = _context.Products.Include(p => p.Categories).ThenInclude(s => s.Categorie).FirstOrDefault(p => p.ProductId == ProductId);
        System.Console.WriteLine(ThisProduct);
        List<Categorie> AllCategories = _context.Categories.ToList();
        ViewBag.AllCategories = AllCategories;
        return View("OneProduct", ThisProduct);
    }

    [HttpPost("/associations/create")]
    public IActionResult AddAssociation(Association newAssociation)
    {
        // var routeData = ControllerContext.RouteData;
        // var currentAction = routeData.Values["action"];
        // System.Console.WriteLine(currentAction);
        if (ModelState.IsValid)
        {
            _context.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
        return RedirectToPage("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
