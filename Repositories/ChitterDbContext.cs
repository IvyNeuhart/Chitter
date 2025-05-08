using Chitter.Models;
using Microsoft.EntityFrameworkCore;

namespace Chitter.Repositories
{
    public class ChitterDbContext: DbContext
    {
        public ChitterDbContext(DbContextOptions<ChitterDbContext> options): base(options)
        {

        }
        // alllows us to save things to database
        public DbSet<User> Users {get; set;}
        public DbSet<ChitPost> ChitPosts {get; set;}
        public DbSet<ChitPostComment> ChitPostComments {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChitPostComment>()
            .HasOne(c => c.User)
            .WithMany(u => u.ChitPostComments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict); // <--- important!! This fixes the issue with multiple cascade paths

        modelBuilder.Entity<ChitPostComment>()
            .HasOne(c => c.ChitPost)
            .WithMany(p => p.ChitPostComments)
            .HasForeignKey(c => c.ChitPostId)
            .OnDelete(DeleteBehavior.Cascade); // This one can stay cascade
        }
    }
}