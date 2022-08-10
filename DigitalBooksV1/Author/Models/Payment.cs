using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Author.Models
{
    [Table("Payment")]
    public class Payment
    {
        [Key]
        public long PaymentId { get; set; }
        public string? Email { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public long? BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual BooksDetail? BooksDetail { get; set; }
    }
}
