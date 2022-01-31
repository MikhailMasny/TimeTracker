using Masny.TimeTracker.Logic.Models;
using System.Threading.Tasks;

namespace Masny.TimeTracker.Logic.Interfaces
{
    /// <summary>
    /// User manager.
    /// </summary>
    public interface IUserManager
    {
        ///// <summary>
        ///// Create user.
        ///// </summary>
        ///// <param name="model">User data transfer object.</param>
        //Task CreateAsync(UserDto model);

        ///// <summary>
        ///// Get user by identifier.
        ///// </summary>
        ///// <param name="id">Identifier.</param>
        ///// <returns>User data transfer object.</returns>
        //Task<UserDto> GetByIdAsync(int id);

        ///// <summary>
        ///// Update user by identifier.
        ///// </summary>
        ///// <param name="model">User data transfer object.</param>
        //Task UpdateAsync(UserDto model);

        //// UNDONE: split to manager and service
        //Task<(UserDto User, string Token)> Authenticate(string email, string password, string secret);
    }
}
