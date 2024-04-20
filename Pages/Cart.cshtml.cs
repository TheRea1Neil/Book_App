using Book_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using Book_App.Infrastrucrure;

namespace Book_App.Pages
{
    public class CartModel : PageModel
    {
        private IBookRepository _repo;
        public CartModel(IBookRepository repo)
        {
            _repo = repo;
        }

        public Cart? Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = _repo.Books
                .FirstOrDefault(x => x.BookId == bookId);
           
            if (b != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(b, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }

            return RedirectToPage (new {returnUrl = returnUrl});
          

           
        }
    }
}
