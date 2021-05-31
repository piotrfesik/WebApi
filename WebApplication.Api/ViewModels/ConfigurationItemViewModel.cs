namespace WebApplication.Api.ViewModels
{
    public class ConfigurationItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ConfigurationTypeViewModel ConfigurationType { get; set; }
        public decimal Cost { get; set; }  
    }
}