using System;

namespace CheckInWeb.Data.Entities
{
    public class CheckIn : IIdEntity
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Location Location { get; set; }
        public DateTime Time { get; set; }
    }
}
