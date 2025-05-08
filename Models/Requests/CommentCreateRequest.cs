using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

/// <summary>
    /// Requests to make a comment
    /// </summary>
    /// <author>Ivy N</author>

namespace Chitter.Models.Requests {

    public class CommentCreateRequest {
        //public int CommentId {get; set;}
        public int ChitPostId {get; set;}
        public int ParentCommentId {get; set;}
        [MinLength(1, ErrorMessage = "Must contain at least 1 character")]
        [MaxLength(500, ErrorMessage = "Must contain 500 characters or less")]
        public string Content { get; set; }
        public int UserId {get; set;}
        //public string UserName {get; set;}
        public DateTime TimeCreated {get; set;}

    }

}