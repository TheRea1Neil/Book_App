using Book_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Book_App.Controllers
{
    public class HomeController : Controller
    {

        private IBookRepository _repo;

        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
