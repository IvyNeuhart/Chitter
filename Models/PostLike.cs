namespace Chitter.Models{

    /// <summary>
    /// "like" info for post likes
    /// </summary>
    /// <author>Ivy N</author>
    public class PostLike
    {
        public int Id {get; set;}
        //relational data
        public int UserId {get; set;}
        public int ChitPostId {get; set;}
    }
}