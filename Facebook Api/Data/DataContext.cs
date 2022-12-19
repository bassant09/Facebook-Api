using Facebook_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Facebook_Api.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CommentReaction>().HasKey(e => new { e.UserId, e.CommentId, });
            modelBuilder.Entity<PostReaction>().HasKey(e => new { e.UserId, e.PostId, });
            modelBuilder.Entity<Block>().HasKey(e => new { e.UserId1, e.UserId2, });
            modelBuilder.Entity<Friend>().HasKey(e => new { e.UserId1, e.UserId2, });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<CommentReaction> CommentReactions { get; set; }
        public DbSet<PostReaction>PostReactions{ get; set; }
        public DbSet<Block> Blocks{ get; set; }
    }
}
