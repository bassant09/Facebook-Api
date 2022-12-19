using System.ComponentModel.DataAnnotations.Schema;

namespace Facebook_Api.Models
{
    public class CommentReaction
    {
        public Reaction Reaction { get; set; } = Reaction.Angry;
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
