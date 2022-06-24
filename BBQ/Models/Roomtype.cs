using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{

    [Table("roomtype")]
    public class Roomtype
    {
        [Key]
        public int rtid { get; set; }
        public int hid { get; set; }
        public string type { get; set; }
        public string  des { get; set; }
        public int price { get; set; }
    }
}
