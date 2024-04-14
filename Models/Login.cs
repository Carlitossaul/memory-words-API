using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace memory_words.Models
{
    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string EmailRecovery { get; set; }
    }
}
