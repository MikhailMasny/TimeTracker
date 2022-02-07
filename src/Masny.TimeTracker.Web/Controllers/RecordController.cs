using Masny.TimeTracker.Web.Interfaces;
using Masny.TimeTracker.WebApp.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Masny.TimeTracker.Web.Controllers
{
    [Authorize]
    public class RecordController : Controller
    {
        private readonly IRecordService _recordService;

        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet]
        public IActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendAsync(RecordCreateRequest request)
        {
            var token = User.FindFirst(ClaimTypes.Name).Value;

            await _recordService.SendAsync(request, token);

            return View();
        }
    }
}
