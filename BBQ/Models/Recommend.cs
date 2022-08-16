using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{
    [Table("recommend")]
    public class Recommend
    {
        [Key]
        public int recid { get; set; }
        public string user { get; set; }

        public int star { get; set; }

    }
}
