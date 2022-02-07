using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masny.TimeTracker.Web.Interfaces
{
    public interface IIdentityService
    {
        Task<string> LoginAsync(object value);
    }
}
