using Facebook_Api.DTOS.AuthDtos;
using Facebook_Api.Models;

namespace Facebook_Api.DTOS.FriendDtos
{
    public class GetFriendDto
    {
        public UserGetDto User1 { get; set; }
        public UserGetDto User2 { get; set; }
        public FriendRequestStatus Status { get; set; } = FriendRequestStatus.Request;
    }
}
