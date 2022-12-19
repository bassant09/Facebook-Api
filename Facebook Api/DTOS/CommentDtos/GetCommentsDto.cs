using Facebook_Api.DTOS.AuthDtos;
using Facebook_Api.DTOS.PostDtos;
using Facebook_Api.Models;

namespace Facebook_Api.DTOS.CommentDtos
{
    public class GetCommentsDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public UserGetDto User { get; set; }
        public GetPostDto Post { get; set; }
        public Comment? ReplyCommentId { get; set; }
        public List<CommentReaction>? commentReactions { get; set; }
    }
}
