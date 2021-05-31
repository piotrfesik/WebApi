using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Services.DtoModels;

namespace WebApplication.Services.Services.ShoppingBasket
{
    public interface IShoppingBasketService
    {
        Task<BasketDtoModel> AddLaptop(int model);
        Task<List<BasketDtoModel>> GetLaptopList();
        Task RemoveLaptopList();
    }
}