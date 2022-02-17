using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Masny.TimeTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public CacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        [HttpGet("withoutcache")]
        public IEnumerable<int> GetWithoutCache()
        {
            int[] numbers = new[] { 0, 1, 4, 6, 8, 2 };
            int[] shuffled = numbers.OrderBy(n => Guid.NewGuid()).ToArray();

            Response.ContentType = "text/json";
            return shuffled;
        }

        [HttpGet("withmemorycache")]
        public IEnumerable<int> GetWithMemoryCache(int id)
        {
            int[] shuffled;
            if (!_memoryCache.TryGetValue(id, out shuffled))
            {
                int[] numbers = new[] { 0, 1, 4, 6, 8, 2 };
                shuffled = numbers.OrderBy(n => Guid.NewGuid()).ToArray();
                if (shuffled.Any())
                {
                    _memoryCache.Set(id, shuffled,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
            }

            return shuffled;
        }

        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 300)]
        [HttpGet("withcache")]
        public IEnumerable<string> GetWithCache()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
