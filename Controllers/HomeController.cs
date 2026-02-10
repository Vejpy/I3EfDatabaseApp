using System.Diagnostics;
using I3EfDatabase.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using I3EfDatabase.Models;
using I3EfDatabase.Services;

namespace I3EfDatabase.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseService _database;

    public HomeController(ILogger<HomeController> logger, DatabaseService databaseService)
    {
        _logger = logger;
        _database = databaseService;
    }
    
    public IActionResult Index()
    {
        return View(new IndexViewModel(_database.Count()));
        
    }


    [HttpPost]
    public IActionResult Index(IndexViewModel model)
    {
        if (ModelState.IsValid && !string.IsNullOrWhiteSpace(model.NewSupporter.Name) && !string.IsNullOrWhiteSpace(model.NewSupporter.Email))
        {
            _database.Create(model.NewSupporter);
            return RedirectToAction("Index");
        }
        
        return View(model);
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