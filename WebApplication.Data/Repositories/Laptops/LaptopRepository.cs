using WebApplication.Data.Context;
using WebApplication.Data.DataModels.Laptops;
using WebApplication.Data.Repositories.BaseRepository;

namespace WebApplication.Data.Repositories.Laptops
{
    public class LaptopRepository : BaseRepository<Laptop>, ILaptopRepository
    {
        public LaptopRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}