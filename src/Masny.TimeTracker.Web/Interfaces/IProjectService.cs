using Masny.TimeTracker.WebApp.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Masny.TimeTracker.Web.Interfaces
{
    /// <summary>
    /// Project service.
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// Get all projects.
        /// </summary>
        /// <param name="token">Jwt token.</param>
        /// <returns>Project collection.</returns>
        Task<IEnumerable<ProjectItemResponse>> GetAllAsync(string token);
    }
}
