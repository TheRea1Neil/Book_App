namespace Book_App.Models.ViewModels
{
    public class BooksListViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();

        public string? CurrentProjectType { get; set; }
    }
}
