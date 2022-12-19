using Facebook_Api.DTOS.PostDtos;
using Facebook_Api.Models;
using Facebook_Api.Services.Post_Folder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Facebook_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostServices _postServices;
        public PostController(IPostServices postServices)
        {
            _postServices = postServices;   
                
        }
        [HttpGet("get")]
        public async Task<ActionResult<ServicesRespone<List<GetPostDto>>>> GetAllPosts()
        {
            //int userId = int.Parse(User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _postServices.GetAllPosts());
        }
        [HttpPost("Add")]
        public async Task<ActionResult<ServicesRespone<GetPostDto>>>AddPost(AddPostDto post)
        {
            //int userId = int.Parse(User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _postServices.AddPost(post));
        }
        [HttpDelete("delete/{Id}")]
        public async Task<ActionResult<ServicesRespone<List<GetPostDto>>>> DeletePost(int? Id)
        {
            //int userId = int.Parse(User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _postServices.DeletePost(Id));
        }
        [HttpPut("Edit")]
        public async Task<ActionResult<ServicesRespone<GetPostDto>>> EditPost(EditPostDto post)
        {
            //int userId = int.Parse(User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _postServices.EditPost(post));
        }
    }
}
