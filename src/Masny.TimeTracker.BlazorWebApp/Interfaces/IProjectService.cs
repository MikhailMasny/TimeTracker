using System.Threading.Tasks;

namespace Masny.TimeTracker.BlazorWebApp.Client.Interfaces
{
    /// <summary>
    /// Project service.
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// Create.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="isFavourite">Is favourite.</param>
        Task Create(string name, bool isFavourite);
    }
}
