using System;

namespace CheckInWeb.Models
{
    public class CheckInViewModel
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
    }
}
