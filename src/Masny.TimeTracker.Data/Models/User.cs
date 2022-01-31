using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Masny.TimeTracker.Data.Models
{
    /// <summary>
    /// User.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Fullname.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Navigation property for project.
        /// </summary>
        public ICollection<Project> Projects { get; set; }
    }
}
