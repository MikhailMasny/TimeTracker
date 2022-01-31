using System.ComponentModel.DataAnnotations;

namespace Masny.TimeTracker.WebApp.Shared.Models
{
    /// <summary>
    /// Project create operation request.
    /// </summary>
    public class ProjectCreateRequest
    {
        /// <summary>
        /// Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Is favourite.
        /// </summary>
        public bool IsFavourite { get; set; }
    }
}
