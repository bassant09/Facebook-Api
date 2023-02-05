using Facebook_Api.DTOS.FilterDto;
using Facebook_Api.DTOS.PostDtos;
using Facebook_Api.Models;
using Facebook_Api.Services.Filer_Folder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Facebook_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private  readonly IFilterServices _filterServices;
        public FilterController(IFilterServices filter)
        {
            _filterServices = filter;

        }
        [HttpGet("get")]
        public async Task<ActionResult<ServicesRespone<FilterGetDto>>> Search([FromQuery] string Name)
        {
            //int userId = int.Parse(User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _filterServices.Search(Name));
        }

    }
}
