namespace WebApplication.Services.DtoModels
{
    public class ConfigurationItemDtoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ConfigurationTypeDtoModel ConfigurationType { get; set; }
        public decimal Cost { get; set; }   
    }
}