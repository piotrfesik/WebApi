namespace WebApplication.Api.Models
{
    public class LaptopConfigurationModel
    {
        public int LaptopId { get; set; }
        public LaptopsModel Laptop { get; set; }

        public int ConfigurationItemId { get; set; }
        public ConfigurationItemModel ConfigurationItem{ get; set; }
    }
}