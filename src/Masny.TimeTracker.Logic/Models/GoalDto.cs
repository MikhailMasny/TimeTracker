using System;

namespace Masny.TimeTracker.Logic.Models
{
    /// <summary>
    /// Goal.
    /// </summary>
    public class GoalDto
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
