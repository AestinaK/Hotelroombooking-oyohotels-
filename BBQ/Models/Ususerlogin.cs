using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{
    [Table("logintable")]
    public class Ususerlogin
    {
        [Key]
        public int id{ get; set;}
        [Required]
        [EmailAddress]

        public string email { get; set;}
        [Required]

        public string password { get; set; }
        [Required]

        
        public string role { get; set; }
        [Required]
        public string hname { get; set; }
        [Required]
        public string name { get; set; }


    }
}
