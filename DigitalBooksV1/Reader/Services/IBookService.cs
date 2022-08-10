using Author.Models;

namespace Reader.Services
{
    public interface IBookService
    {
        IEnumerable<BooksDetail> GetBooks();
        IEnumerable<BooksDetail> SearchBooks(BooksDetail booksDetail);
    }
}