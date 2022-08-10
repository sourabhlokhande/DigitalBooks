using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Author.Models
{
    [Table("Books")]
    public class BooksDetail
    {
        [Key]
        public long? BookId { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public decimal? Price { get; set; }
        public string? Publisher { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        public bool? Active { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
