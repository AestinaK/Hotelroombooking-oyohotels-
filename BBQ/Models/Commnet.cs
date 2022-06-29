using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{
    [Table("comment")]
    public class Commnet
    {
        [Key]
        public int cid { get; set; }
        public int hid { get; set; }
        public string comment { get; set; }
        public int rating { get; set; }
        public string user { get; set; }
    }
}
