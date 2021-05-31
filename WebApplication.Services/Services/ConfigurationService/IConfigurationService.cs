using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Services.DtoModels;

namespace WebApplication.Services.Services.ConfigurationService
{
    public interface IConfigurationService
    {
        Task<ConfigurationItemDtoModel> CreateConfigurationItem(ConfigurationItemDtoModel model);
        Task<List<ConfigurationItemDtoModel>> GetAllConfigurationItems();
    }
}