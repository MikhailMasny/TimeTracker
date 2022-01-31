using System.Collections.Generic;

namespace Masny.TimeTracker.Logic.Models
{
    /// <summary>
    /// User.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Fullname.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
