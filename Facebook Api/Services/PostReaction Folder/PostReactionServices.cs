using AutoMapper;
using Facebook_Api.Data;
using Facebook_Api.DTOS.CommentReactionDto;
using Facebook_Api.DTOS.PostReactions_Dtos;
using Facebook_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Security.Claims;

namespace Facebook_Api.Services.PostReaction_Folder
{
    public class PostReactionServices : IPostReactionServices
    {
        private readonly IMapper _mapper;
        private readonly DataContext _db;
        private readonly IHttpContextAccessor _contextAccessor;
        public PostReactionServices(IMapper mapper, DataContext dataContext, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _db = dataContext;
            _contextAccessor = contextAccessor;
        }
        private int GetUserId()
        {
            int userId = int.Parse(_contextAccessor.HttpContext.User.
                FindFirstValue(ClaimTypes.NameIdentifier));
            return userId;
        }
        public async Task<ServicesRespone<GetPostReactionDto>> AddPostReact(int PostId, Reaction react)
        {
            var respone = new ServicesRespone<GetPostReactionDto>();
            var Postreact = new PostReaction();

            var post = _db.Posts.FirstOrDefault(e => e.Id == PostId);
            if (post == null)
            {
                respone.Success = false; 
                respone.Message="Post Not Found"; 
                return respone;
            }
            var found = _db.PostReactions.FirstOrDefault(e => e.UserId == GetUserId() && e.PostId == PostId);
            if (found != null)
            {
                respone.Success = false;
                respone.Message = "Already React Found on this Post ";
                return respone;
            }
            Postreact.PostId = PostId;
            Postreact.UserId = GetUserId();
            Postreact.Reaction = react; 
            _db.PostReactions.Add(Postreact);
           await _db.SaveChangesAsync();
            respone.Data = _mapper.Map<GetPostReactionDto>(Postreact);
            return respone;
        }

        public async Task<ServicesRespone<string>> DeletePostReact(int PostId)
        {
            var respone = new ServicesRespone<string>();
            var Postreact = new PostReaction();

            var post = _db.Posts.FirstOrDefault(e => e.Id == PostId);
            if (post == null)
            {
                respone.Success = false;
                respone.Message = "Post Not Found";
                return respone;
            }
             var postreact =_db.PostReactions.FirstOrDefault(e=>e.UserId==GetUserId()&&e.PostId == PostId);
            if(postreact == null)
            {
                respone.Success = false;
                respone.Message = "No React ";
                return respone;

            }
            _db.PostReactions.Remove(postreact);
            await _db.SaveChangesAsync();
            respone.Data = "React on Post Deleted Successfully ";
            return respone; 
        }

        public async Task<ServicesRespone<List<GetPostReactionDto>>> ShowAllPostReaction(int PostId)
        {
            var respone = new ServicesRespone<List<GetPostReactionDto>>();
            var AllReaction = _db.PostReactions.Include(e => e.Post).Where(e => e.PostId==PostId);
            if (AllReaction == null)
            {
                respone.Message = "No React";
                return respone;
            }
            respone.Data = AllReaction.Select(c => _mapper.Map<GetPostReactionDto>(c)).ToList();
            return respone;

        }
    }
}
