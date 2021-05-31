using System.Collections.Generic;
using WebApplication.Data.DataModels.Laptops;

namespace WebApplication.Data.DataModels.Configurations
{
    public class ConfigurationItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int ConfigurationTypeId { get; set; }
        public ConfigurationType ConfigurationItemType { get; set; }
        public IList<LaptopConfiguration> LaptopConfigurations { get; set; }
    }
}