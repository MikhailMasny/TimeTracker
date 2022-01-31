using Masny.TimeTracker.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Masny.TimeTracker.Logic.Interfaces
{
    /// <summary>
    /// Project manager.
    /// </summary>
    public interface IProjectManager
    {
        /// <summary>
        /// Create project.
        /// </summary>
        /// <param name="model">Project data transfer object.</param>
        Task CreateAsync(ProjectDto model);

        /// <summary>
        /// Get projects by user identifier.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>Project data transfer objects.</returns>
        Task<IEnumerable<ProjectDto>> GetAllByUserIdAsync(string userId);

        /// <summary>
        /// Update project by identifier.
        /// </summary>
        /// <param name="model">Project data transfer object.</param>
        Task UpdateAsync(ProjectDto model);

        /// <summary>
        /// Delete project by identifier.
        /// </summary>
        /// <param name="id">Project identifier.</param>
        /// <param name="id">User identifier.</param>
        Task DeleteAsync(int id, string userId);
    }
}
