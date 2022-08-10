using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Author.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public long UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
