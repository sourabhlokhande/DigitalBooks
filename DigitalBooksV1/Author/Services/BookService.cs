using Author.Data;
using Author.Models;

namespace Author.Services
{
    public class BookService : IBookService
    {
        private readonly AuthorDbContext _dbContext;

        public BookService(AuthorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string AddBooks(BooksDetail booksDetail)
        {
            try
            {
                _dbContext.BooksTbl.Add(booksDetail);
                _dbContext.SaveChanges();

                return $"{booksDetail.Title} Added Successfully";

            }
            catch(Exception ex)
            {
                return ex.Message;
            }        
        }

        
        

        public string UpdateBook(BooksDetail booksDetail)
        {
            try
            {
                var book = _dbContext.BooksTbl.Find(booksDetail.BookId);
                if (book != null)
                {
                    book.Active = booksDetail.Active;
                    book.ModifiedDate = booksDetail.ModifiedDate = DateTime.Now;
                    _dbContext.BooksTbl.Update(book);
                    _dbContext.SaveChanges();

                    return $"{booksDetail.Title} Updated Successfully";
                }
                else
                {
                    throw new Exception("Book not found");
                }
                

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
