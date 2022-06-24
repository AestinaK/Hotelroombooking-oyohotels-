using BBQ.Models;

namespace BBQ.ViewModel
{
    public class Hotelsearchviewmodel
    {
        public string address { get; set; }
        public string start { get; set; }
        public string end { get; set; } 
        public int noofrooms { get; set; }
        public IList<Room> Rooms { get; set; }=new List<Room>();
    }
}
