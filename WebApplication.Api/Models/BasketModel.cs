namespace WebApplication.Api.Models
{
    public class BasketModel
    {
        public int Id { get; set; }
        public int LaptopId { get; set; }
        public LaptopsModel Laptop { get; set; }
    }
}