using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{
    [Table("logintable")]
    public class Ususerlogin
    {
        [Key]
        public int id{ get; set;}
        public string ename{ get; set;}

        public string address { get; set; }
    }
}
