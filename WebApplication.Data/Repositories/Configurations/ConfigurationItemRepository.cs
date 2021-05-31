using WebApplication.Data.Context;
using WebApplication.Data.DataModels.Configurations;
using WebApplication.Data.Repositories.BaseRepository;

namespace WebApplication.Data.Repositories.Configurations
{
    public class ConfigurationItemRepository : BaseRepository<ConfigurationItem>, IConfigurationItemRepository
    {
        public ConfigurationItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}