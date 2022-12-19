using Facebook_Api.DTOS.FriendDtos;
using Facebook_Api.Models;
using Facebook_Api.Services.Friends_Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Facebook_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendServices _friendServices;

        public FriendController(IFriendServices friendServices)
        {
            _friendServices = friendServices;
        }
        [HttpPost("AddFriend {UserId}")]
        public async Task<ActionResult<ServicesRespone<GetFriendDto>>> AddFriend(int UserId)
        { 
            return Ok( await _friendServices.AddFriend(UserId));

        }
        [HttpDelete("DeleteFriend {UserId}")]
        public async Task<ActionResult<ServicesRespone<GetFriendDto>>> RemoveFriend(int UserId)
        {
            return Ok(await _friendServices.RemoveFriend(UserId));

        }
    }
}
