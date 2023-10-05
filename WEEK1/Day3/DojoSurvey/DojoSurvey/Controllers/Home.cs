using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers;

public class FirstController : Controller
{
        [HttpGet ("")]
    public ViewResult Home()
    {
        return View("Home");
    } 
}