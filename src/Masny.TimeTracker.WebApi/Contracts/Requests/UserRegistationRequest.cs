using System.ComponentModel.DataAnnotations;

namespace Masny.TimeTracker.WebApi.Contracts.Requests
{
    /// <summary>
    /// User registration operation request.
    /// </summary>
    public class UserRegistationRequest
    {
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Fullname.
        /// </summary>
        [Required]
        public string FullName { get; set; }
    }
}
