namespace CheckInWeb.Data.Entities
{
    using System.Collections.ObjectModel;

    public class Location : IIdEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Collection<CheckIn> CheckIns { get; set; } 
    }
}
