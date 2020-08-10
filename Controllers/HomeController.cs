using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers {
  public class HomeController: Controller {

    private readonly ILogger<HomeController> _logger;
    private readonly IDatabaseService<MyDbContext> _dbService;

    public HomeController(ILogger<HomeController> logger, IDatabaseService<MyDbContext> dbService) {
      _logger = logger;
      _dbService = dbService;
    }

    public IActionResult Index() {
      var records = _dbService.Query(db => db.MyEntities.ToList());
      return View();
    }

    public IActionResult Privacy() {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
