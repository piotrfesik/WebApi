using System.Collections.Generic;

namespace WebApplication.Data.DataModels.Laptops
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public IList<Laptop> Laptops { get; set; }
    }
}