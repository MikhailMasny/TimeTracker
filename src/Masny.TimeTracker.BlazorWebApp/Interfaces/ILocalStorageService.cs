using System.Threading.Tasks;

namespace Masny.TimeTracker.BlazorWebApp.Client.Interfaces
{
    /// <summary>
    /// Local storage service.
    /// </summary>
    public interface ILocalStorageService
    {
        /// <summary>
        /// Get.
        /// </summary>
        /// <typeparam name="T">Generic.</typeparam>
        /// <param name="key">Key.</param>
        Task<T> GetItem<T>(string key);

        /// <summary>
        /// Set.
        /// </summary>
        /// <typeparam name="T">Generic.</typeparam>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        Task SetItem<T>(string key, T value);

        /// <summary>
        /// Remove.
        /// </summary>
        /// <param name="key">Key.</param>
        Task RemoveItem(string key);
    }
}
