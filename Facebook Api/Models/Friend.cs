using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Facebook_Api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FriendRequestStatus
    {
        Request=0,
        Accept=1,
    }

    public class Friend
    {
        [ForeignKey (nameof (User1))]
        public int UserId1 { get; set; }
        public User User1 { get; set; }

        [ForeignKey(nameof(User2))]
        public int UserId2 { get; set; }
        public User User2 { get; set; }
        public FriendRequestStatus Status { get; set; } = FriendRequestStatus.Request; 
    }
} 