using Facebook_Api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facebook_Api.DTOS.PostReactions_Dtos
{
    public class GetPostReactionDto
    {
        public Reaction Reaction { get; set; } = Reaction.Angry;
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
