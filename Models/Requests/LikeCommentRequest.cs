using System.ComponentModel.DataAnnotations;
using Microsoft.Net.Http.Headers;

/// <summary>
/// Requests to like commment
/// </summary>
/// <author>Ivy N</author>

namespace Chitter.Models.Requests
{
    public class LikeCommentRequest
    {
        public int ChitPostCommentId {get; set;}
        public int UserId {get; set;}
    }
}