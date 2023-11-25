using Microsoft.AspNetCore.Mvc;
using PrisonSaveSystem.Models;
using System.Diagnostics;

namespace PrisonSaveSystem.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
     

        public IActionResult Index()
        {
            return View();
        }

      
    }
}