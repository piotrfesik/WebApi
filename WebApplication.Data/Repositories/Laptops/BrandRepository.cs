using WebApplication.Data.Context;
using WebApplication.Data.DataModels.Laptops;
using WebApplication.Data.Repositories.BaseRepository;

namespace WebApplication.Data.Repositories.Laptops
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}