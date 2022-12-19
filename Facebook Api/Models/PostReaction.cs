using System.ComponentModel.DataAnnotations.Schema;

namespace Facebook_Api.Models
{
    public class PostReaction
    {
        public Reaction Reaction { get; set; } = Reaction.Angry;
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
