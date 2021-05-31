using WebApplication.Data.Context;
using WebApplication.Data.DataModels.Configurations;
using WebApplication.Data.Repositories.BaseRepository;

namespace WebApplication.Data.Repositories.Configurations
{
    public class ConfigurationTypeRepository : BaseRepository<ConfigurationType>, IConfigurationTypeRepository
    {
        public ConfigurationTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}