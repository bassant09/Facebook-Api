namespace Facebook_Api.Models
{
    public class Comment
    {
        public int Id { get; set; } 
        public string  Content { get; set; }
        public  User User { get; set; }
        public  Post Post  { get; set; }
        public Comment? ReplyCommentId { get; set; }
        public List<CommentReaction>? commentReactions { get; set; }
    }
}
