using Masny.TimeTracker.Core.Enums;
using System;

namespace Masny.TimeTracker.WebApp.Shared.Models
{
    /// <summary>
    /// Project item response.
    /// </summary>
    public class ProjectItemResponse
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
