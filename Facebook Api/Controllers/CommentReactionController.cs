using Facebook_Api.DTOS.BlockDto;
using Facebook_Api.DTOS.CommentDtos;
using Facebook_Api.DTOS.CommentReactionDto;
using Facebook_Api.Models;
using Facebook_Api.Services.CommentReaction_Folder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Facebook_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentReactionController : ControllerBase
    {
        private readonly ICommentReactionServices _services;
        public CommentReactionController(ICommentReactionServices commentReactionServices)
        {
            _services = commentReactionServices;

        }
        [HttpPost("AddReact/ {PostId} {CommentId} {react}")]
        public async Task<ActionResult<ServicesRespone<GetCommentReactionsDto>>> AddCommentReaction(int PostId,int CommentId, Reaction react)
        {
            return Ok(await _services.AddCommentReact(PostId,CommentId,react));

        }
        [HttpDelete("DeleteReact/{PostId}/{CommentId}")]

        public async Task<ActionResult<ServicesRespone<string>>> DeleteCommentReaction(int PostId, int CommentId)
        {
            return Ok(await _services.DeleteCommentReact(PostId, CommentId));

        }
        [HttpGet ("ShowALLReacts/ {CommentId}")]
        public async Task<ActionResult<ServicesRespone<List<GetCommentReactionsDto>>>> ShowAllCommentReaction(int CommentId)
        {
            return Ok(await _services.ShowAllCommentReaction(CommentId));

        }


    }
}
