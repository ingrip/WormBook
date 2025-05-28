using System.ComponentModel.DataAnnotations;

namespace WormBook.Models
{
    public class Login
    {
        [Key]
        public int userId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool cliente { get; set; }
    }
}
