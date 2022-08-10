using Author.Data;
using Author.Models;

namespace Author.Services
{
    public class UserService : IUserService
    {
        private readonly AuthorDbContext _dbContext;

        public UserService(AuthorDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string AddUser(User user)
        {
            try
            {
                _dbContext.UserTbl.Add(user);
                _dbContext.SaveChanges();

                return $"{user.UserName} Added Successfully";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
