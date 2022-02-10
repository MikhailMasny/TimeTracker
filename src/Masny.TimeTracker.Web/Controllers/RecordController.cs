using Masny.TimeTracker.Web.Interfaces;
using Masny.TimeTracker.WebApp.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Masny.TimeTracker.Web.Controllers
{
    /// <summary>
    /// Record controller.
    /// </summary>
    [Authorize]
    public class RecordController : Controller
    {
        private readonly IRecordService _recordService;
        private readonly IProjectService _projectService;

        /// <summary>
        /// Controller with params
        /// </summary>
        /// <param name="recordService">Record service.</param>
        /// <param name="projectService">Project service.</param>
        public RecordController(
            IRecordService recordService,
            IProjectService projectService)
        {
            _recordService = recordService ?? throw new ArgumentNullException(nameof(recordService));
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        }

        /// <summary>
        /// Send (Get).
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> SendAsync()
        {
            var token = User.FindFirst(ClaimTypes.Name).Value;
            var projects = await _projectService.GetAllAsync(token);

            SelectList projectList = new SelectList(projects, "Id", "Name");
            ViewBag.Projects = projectList;

            return View();
        }

        /// <summary>
        /// Send (Post).
        /// </summary>
        /// <param name="request">Record create request.</param>
        [HttpPost]
        public async Task<IActionResult> SendAsync(RecordCreateRequest request)
        {
            var token = User.FindFirst(ClaimTypes.Name).Value;

            await _recordService.AddAsync(request, token);

            return RedirectToAction("Index", "Home");
        }
    }
}
