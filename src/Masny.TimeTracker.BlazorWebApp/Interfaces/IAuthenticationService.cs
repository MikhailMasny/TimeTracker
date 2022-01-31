using Masny.TimeTracker.WebApp.Shared.Models;
using System.Threading.Tasks;

namespace Masny.TimeTracker.BlazorWebApp.Client.Interfaces
{
    /// <summary>
    /// Authentication service.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// User.
        /// </summary>
        UserAuthModel User { get; }

        /// <summary>
        /// Initialize.
        /// </summary>
        Task Initialize();

        /// <summary>
        /// Login.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        Task Login(string email, string password);

        /// <summary>
        /// Logout.
        /// </summary>
        Task Logout();
    }
}
