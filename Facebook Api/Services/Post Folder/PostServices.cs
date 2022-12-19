using AutoMapper;
using Facebook_Api.Data;
using Facebook_Api.DTOS.PostDtos;
using Facebook_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Facebook_Api.Services.Post_Folder
{
    public class PostServices : IPostServices
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public PostServices(DataContext db,IMapper mapper,IHttpContextAccessor httpContextAccessor)
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
        public async Task<ServicesRespone<List<GetPostDto>>> GetAllPosts()
        {
            var data = await _db.Posts.Include(e=>e.User).Include(e=>e.PostReactions).Include(e=>e.Comments) . Where(e => e.User.Id == GetUserId()).ToListAsync();  
            var respone = new ServicesRespone<List<GetPostDto>>();
            respone.Data = data.Select(c => _mapper.Map<GetPostDto>(c)).ToList();
            return respone; 
        }

        public async  Task<ServicesRespone<GetPostDto>> AddPost(AddPostDto post)
        {
            var servicesRespone = new ServicesRespone<GetPostDto>();
            Post Post =_mapper.Map<Post>(post);
            Post.User = await _db.Users.FirstOrDefaultAsync(e => e.Id == GetUserId()); 
            _db.Posts.Add(Post);
           await _db.SaveChangesAsync();
            servicesRespone.Data = _mapper.Map<GetPostDto>(Post); 

            return servicesRespone;

        }

        public async Task<ServicesRespone<List<GetPostDto>>> DeletePost(int? Id)
        {
            var respone = new ServicesRespone<List<GetPostDto>>();

            if (Id==null)
            {
                respone.Success = false;
                respone.Message = "Post Not Found";
            }
            var post = _db.Posts.FirstOrDefault(e => e.Id == Id && e.User.Id == GetUserId());
             _db.Posts.Remove(post);
            await _db.SaveChangesAsync();
            respone.Data = _db.Posts.Where(e => e.User.Id == GetUserId()).Select(c => _mapper.Map<GetPostDto>(c)).ToList(); 
            return respone; 
        }

        public async Task<ServicesRespone<GetPostDto>> EditPost(EditPostDto post)
        {
            var respone = new ServicesRespone<GetPostDto>();

            var OldPost = _db.Posts.FirstOrDefault(e => e.Id == post.Id && e.User.Id == GetUserId()); 
            if(OldPost==null)
            {
                respone.Success =false;
                respone.Message = " Post not Found";
                return respone;
            }

            _mapper.Map(post,OldPost);
            _db.Posts.Update(OldPost);
            await _db.SaveChangesAsync();
            respone.Data = _mapper.Map<GetPostDto>(OldPost);
            return respone; 

        }
    }
}
