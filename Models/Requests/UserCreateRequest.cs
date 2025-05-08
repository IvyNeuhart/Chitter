using System.ComponentModel.DataAnnotations;

/// <summary>
    /// Requests to create user
    /// </summary>
    /// <author>Ivy N</author>

namespace Chitter.Models.Requests
{
    public class UserCreateRequest
    {
        //public int Id { get; set;} unneccessary

        [MinLength(1, ErrorMessage = "Must contain at least 1 character")]
        [MaxLength(25, ErrorMessage = "Must contain 25 characters or less")]
        public string UserName { get; set;}
    }
}