namespace WebApplication.Data.DataModels.Laptops
{
    public class Basket
    {
        public int Id { get; set; }
        public int LaptopId { get; set; }
        public Laptop Laptop { get; set; }
    }
}