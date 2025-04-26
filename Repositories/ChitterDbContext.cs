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
    }
}