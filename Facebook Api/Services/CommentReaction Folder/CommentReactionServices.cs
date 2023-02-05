using AutoMapper;
using Facebook_Api.Data;
using Facebook_Api.DTOS.CommentReactionDto;
using Facebook_Api.DTOS.FriendDtos;
using Facebook_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Facebook_Api.Services.CommentReaction_Folder
{
    public class CommentReactionServices : ICommentReactionServices
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public CommentReactionServices( DataContext db,IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _mapper = mapper;
            _contextAccessor = httpContextAccessor; 


        }
        private int GetUserId()
        {
            int userId = int.Parse(_contextAccessor.HttpContext.User.
                FindFirstValue(ClaimTypes.NameIdentifier));
            return userId;
        }
        public async Task<ServicesRespone<GetCommentReactionsDto>> AddCommentReact(int PostId, int CommentId, Reaction react)
        {
            var respone = new ServicesRespone<GetCommentReactionsDto>();
            var Commentreact = new CommentReaction(); 
            var comment =_db.Comments.FirstOrDefault(e => e.Id == CommentId && e.Post.Id == PostId && e.User.Id == GetUserId());
            var user = _db.Users.FirstOrDefault(e => e.Id == GetUserId()); 
            if(comment == null)
            {
                respone.Success = false;
                respone.Message = "Comment Not Found ";
                return respone; 
            }
            var found = _db.CommentReactions.FirstOrDefault(e => e.UserId == GetUserId() && e.CommentId == CommentId );

            if (found != null)
            {
                respone.Message = "There is Already reaction on this comment";
                respone.Success = false;
                return respone;
            }
            Commentreact.Comment = comment;
            Commentreact.User = user;
            Commentreact.Reaction = react;
            _db.CommentReactions.Add(Commentreact); 
           await  _db.SaveChangesAsync();
            respone.Data = _mapper.Map<GetCommentReactionsDto>(Commentreact);
            return respone; 

        }

        public async Task<ServicesRespone<string>> DeleteCommentReact(int PostId, int CommentId)
        {
            var respone = new ServicesRespone<string>();
            var Commentreact = new CommentReaction();
            var comment = _db.Comments.FirstOrDefault(e => e.Id == CommentId && e.Post.Id == PostId && e.User.Id == GetUserId());
            var user = _db.Users.FirstOrDefault(e => e.Id == GetUserId());
            if (comment == null)
            {
                respone.Success = false;
                respone.Message = "Comment Not Found ";
                return respone;
            }
            var found = _db.CommentReactions.FirstOrDefault(e => e.UserId == GetUserId() && e.CommentId == CommentId);
            if(found == null)
            {
                respone.Success = false; 
                respone.Message="Already No React on this Comment "; 
                    return respone;
            }
            var reaction = _db.CommentReactions.FirstOrDefault(e => e.UserId == GetUserId() && e.CommentId == CommentId );
            _db.CommentReactions.Remove(reaction);
            await _db.SaveChangesAsync();
           respone.Data ="React Deleted Successfully";
            return respone;
        }

        public async Task<ServicesRespone<List<GetCommentReactionsDto>>> ShowAllCommentReaction( int CommentId )
        {
            var respone = new ServicesRespone<List<GetCommentReactionsDto>>();
            var AllReaction = _db.CommentReactions.Include(e=>e.Comment).Where(e=>e.CommentId==CommentId);
            if (AllReaction == null)
            {
                respone.Message = "No React";
                return respone; 
            }
            respone.Data =AllReaction.Select(c => _mapper.Map<GetCommentReactionsDto>(c)).ToList();
            return respone; 
        }
    }
}
