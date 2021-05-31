using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data.DataModels.Laptops;
using WebApplication.Data.Repositories.Laptops;
using WebApplication.Services.DtoModels;

namespace WebApplication.Services.Services.LaptopService
{
    public class LaptopService : ILaptopService
    {
        private readonly ILaptopRepository _laptopRepository;
        private readonly IMapper _mapper;

        public LaptopService(ILaptopRepository laptopRepository, IMapper mapper)
        {
            _laptopRepository = laptopRepository;
            _mapper = mapper;
        }

        public async Task<LaptopsDtoModel> CreateLaptop(LaptopsDtoModel model)
        {
            var existList = await _laptopRepository
                .FindByCondition(x => x.BrandId == model.BrandId)
                .Select(s => new
                {
                    LaptopId = s.Id,
                    ItemsId = s.LaptopConfiguration.Select(l => l.ConfigurationItemId).ToList()
                }).ToListAsync();
            if (existList.Any())
            {
                var input = model.LaptopConfiguration.Select(x => x.ConfigurationItemId).ToList();
                var isNotExist = existList.Select(x => x.ItemsId.Except(input).Any()).Contains(true);
                if (!isNotExist) return null;
            }
            var dataItem = _mapper.Map<Laptop>(model);
            await _laptopRepository.AddAsync(dataItem);
            await _laptopRepository.SaveAsync();
            return _mapper.Map<LaptopsDtoModel>(dataItem);
        }

        public async Task<List<LaptopsDtoModel>> GetAllLaptops()
        {
            var laptops = await _laptopRepository
                .GetAll()
                .ProjectTo<LaptopsDtoModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return laptops;
        }
    }
}