using Microsoft.AspNetCore.Mvc;
using Chitter.Repositories;
using Chitter.Models;
using Microsoft.EntityFrameworkCore;
using Chitter.Models.Requests;
using Microsoft.Extensions.Configuration.UserSecrets;

/// <summary>
    /// All of our controllers
    /// </summary>
    /// <author>Ivy N</author>

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
            .Include(b => b.PostLikes)
            .Include(b => b.ChitPostComments)
            //.Include(b => b.CommentLikes)     need to figure out how to show comment likes
            .ToList();
            
        }

        [HttpPost("/create-chit-post", Name = "CreateChitPost")]
        public ChitPost CreateChitPost(ChitPostCreateRequest request) {
            // Map our request to an actual post
            ChitPost chitPostToPost = new ChitPost{
                //Id = request.ChitPostId,// In an actual app we would generally use a generated ID from a database.
                Content = request.Content,
                UserId = request.UserId,
                TimeCreated = request.TimeCreated,
            };
            
            // "Save" the post by simply adding it to our list of posts.
            _context.ChitPosts.Add(chitPostToPost);
            _context.SaveChanges();
            // Return our newly saved post
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
                ParentCommentId = request.ParentCommentId,
                Content = request.Content,
                UserId = request.UserId,
                //User = UserId.User
                TimeCreated = request.TimeCreated,
            };
            _context.ChitPostComments.Add(commentToPost);
            _context.SaveChanges();
            // Return our newly saved comment
            return commentToPost;
        }

        [HttpPost("/like-post", Name = "Like Post")]
        public PostLike LikePost(LikePostRequest request)
        {
            PostLike postToLike = new PostLike
            {
                UserId = request.UserId,
                ChitPostId = request.ChitPostId,
            };
            _context.PostLikes.Add(postToLike);
            _context.SaveChanges();
            return postToLike;
        }

        [HttpPost("/like-comment", Name = "Like Comment")]
        public CommentLike LikeComment(LikeCommentRequest request)
        {
            CommentLike commentToLike = new CommentLike
            {
                UserId = request.UserId,
                ChitPostCommentId = request.ChitPostCommentId,
            };
            _context.CommentLikes.Add(commentToLike);
            _context.SaveChanges();
            return commentToLike;
        }

        [HttpDelete("unlike-post", Name = "Unlike Post")]
        public void UnlikePost(int id)
        {
            PostLike? postToUnlike = _context.PostLikes.Find(id);
            if (postToUnlike == null)
            {
                throw new Exception($"Post {id} was not found.");
            }
            _context.PostLikes.Remove(postToUnlike);
            _context.SaveChanges();
        }

        [HttpDelete("unlike-comment", Name = "Unlike Comment")]
        public void UnlikeComment(int id)
        {
            CommentLike? commentToUnlike = _context.CommentLikes.Find(id);
            if (commentToUnlike == null)
            {
                throw new Exception($"Comment {id} was not found.");
            }
            _context.CommentLikes.Remove(commentToUnlike);
            _context.SaveChanges();
        }

        [HttpDelete("/delete-post", Name = "Delete Post")]
        public void DeletePost(int Id) {
            // Find the post we need to delete by its ID.
            ChitPost? postToDelete = _context.ChitPosts.Find(Id);

            if (postToDelete == null) {
                throw new Exception($"Post {Id} was not found.");
            }

            // Mark the entity as deleted in the EF change tracker.
            _context.ChitPosts.Remove(postToDelete);
            _context.SaveChanges(); // Execute the DELETE SQL statement.
        }
        [HttpDelete("/delete-user", Name = "Delete User")]
        public void DeleteUser(int Id) {
            // Find the post we need to delete by its ID.
            User? userToDelete = _context.Users.Find(Id);

            if (userToDelete == null) {
                throw new Exception($"User {Id} was not found.");
            }

            // Mark the entity as deleted in the EF change tracker.
            _context.Users.Remove(userToDelete);
            _context.SaveChanges(); // Execute the DELETE SQL statement.
        }

    }
}