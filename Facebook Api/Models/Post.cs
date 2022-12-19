namespace Facebook_Api.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime UpdataAt { get; set; }=DateTime.Now;
        public  string ImagePath  { get; set; }=String.Empty;
        public User User { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<PostReaction>? PostReactions { get; set; }
    }
}
