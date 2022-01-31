using System;

namespace Masny.TimeTracker.WebApi.Contracts.Requests
{
    /// <summary>
    /// Record update operation request.
    /// </summary>
    public class RecordUpdateRequest
    {
        /// <summary>
        /// Start.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// End.
        /// </summary>
        public DateTime End { get; set; }
    }
}
