using Masny.TimeTracker.Web.Interfaces;
using Masny.TimeTracker.WebApp.Shared.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Masny.TimeTracker.Web.Controllers
{
    /// <summary>
    /// Account controller.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly IIdentityService _identityService;

        /// <summary>
        /// Constructor with params.
        /// </summary>
        /// <param name="identityService">Identity service.</param>
        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        /// <summary>
        /// Login (Get).
        /// </summary>
        [HttpGet]
        public IActionResult Login()
        {
            var viewModel = new UserLoginRequest();

            return View(viewModel);
        }

        /// <summary>
        /// Login (Post).
        /// </summary>
        /// <param name="request">User login request.</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(UserLoginRequest request)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            if (ModelState.IsValid)
            {
                var (token, roles) = await _identityService.LoginAsync(request);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, token),
                };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }

            // UNDONE: ModelError

            return View(request);
        }
    }
}
