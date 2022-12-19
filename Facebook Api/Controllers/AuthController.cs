using Facebook_Api.DTOS.AuthDtos;
using Facebook_Api.Models;
using Facebook_Api.Services.Authantication_Folder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Facebook_Api.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthanticationRepository _authanticationRepository;
        public AuthController( IAuthanticationRepository authanticationRepository)
        {
            _authanticationRepository = authanticationRepository;

        }
        [HttpPost("register")]
        public async Task<ActionResult<ServicesRespone<int>>> Register(UsertRegisterDto request )
        {
            var respone =  await _authanticationRepository.Register(new User { UserName = request.UserName, Email = request.Email, PhoneNumber = request.PhonenNumber }, request.Password);
            if (!respone.Success)
            {
                return BadRequest(respone.Message);
            }
            return Ok(respone); 
        }
        [HttpPost("Login")]
        public async Task<ActionResult<ServicesRespone<int>>>Login(UserLoginDto request)
        {
            var respone = await _authanticationRepository.Login(request.Email, request.Password);
            if (!respone.Success)
            {
                return BadRequest(respone.Message);
            }
            return Ok(respone);
        }
    }
}
