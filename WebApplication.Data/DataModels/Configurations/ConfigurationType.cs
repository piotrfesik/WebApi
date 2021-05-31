using System.Collections.Generic;
using WebApplication.Data.Infrastructure;

namespace WebApplication.Data.DataModels.Configurations
{
    public class ConfigurationType
    {
        public int Id { get; set; }
        public ConfigurationTypeEnum TypeName { get; set; }
        public IList<ConfigurationItem> ConfigurationItems { get; set; }
    }
}