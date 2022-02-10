using Masny.TimeTracker.Core.Enums;
using Masny.TimeTracker.Data.Enums;

namespace Masny.TimeTracker.WebApi.Contracts.Requests
{
    /// <summary>
    /// Project update operation request.
    /// </summary>
    public class ProjectUpdateRequest
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Is favourite.
        /// </summary>
        public bool IsFavourite { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public ProjectType Type { get; set; }
    }
}
