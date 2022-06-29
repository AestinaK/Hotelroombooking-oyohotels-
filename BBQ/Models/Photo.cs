using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{
    [Table("photos")]
    public class Photo
    {
        [Key]
        public int pid { get; set; }
        public string photos { get; set; }
     
        public string hid { get; set; }
    }
}
