using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{

    [Table("roomtype")]
    public class Roomtype
    {
        [Key]
        public int rtid { get; set; }
        public string type { get; set; }
    }
}
