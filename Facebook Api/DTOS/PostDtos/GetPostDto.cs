using Facebook_Api.DTOS.AuthDtos;
using Facebook_Api.Models;

namespace Facebook_Api.DTOS.PostDtos
{
    public class GetPostDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdataAt { get; set; }
        public string ImagePath { get; set; } =String.Empty;
        public UserGetDto User { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<PostReaction>? PostReactions { get; set; }


    }
}
