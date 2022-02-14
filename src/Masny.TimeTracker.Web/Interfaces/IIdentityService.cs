using System.Collections.Generic;
using System.Threading.Tasks;

namespace Masny.TimeTracker.Web.Interfaces
{
    /// <summary>
    /// Identity service.
    /// </summary>
    public interface IIdentityService
    {
        /// <summary>
        /// Login.
        /// </summary>
        /// <param name="value">Object.</param>
        /// <returns>Jwt token.</returns>
        Task<(string token, IList<string> roles)> LoginAsync(object value);
    }
}
