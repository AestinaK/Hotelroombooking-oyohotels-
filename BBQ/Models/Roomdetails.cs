using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{
    [Table("roomdetails")]
    public class Roomdetails
    {
        [Key]
        public int roomid { get; set; }
        public int price { get; set; }
       
        public string facilities { get; set; }

         public string hotel { get; set; }
        public string address { get; set; }

    }
}
