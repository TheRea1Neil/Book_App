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
        public IActionResult Index(int page = 1)
        {
            int pageSize = 10; // Number of books per page
            var books = _repo.Books;

            var paginatedBooks = books
             .OrderBy(b => b.Title) // Order by title or any other property
             .Skip((page - 1) * pageSize)
             .Take(pageSize)
             .ToList();

            int totalBooks = books.Count();
            int totalPages = (int)Math.Ceiling(totalBooks / (double)pageSize);

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;

            return View(paginatedBooks);
        }
        
    }
}
