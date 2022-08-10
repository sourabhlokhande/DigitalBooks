using Author.Models;

namespace Author.Services
{
    public interface IBookService
    {
        string AddBooks(BooksDetail booksDetail);
        string UpdateBook(BooksDetail booksDetail);
    }
}
