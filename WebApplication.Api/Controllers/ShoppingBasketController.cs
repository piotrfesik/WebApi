using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Api.Infrastructure.Errors;
using WebApplication.Api.Models;
using WebApplication.Services.Services.ShoppingBasket;

namespace WebApplication.Api.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class ShoppingBasketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShoppingBasketService _shoppingBasketService;

        public ShoppingBasketController(IMapper mapper, IShoppingBasketService shoppingBasketService)
        {
            _mapper = mapper;
            _shoppingBasketService = shoppingBasketService;
        }

        /// <summary>
        ///     Add Laptop in Basket 
        /// </summary>
        /// <returns></returns>
        [HttpPost("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BasketModel>> AddLaptop(LaptopsModel model)
        {
            var data = await _shoppingBasketService.AddLaptop(model.Id);
            if (data == null)
                return BadRequest(Errors.AddErrorToModelState(ErrorsModelConst.ObjectIsExistKey,
                    ErrorsModelConst.ObjectIsExist + ": " + model.Name
                    , ModelState));
            return Ok(_mapper.Map<LaptopsModel>(data));
        }

        /// <summary>
        ///     Get Baskets list 
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<LaptopsModel>>> GetLaptopList()
        {
            var data = await _shoppingBasketService.GetLaptopList();
            var view = _mapper.Map<List<LaptopsModel>>(data);
            return Ok(view);
        }

        /// <summary>
        ///     Clear Basket
        /// </summary>
        /// <returns></returns>
        [HttpGet("clear")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<LaptopsModel>>> RemoveLaptopList()
        {
            await _shoppingBasketService.RemoveLaptopList();
            return Ok();
        }
    }
}