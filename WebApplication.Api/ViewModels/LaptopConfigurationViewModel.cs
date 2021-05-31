namespace WebApplication.Api.ViewModels
{
    public class LaptopConfigurationViewModel
    {
        public int LaptopId { get; set; }
        public LaptopsViewModel Laptop { get; set; }

        public int ConfigurationItemId { get; set; }
        public ConfigurationItemViewModel ConfigurationItem{ get; set; }
    }
}