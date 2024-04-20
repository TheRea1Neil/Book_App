using Book_App.Models;
using Book_App.Models.ViewModels;
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
        public IActionResult Index(string bookType, int page = 1)
        {
            int pageSize = 3; // Number of books per page

            // Fetch the books query from the repository
            var booksQuery = _repo.Books.AsQueryable(); // Assuming _repo.Books returns an IQueryable<Book>

            // If a specific book type is requested, filter the books
            if (!string.IsNullOrEmpty(bookType))
            {
                booksQuery = booksQuery.Where(b => b.Category == bookType);
            }

            // Calculate total number of books after filtering but before pagination
            int totalBooks = booksQuery.Count();

            // Apply ordering and pagination
            var paginatedBooks = booksQuery
                .OrderBy(b => b.Title) // Order by title or any other property
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            int totalPages = (int)Math.Ceiling(totalBooks / (double)pageSize);
            
            BooksListViewModel PaginationInfo = new BooksListViewModel
            {

            };

            // Create a view model if you have one, which is the recommended approach
            // Otherwise, pass data directly using ViewBag or ViewData
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;
            ViewBag.BookType = bookType; // To highlight the current book type filter in the view

            return View(paginatedBooks);
        }


    }
}
