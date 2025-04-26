namespace Chitter.Models{
    /// <summary>
    /// user info
    /// </summary>
    /// <author>Ivy N</author>
    public class User
    {
        public int Id { get; set;}
        public string UserName { get; set;}
        // Relational Properties
        public List<ChitPost> ChitPosts {get; set;}
        public List<ChitPostComment> ChitPostComments {get; set;}
    }
}