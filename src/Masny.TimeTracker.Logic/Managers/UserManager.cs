using Masny.TimeTracker.Data.Models;
using Masny.TimeTracker.Logic.Interfaces;
using Masny.TimeTracker.Logic.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Masny.TimeTracker.Logic.Managers
{
    /// <inheritdoc cref="IUserManager"/>
    public class UserManager : IUserManager
    {
        //private readonly IRepositoryManager<User> _userRepository;

        //public UserManager(IRepositoryManager<User> userRepository)
        //{
        //    _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        //}

        //public async Task CreateAsync(UserDto model)
        //{
        //    if (string.IsNullOrEmpty(model.FullName))
        //    {
        //        throw new ArgumentException($"'{nameof(model.FullName)}' cannot be null or empty.", nameof(model.FullName));
        //    }

        //    if (string.IsNullOrEmpty(model.Email))
        //    {
        //        throw new ArgumentException($"'{nameof(model.Email)}' cannot be null or empty.", nameof(model.Email));
        //    }

        //    if (string.IsNullOrEmpty(model.Password))
        //    {
        //        throw new ArgumentException($"'{nameof(model.Password)}' cannot be null or empty.", nameof(model.Password));
        //    }

        //    var user = new User
        //    {
        //        FullName = model.FullName,
        //        Email = model.Email,
        //        Password = model.Password,
        //        IsActive = true,
        //    };

        //    await _userRepository.CreateAsync(user);
        //    await _userRepository.SaveChangesAsync();
        //}

        //public async Task<UserDto> GetByIdAsync(int id)
        //{
        //    var user = await _userRepository.GetEntityWithoutTrackingAsync(u => u.Id == id);

        //    return user is null
        //        ? new UserDto()
        //        : new UserDto
        //        {
        //            Id = user.Id,
        //            FullName = user.FullName,
        //            Email = user.Email,
        //            Password = user.Password,
        //            IsActive = user.IsActive,
        //        };
        //}

        //public async Task UpdateAsync(UserDto model)
        //{
        //    model = model ?? throw new ArgumentNullException(nameof(model));

        //    var user = await _userRepository.GetEntityAsync(u => u.Id == model.Id);

        //    if (user is null)
        //    {
        //        throw new ArgumentException($"'{nameof(model.Id)}' user not found.", nameof(model.Id));
        //    }

        //    user.FullName = model.FullName;
        //    user.Email = model.Email;
        //    user.Password = model.Password;
        //    user.IsActive = model.IsActive;

        //    await _userRepository.SaveChangesAsync();
        //}

        //public async Task<(UserDto User, string Token)> Authenticate(string email, string password, string secret)
        //{
        //    var user = await _userRepository.GetEntityWithoutTrackingAsync(u =>
        //        u.Email == email && u.Password == password);

        //    if (user is null)
        //    {
        //        return (new UserDto(), string.Empty);
        //    }

        //    return (new UserDto
        //    {
        //        FullName = user.FullName,
        //        Email = user.Email,
        //        Password = user.Password,
        //        IsActive = user.IsActive,
        //    },
        //    GenerateJwtToken(user, secret));
        //}

        //private static string GenerateJwtToken(User user, string secret)
        //{
        //    // generate token that is valid for 7 days
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(
        //            new SymmetricSecurityKey(key),
        //            SecurityAlgorithms.HmacSha256Signature)
        //    };
            
        //    var token = tokenHandler.CreateToken(tokenDescriptor);

        //    return tokenHandler.WriteToken(token);
        //}
    }
}
