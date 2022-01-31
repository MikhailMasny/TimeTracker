using Masny.TimeTracker.Data.Enums;
using System;
using System.Collections.Generic;

namespace Masny.TimeTracker.Data.Models
{
    /// <summary>
    /// Project.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User identifier.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Navigation property for user.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Creation time.
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public ProjectType Type { get; set; }

        /// <summary>
        /// Is favourite.
        /// </summary>
        public bool IsFavourite { get; set; }

        /// <summary>
        /// Navigation property for goal.
        /// </summary>
        public ICollection<Goal> Goals { get; set; }

        /// <summary>
        /// Navigation property for record.
        /// </summary>
        public ICollection<Record> Records { get; set; }
    }
}
