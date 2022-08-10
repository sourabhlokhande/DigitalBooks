using Author.Data;
using Author.Models;

namespace Reader.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly AuthorDbContext _dbContext;

        public PaymentService(AuthorDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string BuyBook(Payment payment)
        {
            try
            {
                _dbContext.PaymentTbl.Add(payment);
                _dbContext.SaveChanges();

                return $"Transaction Id : {payment.PaymentId} Payment Successfull";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public object SearchBookByPaymentId(long paymentId)
        {
            try
            {
                var payments = _dbContext.PaymentTbl.Find(paymentId);
                var book = _dbContext.BooksTbl.Find(payments.BookId);
                return book;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
