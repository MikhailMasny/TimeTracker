using Masny.TimeTracker.BlazorWebApp.Client.Interfaces;
using System;
using System.Threading.Tasks;

namespace Masny.TimeTracker.BlazorWebApp.Client.Services
{
    /// <inheritdoc cref="IRecordService"/>
    public class RecordService : IRecordService
    {
        private IHttpService _httpService;

        public RecordService(IHttpService httpService)
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
        }

        public async Task Create(int projectId, DateTime start, DateTime end)
        {
            await _httpService.PostDefault("/api/record", new { projectId, start, end });
        }
    }
}
