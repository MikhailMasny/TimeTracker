using Masny.TimeTracker.BlazorWebApp.Client.Interfaces;
using Masny.TimeTracker.WebApp.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Masny.TimeTracker.BlazorWebApp.Client.Services
{
    /// <inheritdoc cref="IAuthenticationService"/>
    public class AuthenticationService : IAuthenticationService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public UserAuthModel User { get; private set; }

        public AuthenticationService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        )
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
            _localStorageService = localStorageService ?? throw new ArgumentNullException(nameof(localStorageService));
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<UserAuthModel>("user");
        }

        public async Task Login(string email, string password)
        {
            User = await _httpService.Post<UserAuthModel>("/api/user/login", new { email, password });
            await _localStorageService.SetItem("user", User);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem("user");
            _navigationManager.NavigateTo("login");
        }
    }
}
