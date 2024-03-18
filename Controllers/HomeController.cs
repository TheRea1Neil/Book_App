using Book_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Book_App.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        
    }
}
