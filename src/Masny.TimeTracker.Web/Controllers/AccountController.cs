using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Masny.TimeTracker.Web.Interfaces;
using Masny.TimeTracker.WebApp.Shared.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Masny.TimeTracker.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityService _identityService;

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        /// <summary>
        /// Страница для входа в систему.
        /// </summary>
        /// <param name="returnUrl">Возврат по определенному адресу.</param>
        /// <returns>Определенное представление.</returns>
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            var viewModel = new UserLoginRequest();

            return View(viewModel);
        }

        /// <summary>
        /// Вход в систему.
        /// </summary>
        /// <param name="request">Модель пользовательских данных.</param>
        /// <returns>Определенное представление.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(UserLoginRequest request)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            if (ModelState.IsValid)
            {

                var token = await _identityService.LoginAsync(request);

                //var (result, message) = await _identityService.EmailConfirmCheckerAsync(request.UserName);

                //if (!result)
                //{
                //    ModelState.AddModelError(string.Empty, message);

                //    return View(request);
                //}

                //var isSignIn = await _identityService.LoginUserAsync(request.UserName, request.Password, request.*(RememberMe, true);

                //if (isSignIn.Succeeded)
                //{
                //    // Проверка на принадлежность URL приложению.
                //    if (!string.IsNullOrEmpty(request.ReturnUrl) && Url.IsLocalUrl(request.ReturnUrl))
                //    {
                //        return Redirect(request.ReturnUrl);
                //    }

                //    return RedirectToAction("Index", "Home");
                //}

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, token),
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }


            return View(request);
        }
    }
}
