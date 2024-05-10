using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Authorize(Roles = "Admin")]
public class HistoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}