using Facebook_Api.DTOS.PostDtos;

namespace Facebook_Api.DTOS.CommentDtos
{
    public class EditCommentDto
    {
        public int Id { get; set; }
        public PostCommentDto Post { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; } = String.Empty;
    }
}
