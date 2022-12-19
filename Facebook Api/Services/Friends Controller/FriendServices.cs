using AutoMapper;
using Facebook_Api.Data;
using Facebook_Api.DTOS.FriendDtos;
using Facebook_Api.DTOS.PostDtos;
using Facebook_Api.Models;
using System.Security.Claims;

namespace Facebook_Api.Services.Friends_Controller
{
    public class FriendServices : IFriendServices
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public FriendServices(DataContext db, IMapper mapper, IHttpContextAccessor httpContextAccessor)
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
        public  async Task<ServicesRespone<GetFriendDto>> AddFriend(int UserId)
        {
            var respone = new ServicesRespone<GetFriendDto>();  
            var friend = new Friend();
            var User1 =_db.Users.FirstOrDefault(x => x.Id==GetUserId());
            var User2 = _db.Users.FirstOrDefault(x => x.Id == UserId);
            if (User2 == null)
            {
                respone.Success = false;
                respone.Message = "User Not Found";
                return respone; 
            }
            friend.User1 = User1;
            friend.User2 = User2;
            _db.Friends.Add(friend); 
           await _db.SaveChangesAsync();
            respone.Data = _mapper.Map<GetFriendDto>(friend); 
           return respone;
            
        }
        public async Task<ServicesRespone<GetFriendDto>> RemoveFriend(int UserId)
        {
            var respone = new ServicesRespone<GetFriendDto>();
            var friend = new Friend();
            var User1 = _db.Users.FirstOrDefault(x => x.Id == GetUserId());
            var User2 = _db.Users.FirstOrDefault(x => x.Id == UserId);
            if (User2 == null)
            {
                respone.Success = false;
                respone.Message = "User Not Found";
                return respone;
            }
            friend.User1 = User1;
            friend.User2 = User2;
            if (friend.Status == 0)
            {
                respone.Message = "Request canceled";
            }
            else
            {
                respone.Message = "Unfriend Successfully ";
            }
            _db.Friends.Remove(friend);
            await _db.SaveChangesAsync();
            respone.Success = true; 
            return respone;


        }
    }
}
