using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LINQLecture.Models;

namespace LINQLecture.Controllers;

public class HomeController : Controller
{
    public static Game[] Games = new Game[]{
        new Game {Title = "Elden Ring", Price=69.99, Genre= "Action RPG", Rating="M", Platform = "PC"},
        new Game {Title="League of Legends", Price=0.00, Genre="MOBA", Rating="T", Platform="PC"},
        new Game {Title="World of Warcraft", Price=49.99, Genre="MMORPG", Rating="T", Platform="PC"},
        new Game {Title="Elder Scrolls Online", Price=19.99, Genre="Action RPG", Rating="M", Platform="PC"},
        new Game {Title="Smite", Price=0.00, Genre="MOBA", Rating="T", Platform="All"},
        new Game {Title="Overwatch", Price=49.00, Genre="First-person Shooter", Rating="T", Platform="PC"},
        new Game {Title="Scarlet Nexus", Price=69.99, Genre="Action JRPG", Rating="T", Platform="All"},
        new Game {Title="Wonderlands", Price=69.99, Genre="RPG FPS", Rating="M", Platform="All"},
        new Game {Title="Rocket League", Price=19.99, Genre="Sports", Rating="E", Platform="All"},
        new Game {Title="StarCraft", Price=29.99, Genre="RTS", Rating="T", Platform="PC"},
        new Game {Title="God of War", Price=39.99, Genre="Action-adventure ", Rating="M", Platform="PC"},
        new Game {Title="Doki Doki Literature Club Plus!", Price=15.00, Genre="Casual", Rating="E", Platform="PC"},
        new Game {Title="Red Dead Redemption", Price=49.99, Genre="Action adventure", Rating="M", Platform="All"},
        new Game {Title = "FIFA 23", Price = 199.99, Genre ="Sports", Rating = "A", Platform = "All"},
        new Game {Title = "Call Of Duty", Price = 299.99, Genre  = "Action", Rating = "A", Platform = "PC"},
        new Game {Title = "PES", Price = 129.99, Genre  = "Sports", Rating = "A", Platform = "All"},
        new Game {Title = "Battlefield", Price = 59.99, Genre = "MOBA", Rating = "B"},
        new Game {Title="My Little Pony A Maretime Bay Adventure", Price=39.99, Genre="Adventure", Rating="E",Platform="All"},
        new Game {Title="Fallout New Vegas", Price=15.00, Genre="Open World RPG", Rating="M", Platform="PC"},
        new Game {Title="BattalField", Price=59.99, Genre="MOBA", Rating="B"},
        new Game {Title = "Cyberpunk 2077", Price = 49.99, Genre = "Action RPG", Rating = "M", Platform = "All"},
        new Game {Title = "Assassin's Creed Valhalla", Price = 59.99, Genre = "Action RPG", Rating = "M", Platform = "All"},
        new Game {Title = "Fortnite", Price = 0.00, Genre = "Battle Royale", Rating = "T", Platform = "All"},
        new Game {Title = "Minecraft", Price = 29.99, Genre = "Sandbox", Rating = "E10+", Platform = "All"},
        new Game {Title = "The Legend of Zelda: Breath of the Wild", Price = 59.99, Genre = "Action-adventure", Rating = "E10+", Platform = "Nintendo Switch"},
        new Game {Title = "Halo Infinite", Price = 59.99, Genre = "First-person Shooter", Rating = "T", Platform = "Xbox"},
        new Game {Title = "Among Us", Price = 4.99, Genre = "Party Game", Rating = "T", Platform = "All"},
        new Game {Title = "Apex Legends", Price = 0.00, Genre = "Battle Royale", Rating = "T", Platform = "All"},
        new Game {Title = "The Witcher 3: Wild Hunt", Price = 39.99, Genre = "Action RPG", Rating = "M", Platform = "All"},
        new Game {Title = "Persona 5", Price = 49.99, Genre = "JRPG", Rating = "M", Platform = "PlayStation"},
        new Game {Title = "Dark Souls III", Price = 39.99, Genre = "Action RPG", Rating = "M", Platform = "All"}
    };
    private readonly ILogger<HomeController> _logger;


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Game> AllGamesList = Games.ToList(); //First Way

        IEnumerable<Game> AllGamesIEnum = Games; //Second way
        ViewBag.AllGamesList = AllGamesList;
        ViewBag.AllGamesIEnum = AllGamesIEnum;

        //ALL PC GAMES
        List<Game> PcGames= Games.Where(g => g.Platform == "PC").ToList();
        ViewBag.PcGames = PcGames;
        

        //ALL FREE GAMES
        List<Game> FreeGames = Games.Where(x => x.Price == 0.0 ).ToList();
        ViewBag.FreeGames = FreeGames;

        // FIRST 3 GAMES
        List<Game> FirstThreeGames = Games.Take(3).ToList();
        ViewBag.FirstThreeGames = FirstThreeGames;

        //FIRST 3 GAMES IN ALL PLATFORM
        List<Game> FirstThreeAllPlatformGames = Games.Where(y => y.Platform=="All").Take(3).ToList();
        ViewBag.FirstThreeAllPlatformGames = FirstThreeAllPlatformGames;

        //ALL GAMES ORDERED BY Title
        List<Game>TitleOrderedGames = Games . OrderBy(t => t.Title).ToList();
        ViewBag.TitleOrderedGames = TitleOrderedGames ;

        //ALL GAMES ORDERED BY TITLE AND PRICE 
        List<Game> TitleAndPriceOrderedGames = Games . OrderBy(t =>t.Title).OrderBy(u=>u.Price).ToList();
        ViewBag.TitleAndPriceOrderedGames = TitleAndPriceOrderedGames;

        //ALL GAMES ORDERED BY TITLE AND PRICE 
        List<Game> PriceAndTitleOrderedGames = Games . OrderBy(u =>u.Price).OrderBy(t =>t.Title).ToList();
        ViewBag.PriceAndTitleOrderedGames =PriceAndTitleOrderedGames;

        //Favorite Game
        Game? FavoriteGame = Games.FirstOrDefault(h => h.Title =="FIFA 23");
        ViewBag.FavoriteGame = FavoriteGame;

        //ALL GAMES TITLES
        List<string> AllTitles = Games.Select(j =>j.Title).ToList();
        ViewBag.AllTitles = AllTitles;

        //MOST EXPENSIVE GAME
        Double MostExpGame = Games.Max(b=>b.Price);
        ViewBag.MostExpGame =MostExpGame;
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
