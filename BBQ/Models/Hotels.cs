 using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{

    [Table("hotels")]
    public class Hotels
    {
        [Key]
        public int hid { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int price { get; set; }
    }
}
