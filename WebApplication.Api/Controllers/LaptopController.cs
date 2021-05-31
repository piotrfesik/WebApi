using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Api.Infrastructure.Errors;
using WebApplication.Api.ViewModels;
using WebApplication.Services.DtoModels;
using WebApplication.Services.Services.LaptopService;

namespace WebApplication.Api.Controllers
{
    [Route("api/laptop")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private readonly ILaptopService _laptopService;
        private readonly IMapper _mapper;

        public LaptopController(ILaptopService laptopService, IMapper mapper)
        {
            _laptopService = laptopService;
            _mapper = mapper;
        }
        
        /// <summary>
        ///     Returns all Laptops 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<LaptopsViewModel>>> GetAllLaptops()
        {
            var data = await _laptopService.GetAllLaptops();
            var view = _mapper.Map<List<LaptopsViewModel>>(data);
            return Ok(view);
        }

        /// <summary>
        ///     Add a new Laptop
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<LaptopsViewModel>> CreateLaptop(LaptopsViewModel model)
        {
            var dto = _mapper.Map<LaptopsDtoModel>(model);
            var data = await  _laptopService.CreateLaptop(dto);
            if (data == null) return BadRequest(Errors.AddErrorToModelState(ErrorsModelConst.ObjectIsExistKey, 
                ErrorsModelConst.ObjectIsExist + ": " + model.Name
                , ModelState));
            var view = _mapper.Map<LaptopsViewModel>(data);
            return Ok(view);
        }
    }
}