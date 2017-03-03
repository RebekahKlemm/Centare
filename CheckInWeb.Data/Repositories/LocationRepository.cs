namespace CheckInWeb.Data.Repositories
{
    using CheckInWeb.Data.Context;
    using CheckInWeb.Data.Entities;
    using System.Collections.Generic;
    using System.Linq;

    public class LocationRepository : ILocationRepository
    {
        private readonly IRepository repository;

        public LocationRepository()
            : this(new Repository(new CheckInDatabaseContext()))
        {
        }

        public LocationRepository(IRepository repository)
        {
            this.repository = repository;
        }

        public Location GetLocationById(int id)
        {
            return repository.GetById<Location>(id);
        }

        public IEnumerable<Location> GetLocations()
        {
            return repository.Query<Location>().ToArray();
        }
    }
}
