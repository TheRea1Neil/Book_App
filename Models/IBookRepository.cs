namespace Book_App.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books {get;}
    }
}
