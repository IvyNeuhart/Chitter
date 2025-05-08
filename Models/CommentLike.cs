namespace Chitter.Models{

    /// <summary>
    /// "like" info for comment likes
    /// </summary>
    /// <author>Ivy N</author>
    public class CommentLike
    {
        public int Id {get; set;}
        //relational data
        public int UserId {get; set;}
        public int ChitPostCommentId {get; set;}
    }
}