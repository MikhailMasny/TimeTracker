using Masny.TimeTracker.Data.Enums;
using System;

namespace Masny.TimeTracker.Data.Models
{
    /// <summary>
    /// Record.
    /// </summary>
    public class Record
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
        /// Start.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// End.
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public RecordType Type { get; set; }
    }
}
