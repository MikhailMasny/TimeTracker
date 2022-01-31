using Masny.TimeTracker.Logic.Interfaces;
using Masny.TimeTracker.Logic.Models;
using Masny.TimeTracker.WebApi.Attributes;
using Masny.TimeTracker.WebApi.Contracts.Requests;
using Masny.TimeTracker.WebApi.Models;
using Masny.TimeTracker.WebApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Masny.TimeTracker.WebApi.Controllers
{
    [OwnAuthorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectManager _projectManager;

        public ProjectController(IProjectManager projectManger)
        {
            _projectManager = projectManger ?? throw new ArgumentNullException(nameof(projectManger));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var user = (UserModel)HttpContext.Items["User"];
            var projects = await _projectManager.GetAllByUserIdAsync(user.Id);

            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProjectCreateRequest request)
        {
            var project = new ProjectDto
            {
                UserId = ((UserModel)HttpContext.Items["User"]).Id,
                Name = request.Name,
                IsFavourite = request.IsFavourite,
            };

            await _projectManager.CreateAsync(project);

            // UNDONE: change it for Created
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ProjectUpdateRequest request)
        {
            var project = new ProjectDto
            {
                Id = id,
                UserId = ((UserModel)HttpContext.Items["User"]).Id,
                Name = request.Name,
                IsFavourite = request.IsFavourite,
                Type = request.Type
            };

            await _projectManager.UpdateAsync(project);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var user = (UserModel)HttpContext.Items["User"];
            await _projectManager.DeleteAsync(id, user.Id);

            return Ok();
        }
    }
}
