using Masny.TimeTracker.Web.Interfaces;
using Masny.TimeTracker.WebApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Masny.TimeTracker.Web.Service
{
    /// <inheritdoc cref="IProjectService"/>
    public class ProjectService : IProjectService
    {
        private readonly HttpClient _httpClient;

        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<ProjectItemResponse>> GetAllAsync(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/project");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var projects = await response.Content.ReadFromJsonAsync<List<ProjectItemResponse>>();
            return projects;
        }
    }
}
