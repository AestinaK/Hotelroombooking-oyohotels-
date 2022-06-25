using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{
    [Table("hotelprice")]
    public class Price
    {
        [Key]
        public int pid { get; set; }
        public int hid { get; set; }
        public int rtid { get; set; }
        public int price { get; set; }


    }
}
