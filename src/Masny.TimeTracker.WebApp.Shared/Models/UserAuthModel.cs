namespace Masny.TimeTracker.WebApp.Shared.Models
{
    /// <summary>
    /// User auth model.
    /// </summary>
    public class UserAuthModel
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Fullname.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Token.
        /// </summary>
        public string Token { get; set; }
    }
}
