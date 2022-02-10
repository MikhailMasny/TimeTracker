using Masny.TimeTracker.Core.Enums;
using System;

namespace Masny.TimeTracker.Logic.Models
{
    /// <summary>
    /// Project.
    /// </summary>
    public class ProjectDto
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
    }
}
