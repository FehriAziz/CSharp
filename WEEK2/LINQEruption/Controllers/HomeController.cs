using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LINQEruption.Models;

namespace LINQEruption.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {

    //-1 Find All Eruptions 
    List<Eruption> AllEruptions = eruptions;
    ViewBag.AllEruptions = AllEruptions;

    //-2 the first eruption that is in Chile and print the result.
    // List<Eruption> Chile = eruptions.Where(x => x.Location == "Chile").Take(1).ToList();
    Eruption? FirstChileEruption= eruptions.FirstOrDefault(h => h.Location == "Chile");
    ViewBag.FirstChileEruption = FirstChileEruption;



    //-3 Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
    bool Exist = eruptions.Any(h => h.Location == "Hawaiian Is");
    Eruption? Hawaiian = eruptions.FirstOrDefault(h => h.Location == "Hawaiian Is");
    ViewBag.Hawaiian = Hawaiian;
    ViewBag.Exist = Exist;


    //-4 Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
    Eruption? NewZ = eruptions.Where(g => g.Year > 1900).FirstOrDefault(g => g.Location == "New Zealand");
    ViewBag.NewZ = NewZ;

    //-5 Find all eruptions where the volcano's elevation is over 2000m and print them.
    List<Eruption> AllEruptionHigh = eruptions.Where(g => g.ElevationInMeters > 2000).ToList();
    ViewBag.AllEruptionHigh = AllEruptionHigh;


    //-6 Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
    List<Eruption> StartL = eruptions.Where(g => g.Volcano.StartsWith("L")).ToList();
    ViewBag.StartL = StartL;

    //-7 Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
    double Highest = eruptions.Max(b => b.ElevationInMeters);
    ViewBag.Highest = Highest;

    //-8 Use the highest elevation variable to find a print the name of the Volcano with that elevation.
    IEnumerable<Eruption> HighName = eruptions.Where(g => g.ElevationInMeters == Highest);
    ViewBag.HighName = HighName;

    //-9 Print all Volcano names alphabetically.
    List<Eruption> Alpha = eruptions.OrderBy(t => t.Volcano).ToList();
    ViewBag.Alpha = Alpha;

    //-10 Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
    List<Eruption> Beta = eruptions.OrderBy(t => t.Volcano).Where(g => g.Year < 1000).ToList();
    ViewBag.Beta = Beta;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


