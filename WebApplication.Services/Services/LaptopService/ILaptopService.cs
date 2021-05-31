using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Services.DtoModels;

namespace WebApplication.Services.Services.LaptopService
{
    public interface ILaptopService
    {
        Task<LaptopsDtoModel> CreateLaptop(LaptopsDtoModel model);
        Task<List<LaptopsDtoModel>> GetAllLaptops();
    }
}