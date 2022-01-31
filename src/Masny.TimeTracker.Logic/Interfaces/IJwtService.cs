using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masny.TimeTracker.Logic.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(string userId, string secret);
    }
}
