using Facebook_Api.DTOS.CommentReactionDto;
using Facebook_Api.DTOS.PostReactions_Dtos;
using Facebook_Api.Models;
using Facebook_Api.Services.PostReaction_Folder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Facebook_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostReactionController : ControllerBase
    {
        private readonly IPostReactionServices _postReactionServices;
        public PostReactionController(IPostReactionServices postReactionServices)
        {
            _postReactionServices = postReactionServices;

        }
        [HttpPost("AddReact/{PostId}/{react}")]
        public async Task<ActionResult<ServicesRespone<GetPostReactionDto>>> AddPostReaction(int PostId, Reaction react)
        {
            return Ok(await _postReactionServices.AddPostReact(PostId,  react));

        }
        [HttpDelete("DeleteReact/{PostId}")]

        public async Task<ActionResult<ServicesRespone<string>>> DeletePostReaction(int PostId)
        {
            return Ok(await _postReactionServices.DeletePostReact(PostId));

        }
        [HttpGet("ShowALLReacts/{PostId}")]
        public async Task<ActionResult<ServicesRespone<List<GetCommentReactionsDto>>>> ShowAllPostReaction(int PostId)
        {
            return Ok(await _postReactionServices.ShowAllPostReaction(PostId));

        }

    }
}
