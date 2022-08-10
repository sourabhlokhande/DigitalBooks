using Author.Models;

namespace Reader.Services
{
    public interface IPaymentService
    {
        string BuyBook(Payment payment);
        object SearchBookByPaymentId(long paymentId);
    }
}