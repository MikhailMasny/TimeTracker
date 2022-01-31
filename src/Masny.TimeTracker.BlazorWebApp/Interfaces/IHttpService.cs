using System.Threading.Tasks;

namespace Masny.TimeTracker.BlazorWebApp.Client.Interfaces
{
    /// <summary>
    /// HttpService.
    /// </summary>
    public interface IHttpService
    {
        /// <summary>
        /// Get.
        /// </summary>
        /// <typeparam name="T">Generic.</typeparam>
        /// <param name="uri">Url.</param>
        /// <returns>Result.</returns>
        Task<T> Get<T>(string uri);

        /// <summary>
        /// Crate with returned result.
        /// </summary>
        /// <typeparam name="T">Generic.</typeparam>
        /// <param name="uri">Url.</param>
        /// <param name="value">Value.</param>
        /// <returns>Result.</returns>
        Task<T> Post<T>(string uri, object value);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="uri">Url.</param>
        /// <param name="value">Value.</param>
        /// <returns>Result.</returns>
        Task PostDefault(string uri, object value);
    }
}
