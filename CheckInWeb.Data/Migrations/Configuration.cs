using System.Data.Entity.Migrations;
using CheckInWeb.Data.Context;
using CheckInWeb.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CheckInWeb.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CheckInDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CheckInDatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            var userStore = new UserStore<ApplicationUser>(context);
            var passwordHasher = new PasswordHasher();

            var user1 = new ApplicationUser { UserName = "AlexHardin", PasswordHash = passwordHasher.HashPassword("AlexHardin") };

            var user2 = new ApplicationUser { UserName = "IanFox", PasswordHash = passwordHasher.HashPassword("IanFox") };

            var user3 = new ApplicationUser { UserName = "DavidManske", PasswordHash = passwordHasher.HashPassword("DavidManske") };

            var user4 = new ApplicationUser { UserName = "MichaelWeinand", PasswordHash = passwordHasher.HashPassword("MichaelWeinand") };

            context.Users.AddOrUpdate(p => p.UserName, user1, user2, user3, user4);

            context.Locations.AddOrUpdate(l => l.Name, new Location { Name = "Miller Park" }, new Location { Name = "Wrigley Field" });
        }
    }
}
