using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data.DataModels.Configurations;
using WebApplication.Data.Repositories.Configurations;
using WebApplication.Services.DtoModels;

namespace WebApplication.Services.Services.ConfigurationService
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationItemRepository _configurationItemRepository;
        private readonly IMapper _mapper;

        public ConfigurationService(IConfigurationItemRepository configurationItemRepository, IMapper mapper)
        {
            _configurationItemRepository = configurationItemRepository;
            _mapper = mapper;
        }

        public async Task<ConfigurationItemDtoModel> CreateConfigurationItem(ConfigurationItemDtoModel model)
        {
            var isNotUnique = await _configurationItemRepository
                .FindByCondition(x =>
                    x.Name.ToLower().Trim().Replace(" ", string.Empty)
                    == model.Name.ToLower().Trim().Replace(" ", string.Empty)
                    && x.ConfigurationTypeId == model.ConfigurationType.Id)
                .AnyAsync();
            if (isNotUnique) return null;
            var dataModel = _mapper.Map<ConfigurationItem>(model);
            await _configurationItemRepository.AddAsync(dataModel);
            await _configurationItemRepository.SaveAsync();
            return _mapper.Map<ConfigurationItemDtoModel>(dataModel);
        }

        public async Task<List<ConfigurationItemDtoModel>> GetAllConfigurationItems()
        {
            var result = await _configurationItemRepository
                .GetAll()
                .ProjectTo<ConfigurationItemDtoModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return result;
        }
    }
}