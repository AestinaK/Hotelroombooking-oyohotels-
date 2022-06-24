using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{
    [Table("room")]
    public class Room
    {
        [Key]
        public int rid { get; set; }
        public int hid { get; set; }
        public int roomno { get; set; }
        public int rtid { get; set; }
    }
}
