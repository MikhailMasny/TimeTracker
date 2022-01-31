using System;
using System.ComponentModel.DataAnnotations;

namespace Masny.TimeTracker.WebApp.Shared.Models
{
    /// <summary>
    /// Record create operation request.
    /// </summary>
    public class RecordCreateRequest
    {
        /// <summary>
        /// Project identifier.
        /// </summary>
        [Required]
        public int ProjectId { get; set; }

        /// <summary>
        /// Start.
        /// </summary>
        [Required]
        public DateTime Start { get; set; }

        /// <summary>
        /// End.
        /// </summary>
        [Required]
        public DateTime End { get; set; }
    }
}
