namespace CheckInWeb.Data.Entities
{
    using System;

    public class Achievement : IIdEntity
    {
        public int Id { get; set; }
        public AchievementType Type { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime TimeAwarded { get; set; }
    }
}
