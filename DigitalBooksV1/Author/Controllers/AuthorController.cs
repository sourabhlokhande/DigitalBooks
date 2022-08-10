using Author.Models;
using Author.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Author.Controllers
{
    [ApiController]
    [Route("api/Author")]
    //[Authorize]
    public class AuthorController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        

        public AuthorController(IBookService bookService,IUserService userService)
        {
            _bookService = bookService;
            _userService = userService;
        }

        [Authorize]
        [HttpPost("addbook")]
        public IActionResult AddBook(BooksDetail booksDetail)
        {
            var result = _bookService.AddBooks(booksDetail);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("updatebook")]
        public IActionResult UpdateBook(BooksDetail booksDetail)
        {
            var result = _bookService.UpdateBook(booksDetail);
            return Ok(result);
        }


        [HttpPost("adduser")]
        public IActionResult AddUser(User user)
        {
            var result = _userService.AddUser(user);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {
            return Ok(new[]
            {
                "John.Doe",
                "Jane.Doe",
                "Jewel.Doe",
                "Jayden.Doe",
            });
        
        }
    }
}
