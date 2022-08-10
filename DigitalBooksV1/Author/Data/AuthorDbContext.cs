using Author.Models;
using Microsoft.EntityFrameworkCore;

namespace Author.Data
{
    public class AuthorDbContext : DbContext
    {
        public AuthorDbContext(DbContextOptions<AuthorDbContext> option) : base(option)
        {

        }

        public DbSet<BooksDetail> BooksTbl { get; set; }
        public DbSet<User> UserTbl { get; set; }
        public DbSet<Payment> PaymentTbl { get; set; }
    }
}
