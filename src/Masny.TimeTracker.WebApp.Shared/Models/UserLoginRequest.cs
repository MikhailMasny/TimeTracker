using System.ComponentModel.DataAnnotations;

namespace Masny.TimeTracker.WebApp.Shared.Models
{
    /// <summary>
    /// User login operation request.
    /// </summary>
    public class UserLoginRequest
    {
        /// <summary>
        /// Email.
        /// </summary>
        [Required(ErrorMessage = "TestMessage")]
        public string Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
