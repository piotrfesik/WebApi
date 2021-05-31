namespace WebApplication.Api.ViewModels
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        public int LaptopId { get; set; }
        public LaptopsViewModel Laptop { get; set; }
    }
}