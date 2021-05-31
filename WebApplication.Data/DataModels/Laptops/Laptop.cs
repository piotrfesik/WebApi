using System.Collections.Generic;

namespace WebApplication.Data.DataModels.Laptops
{
    public class Laptop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public IList<LaptopConfiguration> LaptopConfiguration{ get; set; }
        public Basket Basket { get; set; }
    }
}