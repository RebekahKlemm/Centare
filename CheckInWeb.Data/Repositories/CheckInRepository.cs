using CheckInWeb.Data.Context;

namespace CheckInWeb.Data.Repositories
{
    public class CheckInRepository : ICheckInRepository
    {
        private readonly IRepository repository;

        public CheckInRepository(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
