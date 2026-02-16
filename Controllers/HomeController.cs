using System.Diagnostics;
using I3EfDatabase.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using I3EfDatabase.Models;
using I3EfDatabase.Services;
using Microsoft.AspNetCore.Authorization;

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
        return View(new IndexViewModel
        {
            SupportersCount = _database.Count(),
            Supporters = _database.GetAll()
        });
    }

    public IActionResult Supporters()
    {
        var supporters = _database.GetAll();
        return View(supporters);
    }
    [Authorize]
    [HttpDelete]
    public IActionResult DeleteSupporter(Guid id)
    {
        _database.Delete(id);
        return Ok();
    }

    
    [HttpPost]
    public IActionResult Index(IndexViewModel model)
    {
        if (ModelState.IsValid &&
            !string.IsNullOrWhiteSpace(model.NewSupporter.Name) &&
            !string.IsNullOrWhiteSpace(model.NewSupporter.Email))
        {
            _database.Create(model.NewSupporter);
            return RedirectToAction("Index");
        }

        model.Supporters = _database.GetAll();
        model.SupportersCount = _database.Count();
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