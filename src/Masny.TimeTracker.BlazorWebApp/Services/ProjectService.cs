using Masny.TimeTracker.BlazorWebApp.Client.Interfaces;
using System;
using System.Threading.Tasks;

namespace Masny.TimeTracker.BlazorWebApp.Client.Services
{
    /// <inheritdoc cref="IProjectService"/>
    public class ProjectService : IProjectService
    {
        private IHttpService _httpService;

        public ProjectService(IHttpService httpService)
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
        }

        public async Task Create(string name, bool isFavourite)
        {
            await _httpService.PostDefault("/api/project", new { name, isFavourite });
        }
    }
}
