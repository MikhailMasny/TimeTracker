using Masny.TimeTracker.Data.Models;
using Masny.TimeTracker.WebApp.Shared.Models;
using System.Collections.Generic;

namespace Masny.TimeTracker.WebApi.Contracts.Responses
{
    /// <summary>
    /// User authenticate response.
    /// </summary>
    public class AuthenticateResponse : UserAuthModel
    {
        /// <summary>
        /// Constructor with params.
        /// </summary>
        /// <param name="user">User database model.</param>
        /// <param name="token">Jwt token.</param>
        public AuthenticateResponse(User user, string token, IList<string> roles)
        {
            Id = user.Id;
            FullName = user.FullName;
            Email = user.Email;
            Token = token;
            Roles = roles;
        }
    }
}
