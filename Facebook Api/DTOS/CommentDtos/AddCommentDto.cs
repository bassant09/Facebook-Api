using Facebook_Api.DTOS.PostDtos;
using Facebook_Api.Models;

namespace Facebook_Api.DTOS.CommentDtos
{
    public class AddCommentDto
    {
        public string Content { get; set; }
        public PostCommentDto Post { get; set; }
    }
}
