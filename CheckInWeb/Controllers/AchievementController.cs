using CheckInWeb.Data.Entities;
using System.Web;
using System.Web.Mvc;

namespace CheckInWeb.Controllers
{
    using System.Linq;

    using CheckInWeb.Data.Context;
    using CheckInWeb.Data.Repositories;

    public class AchievementController : Controller
    {
        //
        // GET: /Achievement/
        public ActionResult Index()
        {
            // Get the data
            var repository = new Repository(new CheckInDatabaseContext());
            var username = HttpContext.User.Identity.Name;

            ViewBag.Achievements = repository.Query<Achievement>().Where(c => c.User.UserName == username).OrderByDescending(c => c.TimeAwarded).ToList();

            return this.View();
        }
    }
}