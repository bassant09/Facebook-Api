using Facebook_Api.DTOS.FriendDtos;
using Facebook_Api.DTOS.PostDtos;
using Facebook_Api.Models;

namespace Facebook_Api.Services.Friends_Controller
{
    public interface IFriendServices
    {
        Task<ServicesRespone<GetFriendDto>> AddFriend(int UserId);
        Task<ServicesRespone<GetFriendDto>> RemoveFriend(int UserId);
    }
}
