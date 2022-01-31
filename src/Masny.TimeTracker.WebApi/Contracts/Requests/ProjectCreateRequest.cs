namespace Masny.TimeTracker.WebApi.Contracts.Requests
{
    public class ProjectCreateRequest
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Is favourite.
        /// </summary>
        public bool IsFavourite { get; set; }
    }
}
