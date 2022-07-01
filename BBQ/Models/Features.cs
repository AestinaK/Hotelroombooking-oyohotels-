using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{
    [Table("features")]
    public class Features
    {
        [Key]
        public int fid { get; set; }
        public string name { get; set; }
        public int rtid { get; set; }
    }
}
