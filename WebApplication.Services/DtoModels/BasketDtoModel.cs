namespace WebApplication.Services.DtoModels
{
    public class BasketDtoModel
    {
        public int Id { get; set; }
        public int LaptopId { get; set; }
        public LaptopsDtoModel Laptop { get; set; }
    }
}