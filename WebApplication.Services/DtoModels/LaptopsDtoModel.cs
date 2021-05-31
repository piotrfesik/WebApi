using System.Collections.Generic;

namespace WebApplication.Services.DtoModels
{
    public class LaptopsDtoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public BrandDtoModel Brand { get; set; }
        public IList<LaptopConfigurationDtoView> LaptopConfiguration{ get; set; }
    }
}