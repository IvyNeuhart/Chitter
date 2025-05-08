using System.Text.Json.Serialization;

namespace Chitter.Models
{
    public class ChitPostComment
    {
        public int Id {get; set;}
        public string Content {get; set;}
        public DateTime TimeCreated {get; set;}
        //Relational Data
        public int UserId {get; set;}
        [JsonIgnore]
        public User User {get; set;}
        public int ChitPostId {get; set;}
        [JsonIgnore]
        public ChitPost ChitPost {get; set;}
        public int CommentParentId {get; set;}
        
    }
}