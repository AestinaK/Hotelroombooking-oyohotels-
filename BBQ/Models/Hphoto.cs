using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{

    [Table("hphoto")]
    public class Hphoto
    {
        [Key]
        public int hhid { get; set; }
        public string url { get; set; }
        public int hid { get; set; }

    }
}
