using System.ComponentModel.DataAnnotations.Schema;

namespace Facebook_Api.Models
{
    public class Block
    {
        [ForeignKey(nameof(User1))]
        public int UserId1 { get; set; }
        public User User1 { get; set; }

        [ForeignKey(nameof(User2))]
        public int UserId2 { get; set; }
        public User User2 { get; set; }
    }
}
