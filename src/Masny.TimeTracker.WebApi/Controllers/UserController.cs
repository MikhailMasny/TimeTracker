using Masny.TimeTracker.Data.Models;
using Masny.TimeTracker.Logic.Interfaces;
using Masny.TimeTracker.WebApi.Contracts.Requests;
using Masny.TimeTracker.WebApi.Contracts.Responses;
using Masny.TimeTracker.WebApi.Settings;
using Masny.TimeTracker.WebApp.Shared.Models;
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
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));

            if (appSettings is null)
            {
                throw new ArgumentNullException(nameof(appSettings));
            }
            _appSettings = appSettings.Value;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserLoginRequest model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Email or password is incorrect" });
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            var token = _jwtService.GenerateJwtToken(user.Id, _appSettings.Secret);

            var response = new AuthenticateResponse(user, token);

            return Ok(response);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegistrationAsync(UserRegistationRequest request)
        {
            var user = new User
            {
                Email = request.Email,
                UserName = request.Email,
                FullName = request.FullName,
                IsActive = true,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                //foreach (var error in result.Errors)
                //{
                //    ModelState.AddModelError("errors", error.Description);
                //}

                //return BadRequest(ModelState);

                return BadRequest(new ErrorResponse<string>
                {
                    Message = "Can't registration new user.",
                    Errors = result.Errors.Select(error => error.Description)
                });
            }

            var token = _jwtService.GenerateJwtToken(user.Id, _appSettings.Secret);

            var response = new AuthenticateResponse(user, token);

            return Ok(response);
        }

        // UNDONE: DELETE IT
        [HttpPost("test")]
        public async Task<IActionResult> TestAsync()
        {
            var email = "test@test.test";
            var user = await _userManager.FindByEmailAsync(email);
            var token = _jwtService.GenerateJwtToken(user.Id, _appSettings.Secret);

            var response = new AuthenticateResponse(user, token);

            return Ok(response);
        }
    }
}
