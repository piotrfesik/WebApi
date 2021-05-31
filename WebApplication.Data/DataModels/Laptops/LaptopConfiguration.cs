using WebApplication.Data.DataModels.Configurations;

namespace WebApplication.Data.DataModels.Laptops
{
    public class LaptopConfiguration
    {
        public int LaptopId { get; set; }
        public Laptop Laptop { get; set; }

        public int ConfigurationItemId { get; set; }
        public ConfigurationItem ConfigurationItem{ get; set; }
    }
}