using System.Text.Json.Serialization;
using Microsoft.Extensions.ObjectPool;

namespace Chitter.Models
{
    public class ChitPost
    {
        public int Id {get; set;}
        public string Content {get; set;}
        public DateTime TimeCreated {get; set;}
        public int UserId {get; set;}
        //[JsonIgnore]
        public User User {get; set;}
        // Relational Properties
        public List<ChitPostComment> ChitPostComments {get; set;}
    }
}