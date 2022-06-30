using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{

    [Table("roomreservation")]
    public class Roomreservation
    {
        [Key]
        public int rrid { get; set; }

        public int roomid { get; set; }

        public int hid { get; set; }

        public DateOnly checkin { get; set; }

        public DateOnly checkout { get; set; }

        public string user { get; set; }
    }
}
