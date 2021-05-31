using WebApplication.Data.Infrastructure;

namespace WebApplication.Api.Models
{
    public class ConfigurationTypeModel
    {
        public int Id { get; set; }
        public ConfigurationTypeEnum TypeName { get; set; }
    }
}