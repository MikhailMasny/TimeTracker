using Masny.TimeTracker.Data.Models;
using Masny.TimeTracker.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masny.TimeTracker.WebApi.Contracts.Responses
{
    public class AuthenticateResponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            FullName = user.FullName;
            Email = user.Email;
            Token = token;
        }
    }
}
