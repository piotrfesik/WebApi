namespace WebApplication.Services.DtoModels
{
    public class LaptopConfigurationDtoView
    {
        public int LaptopId { get; set; }
        public LaptopsDtoModel Laptop { get; set; }

        public int ConfigurationItemId { get; set; }
        public ConfigurationItemDtoModel ConfigurationItem{ get; set; }
    }
}