using CheckInWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInWeb.Data.Repositories
{
    public interface ILocationRepository
    {
        Location GetLocationById(int id);
        IEnumerable<Location> GetLocations();
    }
}
