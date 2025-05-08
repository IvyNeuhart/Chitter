using System.ComponentModel.DataAnnotations;
using Microsoft.Net.Http.Headers;

/// <summary>
/// Requests to like post
/// </summary>
/// <author>Ivy N</author>

namespace Chitter.Models.Requests
{
    public class LikePostRequest
    {
        public int ChitPostId {get; set;}
        //re
        public int UserId {get; set;}
    }
}