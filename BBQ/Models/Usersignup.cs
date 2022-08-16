using System.ComponentModel.DataAnnotations;

namespace BBQ.Models
{
    public class Usersignup
    {
        [Required]
        public string name { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        

    }
}
