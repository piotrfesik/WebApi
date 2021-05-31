namespace WebApplication.Api.Models
{
    public class ConfigurationItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ConfigurationTypeModel ConfigurationType { get; set; }
        public decimal Cost { get; set; }  
    }
}