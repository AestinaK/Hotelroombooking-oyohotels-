using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{
    [Table("comment")]
    public class Comment
    {
        [Key]
        public int cid { get; set; }
        public int hid { get; set; }
        public string user { get; set; }
        public string  comment { get; set; }


    }
}
