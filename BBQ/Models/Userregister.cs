using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{


    [Table("user")]
    public class Userregister
    {
        [Key]
        public int uid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
