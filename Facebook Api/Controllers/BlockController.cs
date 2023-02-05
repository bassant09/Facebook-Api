using Facebook_Api.DTOS.BlockDto;
using Facebook_Api.DTOS.FriendDtos;
using Facebook_Api.Models;
using Facebook_Api.Services.Block_Folder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Facebook_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        private readonly IBlockServices _blockServices;
        public BlockController(IBlockServices blockServices)
        {
            _blockServices = blockServices;
            

        }
        [HttpPost("AddBlock {UserId}")]
        public async Task<ActionResult<ServicesRespone< List< GetBlockDto>>>> AddBlock(int UserId)
        {
            return Ok(await _blockServices.AddBlock(UserId));

        }
        [HttpGet("ShowBlockList")]
        public async Task<ActionResult<ServicesRespone<List<GetBlockDto>>>> ShowBlockList()
        {
            return Ok(await _blockServices.ShowBlockList());

        }
        [HttpDelete]
        public async Task<ActionResult<ServicesRespone<List<GetBlockDto>>>> UnBlock(int UserId)
        {
            return Ok(await _blockServices.UnBlock(UserId));

        }
    }
}
