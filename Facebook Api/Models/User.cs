namespace Facebook_Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime BithDate { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber{ get; set; }
        public string ProfilePicturePath { get; set; } = string.Empty; 
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public List<Post>? Posts { get; set; }
        public List<Comment>?Comments { get; set; }
        public List<CommentReaction>? CommentReactions { get; set; }
        public List<PostReaction>? PostReactions { get; set; }
    }
}
