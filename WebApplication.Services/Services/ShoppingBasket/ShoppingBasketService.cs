using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data.DataModels.Laptops;
using WebApplication.Data.Repositories.Laptops;
using WebApplication.Services.DtoModels;

namespace WebApplication.Services.Services.ShoppingBasket
{
    public class ShoppingBasketService : IShoppingBasketService
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basketRepository;
        private readonly ILaptopRepository _laptopRepository;

        public ShoppingBasketService(IMapper mapper, IBasketRepository basketRepository, ILaptopRepository laptopRepository)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
            _laptopRepository = laptopRepository;
        }

        public async Task<BasketDtoModel> AddLaptop(int model)
        {
            var data = await _basketRepository.FindByCondition(x => x.LaptopId == model).FirstOrDefaultAsync();
            if (data != null) return null;
            var laptop = await _laptopRepository.FindByCondition(x => x.Id == model).FirstOrDefaultAsync();
            if (laptop == null) return null;
            var basket = new Basket
            {
                LaptopId = laptop.Id
            };
            await _basketRepository.AddAsync(basket);
            await _basketRepository.SaveAsync();
            return _mapper.Map<BasketDtoModel>(basket);
        }

        public async Task<List<BasketDtoModel>> GetLaptopList()
        {
            var data = await _basketRepository
                .GetAll()
                .ToListAsync();
            return _mapper.Map<List<BasketDtoModel>>(data);
        }

        public async Task RemoveLaptopList()
        {
            var data = await _basketRepository.GetAll().ToListAsync();
            data.ForEach(item => { _basketRepository.Delete(item); });
            await _basketRepository.SaveAsync();
        }
    }
}