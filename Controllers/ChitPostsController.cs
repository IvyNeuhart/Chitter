using Microsoft.AspNetCore.Mvc;
using Chitter.Repositories;
using Chitter.Models;
using Microsoft.EntityFrameworkCore;
using Chitter.Models.Requests;
using Microsoft.Extensions.Configuration.UserSecrets;


namespace ChitPostController.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChitPostController : ControllerBase
    {
        private readonly ChitterDbContext _context;
        //Contructor
        public ChitPostController(ChitterDbContext context)
        {
            _context = context;
        }
        //CRUD endpoints here
        [HttpGet("/chit-posts", Name = "GetChitPosts")]
        
        public List<ChitPost> GetChitPosts()
        {
            return _context.ChitPosts
            .Include(b => b.User)
            .Include(b => b.ChitPostComments)
            .ToList();
        }

        [HttpPost("/create-chit-post", Name = "CreateChitPost")]
        public ChitPost CreateChitPost(ChitPostCreateRequest request) {
            // Map our BookCreateRequest to an actual Book.
            ChitPost chitPostToPost = new ChitPost{
                //Id = request.ChitPostId,// In an actual app we would generally use a generated ID from a database.
                Content = request.Content,
                UserId = request.UserId,
                TimeCreated = request.TimeCreated,
            };
            
            // "Save" the book by simply adding it to our list of books.
            _context.ChitPosts.Add(chitPostToPost);
            _context.SaveChanges();
            // Return our newly saved Ski Model.
            return chitPostToPost;
        }
        [HttpPost("/create-user", Name = "CreateUser")] 
        public User CreateUser(UserCreateRequest request)
        {
            User userToCreate = new User
            {
                //Id = request.Id, unneccessary. Id will be automatically made in database
                UserName = request.UserName,
            };
            _context.Users.Add(userToCreate);
            _context.SaveChanges();
            return userToCreate;
        }
        [HttpPost("/create-comment", Name = "Create Comment")]
        public ChitPostComment CreateComment(CommentCreateRequest request) {
            ChitPostComment commentToPost = new ChitPostComment{
                //Id = request.CommentId,
                ChitPostId = request.ChitPostId,
                Content = request.Content,
                UserId = request.UserId,
                //User = UserId.User
                TimeCreated = request.TimeCreated,
            };
            _context.ChitPostComments.Add(commentToPost);
            _context.SaveChanges();
            // Return our newly saved Ski Model.
            return commentToPost;
        }
    }
}