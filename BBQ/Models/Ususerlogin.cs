using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{
    [Table("logintable")]
    public class Ususerlogin
    {
        [Key]
        public int id{ get; set;}
        public string email{ get; set;}

        public string password { get; set; }
        public string role { get; set; }
    }
}
