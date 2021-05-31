using WebApplication.Data.Infrastructure;

namespace WebApplication.Api.ViewModels
{
    public class ConfigurationTypeViewModel
    {
        public int Id { get; set; }
        public ConfigurationTypeEnum TypeName { get; set; }
    }
}