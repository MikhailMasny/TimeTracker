using Masny.TimeTracker.Data.Models;
using Masny.TimeTracker.Logic.Interfaces;
using Masny.TimeTracker.WebApi.Attributes;
using Masny.TimeTracker.WebApi.Contracts.Requests;
using Masny.TimeTracker.WebApi.Contracts.Responses;
using Masny.TimeTracker.WebApi.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masny.TimeTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private IJwtService _jwtService;
        private readonly AppSettings _appSettings;

        public UserController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IJwtService jwtService,
            IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtService = jwtService;
            _appSettings = appSettings.Value;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticateRequest model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (!result.Succeeded)
            {
                return Forbid();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            // UNDONE: check result user

            var token = _jwtService.GenerateJwtToken(user.Id, _appSettings.Secret);

            if (token == string.Empty)
            {
                // UNDONE: change to 401 or 403
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            var response = new AuthenticateResponse(user, token);

            return Ok(response);
        }

        //[HttpPost("token")]
        //public async Task<IActionResult> GetTokenAsync()
        //{
        //    var result = await _signInManager.Authenticate("test@test.test", "qwerty123", _appSettings.Secret);

        //    if (result.Token == string.Empty)
        //    {
        //        // UNDONE: change to 401 or 403
        //        return BadRequest(new { message = "Username or password is incorrect" });
        //    }

        //    var response = new AuthenticateResponse(result.User, result.Token);

        //    return Ok(response);
        //}

        //// UNDONE: delete it
        //[OwnAuthorize]
        //[HttpGet]
        //public IActionResult Test()
        //{
        //    return Ok();
        //}
    }
}
