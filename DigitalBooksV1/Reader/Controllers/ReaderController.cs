using Author.Models;
using Microsoft.AspNetCore.Mvc;
using Reader.Services;

namespace Reader.Controllers
{
    [ApiController]
    [Route("api/Reader")]
    public class ReaderController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IPaymentService _paymentService;

        public ReaderController(IBookService bookService, IPaymentService paymentService)
        {
            _bookService = bookService;
            _paymentService = paymentService;
        }

        [HttpGet("getbook")]
        public IActionResult GetBooks()
        {
            IEnumerable<BooksDetail> result = _bookService.GetBooks();
            return Ok(result.Any() ? result : "Book Not Found");
        }

        [HttpPost("searchbook")]
        public IActionResult SearchBooks(BooksDetail booksDetail)
        {
            IEnumerable<BooksDetail> result = _bookService.SearchBooks(booksDetail);
            return Ok(result.Any() ? result : "Book Not Found");

        }

        [HttpPost("buybook")]
        public IActionResult BuyBook(Payment payment)
        {
            var result = _paymentService.BuyBook(payment);
            return Ok(result);
        }

        [HttpPost("searchbookbypaymentid")]
        public IActionResult SearchBookByPaymentId(Payment payment)
        {
            var result = _paymentService.SearchBookByPaymentId(payment.PaymentId);
            return Ok(result!=null?result:"Book Not Found");
        }
    }
}
