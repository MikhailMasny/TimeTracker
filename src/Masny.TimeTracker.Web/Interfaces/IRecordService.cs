using System.Threading.Tasks;

namespace Masny.TimeTracker.Web.Interfaces
{
    /// <summary>
    /// Record service.
    /// </summary>
    public interface IRecordService
    {
        /// <summary>
        /// Add record.
        /// </summary>
        /// <param name="value">Object.</param>
        /// <param name="token">Jwt token.</param>
        Task AddAsync(object value, string token);
    }
}
