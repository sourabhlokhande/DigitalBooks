using Author.Data;
using Author.Models;

namespace Reader.Services
{
    public class BookService : IBookService
    {
        private readonly AuthorDbContext _dbContext;

        public BookService(AuthorDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<BooksDetail> GetBooks()
        {
            try
            {
                return _dbContext.BooksTbl.Where(b => b.Active == true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<BooksDetail> SearchBooks(BooksDetail booksDetail)
        {
            try
            {
                var books = _dbContext.BooksTbl.Where(b => b.Active == true);
                if (!String.IsNullOrEmpty(booksDetail.Title))
                {
                    books = books.Where(b => b.Title.Contains(booksDetail.Title));
                }
                return books;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
