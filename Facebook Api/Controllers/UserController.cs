using AutoMapper;
using Facebook_Api.DTOS.AuthDtos;
using Facebook_Api.Models;
using Facebook_Api.Services.Authantication_Folder;
using Facebook_Api.Services.Repository_Pattern;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Facebook_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryPattern<User> _repositoryPattern;
        private readonly IAuthanticationRepository _authanticationRepository;
        private readonly IMapper _mapper;
        public UserController(IRepositoryPattern<User> repositoryPattern, IMapper mapper,IAuthanticationRepository authanticationRepository)
        {
            _repositoryPattern = repositoryPattern;
            _mapper = mapper;
            _authanticationRepository = authanticationRepository;
        }
        [HttpGet]
        public async Task<ActionResult<ServicesRespone<List<UserGetDto>>>> GetAllUsers()
        {
            var respone= new ServicesRespone<List<UserGetDto>>();
            var data = await _repositoryPattern.GetAll();
            respone.Data=_mapper.Map<List<UserGetDto>>(data);
            return Ok(respone);
            
        }
        [HttpPut]
        public async Task<ActionResult<ServicesRespone<UserGetDto>>>UpdateUserInfo(UserUpdateDto user)
        {

            return Ok(await (_authanticationRepository.UpdateProfile(user)));

        }

    }
}
