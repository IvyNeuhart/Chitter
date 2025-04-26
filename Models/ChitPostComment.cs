namespace Chitter.Models
{
    public class ChitPostComment
    {
        public int CommentId {get; set;}
        public string Content {get; set;}
        public DateTime TimeCreated {get; set;}
        //Relational Data
        public int UserId {get; set;}
        public int ChitPostId {get; set;}
        
    }
}