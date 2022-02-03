﻿namespace Masny.TimeTracker.Logic.Interfaces
{
    /// <summary>
    /// JWT service.
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        /// Generate Jwt Token.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="secret">Secret key.</param>
        string GenerateJwtToken(string userId, string secret);
    }
}
