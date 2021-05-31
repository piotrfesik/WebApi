using System.Collections.Generic;

namespace WebApplication.Api.ViewModels
{
    public class LaptopsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        // [BindNever]
        public BrandViewModel Brand { get; set; }
        // [BindNever]
        public IList<LaptopConfigurationViewModel> LaptopConfiguration{ get; set; }
    }
}