using Facebook_Api.DTOS.CommentDtos;
using Facebook_Api.DTOS.PostDtos;
using Facebook_Api.Models;
using Facebook_Api.Services.Comment_Folder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Facebook_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentServices _services;
        public CommentController(ICommentServices commentServices)
        {
            _services = commentServices;

        }
        [HttpPost("Add")]
        public async Task<ActionResult<ServicesRespone<List<GetCommentsDto>>>> AddComment(AddCommentDto comment)
        {
            //int userId = int.Parse(User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _services.AddComment(comment));
        }
        [HttpDelete("deleteComment/{Id} {PostId}")]
        public async Task<ActionResult<ServicesRespone<string>>>DeleteComment(int Id, int PostId){
            return Ok(await _services.DeleteComment(Id, PostId)); 
            }

    }
}
