using Masny.TimeTracker.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Masny.TimeTracker.Logic.Interfaces
{
    /// <summary>
    /// Record manager.
    /// </summary>
    public interface IRecordManager
    {
        /// <summary>
        /// Create record.
        /// </summary>
        /// <param name="model">Record data transfer object.</param>
        /// <param name="userId">User identifier.</param>
        Task CreateAsync(RecordDto model, string userId);

        /// <summary>
        /// Get records by project identifier.
        /// </summary>
        /// <param name="projectId">Project identifier.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>Record data transfer objects.</returns>
        Task<IEnumerable<RecordDto>> GetAllByProjectIdAsync(int projectId, string userId);

        /// <summary>
        /// Update record by identifier.
        /// </summary>
        /// <param name="model">Record data transfer object.</param>
        Task UpdateAsync(RecordDto model, string userId);

        /// <summary>
        /// Delete record by identifier.
        /// </summary>
        /// <param name="id">Record identifier.</param>
        /// <param name="userId">User identifier.</param>
        Task DeleteAsync(int id, string userId);
    }
}
