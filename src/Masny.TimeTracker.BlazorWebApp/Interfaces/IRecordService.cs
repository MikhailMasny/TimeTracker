using System;
using System.Threading.Tasks;

namespace Masny.TimeTracker.BlazorWebApp.Client.Interfaces
{
    /// <summary>
    /// Record service.
    /// </summary>
    public interface IRecordService
    {
        /// <summary>
        /// Create.
        /// </summary>
        /// <param name="projectId">Project identifier.</param>
        /// <param name="start">Start.</param>
        /// <param name="end">End.</param>
        Task Create(int projectId, DateTime start, DateTime end);
    }
}
