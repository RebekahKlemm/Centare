using CheckInWeb.Data.Repositories;
using CheckInWeb.Models;
using System.Linq;
using System.Web.Mvc;

namespace CheckInWeb.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationRepository locationRepository;

        public LocationController()
            : this(new LocationRepository())
        {
        }

        public LocationController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        //
        // GET: /Location/
        public ActionResult Index()
        {
            // Get the data
            var model = new LocationIndexViewModel();

            model.Locations = this.locationRepository.GetLocations().ToList();

            return this.View(model);
        }
	}
}