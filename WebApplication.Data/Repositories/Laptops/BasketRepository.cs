using WebApplication.Data.Context;
using WebApplication.Data.DataModels.Laptops;
using WebApplication.Data.Repositories.BaseRepository;

namespace WebApplication.Data.Repositories.Laptops
{
    public class BasketRepository: BaseRepository<Basket>, IBasketRepository
    {
        public BasketRepository (ApplicationDbContext context) : base(context)
        {
        }
    }
}