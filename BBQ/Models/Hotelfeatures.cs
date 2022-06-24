using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{
    [Table("hotelfeatures")]
    public class Hotelfeatures
    {
        [Key]
        public int hfid { get; set; }
        public int fid { get; set; }
        public int hid { get; set; }
    }
}
