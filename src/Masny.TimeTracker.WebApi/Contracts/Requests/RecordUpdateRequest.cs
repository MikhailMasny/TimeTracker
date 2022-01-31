using Masny.TimeTracker.Data.Enums;
using System;

namespace Masny.TimeTracker.WebApi.Contracts.Requests
{
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
