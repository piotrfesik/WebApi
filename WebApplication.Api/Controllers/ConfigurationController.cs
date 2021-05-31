using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Api.Infrastructure.Errors;
using WebApplication.Api.ViewModels;
using WebApplication.Services.DtoModels;
using WebApplication.Services.Services.ConfigurationService;

namespace WebApplication.Api.Controllers
{
    [Route("api/configuration")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;
        private readonly IMapper _mapper;

        public ConfigurationController(IConfigurationService configurationService, IMapper mapper)
        {
            _configurationService = configurationService;
            _mapper = mapper;
        }

        /// <summary>
        ///     Returns all Configuration Items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<ConfigurationItemViewModel>>> GetAllConfigurationItems()
        {
            var data = await _configurationService.GetAllConfigurationItems();
            var view = _mapper.Map<List<ConfigurationItemDtoModel>, List<ConfigurationItemViewModel>>(data);
            return Ok(view);
        }

        /// <summary>
        ///     Add a new Configuration Item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ConfigurationItemViewModel>> CreateConfigurationItem(ConfigurationItemViewModel model)
        {
            var dto = _mapper.Map<ConfigurationItemDtoModel>(model);
            var data = await _configurationService.CreateConfigurationItem(dto);
            if (data == null) return BadRequest(Errors.AddErrorToModelState(ErrorsModelConst.ObjectIsExistKey, 
                ErrorsModelConst.ObjectIsExist + ": " + model.Name
                , ModelState));
            var view = _mapper.Map<ConfigurationItemViewModel>(data);
            return Ok(view);
        }
    }
}