using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBQ.Models
{
    
        [Table("room")]
        public class AdRoom
    {
            [Key]
            public int room_id { get; set; }
            public string facilities { get; set; }
           public string capacity { get; set; }
          public string amenities { get; set; }


        public string prize { get; set; }
        }
    }

