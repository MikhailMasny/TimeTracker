using System;

namespace Masny.TimeTracker.Data.Models
{
    /// <summary>
    /// Goal.
    /// </summary>
    public class Goal
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Project identifier.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Navigation property for project.
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// End.
        /// </summary>
        public DateTime End { get; set; }
    }
}
