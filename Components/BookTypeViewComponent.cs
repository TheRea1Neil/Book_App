using Book_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_App.Components
{
    public class BookTypeViewComponent : ViewComponent
    {
        private IBookRepository _repo;
        public BookTypeViewComponent(IBookRepository temp) 
        {
            _repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            var bookTypes = _repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(bookTypes);
        }
    }
}
