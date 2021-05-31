using System.Collections.Generic;

namespace WebApplication.Api.Models
{
    public class LaptopsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public BrandModel Brand { get; set; }
        public IList<LaptopConfigurationModel> LaptopConfiguration{ get; set; }
    }
}