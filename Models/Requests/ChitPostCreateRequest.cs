using System.ComponentModel.DataAnnotations;

/// <summary>
    /// Requests to make a chitpost
    /// </summary>
    /// <author>Ivy N</author>

namespace Chitter.Models.Requests {

    public class ChitPostCreateRequest {
        //public int ChitPostId {get; set;}
        [MinLength(1, ErrorMessage = "Must contain at least 1 character")]
        [MaxLength(500, ErrorMessage = "Must contain 500 characters or less")]
        public string Content { get; set; }
        public int UserId {get; set;}
        public DateTime TimeCreated {get; set;}

    }

}