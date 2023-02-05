using AutoMapper;
using Facebook_Api.Data;
using Facebook_Api.DTOS.CommentDtos;
using Facebook_Api.DTOS.CommentReactionDto;
using Facebook_Api.DTOS.PostDtos;
using Facebook_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace Facebook_Api.Services.Comment_Folder
{
    public class CommentService : ICommentServices
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public CommentService(DataContext db, IMapper mapper, IHttpContextAccessor httpContextAccessor)
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
        public async Task<ServicesRespone<List<GetCommentsDto>>> AddComment(AddCommentDto comment)
        {
            var post = await _db.Posts.FirstOrDefaultAsync(e => e.Id ==comment.Post.Id);
            var respone = new ServicesRespone<List<GetCommentsDto>>();
          Comment Comment =_mapper.Map<Comment>(comment);
            Comment.User= await _db.Users.FirstOrDefaultAsync(e => e.Id == GetUserId());
            Comment.Post = post;
            _db.Comments.Add(Comment);
            await _db.SaveChangesAsync();
            var data = _db.Comments.Where(e => e.User.Id == GetUserId()).Select(c => _mapper.Map<GetCommentsDto>(c)).ToList();
            respone.Data = data; 
            return respone; 


        }

        public  async Task<ServicesRespone<string>> DeleteComment(int Id, int PostId)
        {
            var respone = new ServicesRespone<string>();

            //var post = _db.Posts.FirstOrDefault(e => e.Id == PostId&&e.User.Id==GetUserId());
            var comment =_db.Comments.FirstOrDefault(e => e.Id == Id&&e.Post.Id==PostId&&e.User.Id==GetUserId());
            if (comment == null)
            {
                respone.Success = false;
                respone.Message = "Comment Not Found ";
            }
            else
            {
                _db.Comments.Remove(comment);
                await _db.SaveChangesAsync();
                respone.Success =true;
                respone.Message = "Comment Deleted Successfully";
            }
            return respone;

        }
        public  async Task<ServicesRespone<GetCommentsDto>> EditComment(EditCommentDto comment)
        {
            var respone = new ServicesRespone<GetCommentsDto>();

            var OldComment = _db.Comments.Include(e=>e.User). FirstOrDefault(e => e.Id == comment.Id && e.User.Id == GetUserId());
            if (OldComment == null)
            {
                respone.Success=false;
                respone.Message = "Comment Not Found ";
                return respone;
            }
            _mapper.Map(comment,OldComment);
            _db.Comments.Update(OldComment);
           await _db.SaveChangesAsync();
            respone.Data = _mapper.Map<GetCommentsDto>(OldComment);
            return respone;


        }
    }
}
