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
    public class RecordController : ControllerBase
    {
        private IRecordManager _recordManager;

        public RecordController(IRecordManager recordManger)
        {
            _recordManager = recordManger ?? throw new ArgumentNullException(nameof(recordManger));
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetAsync(int projectId)
        {
            var user = (UserModel)HttpContext.Items["User"];
            var records = await _recordManager.GetAllByProjectIdAsync(projectId, user.Id);

            return Ok(records);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RecordCreateRequest request)
        {
            var user = (UserModel)HttpContext.Items["User"];

            var record = new RecordDto
            {
                ProjectId = request.ProjectId,
                Start = request.Start,
                End = request.End,
            };

            await _recordManager.CreateAsync(record, user.Id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] RecordUpdateRequest request)
        {
            var user = (UserModel)HttpContext.Items["User"];

            var record = new RecordDto
            {
                Id = id,
                Start = request.Start,
                End = request.End,
            };

            await _recordManager.UpdateAsync(record, user.Id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var user = (UserModel)HttpContext.Items["User"];
            await _recordManager.DeleteAsync(id, user.Id);

            return Ok();
        }
    }
}
