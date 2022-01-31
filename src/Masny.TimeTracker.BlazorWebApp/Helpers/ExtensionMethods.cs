using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Specialized;
using System.Web;

namespace Masny.TimeTracker.BlazorWebApp.Client.Helpers
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// QueryString.
        /// </summary>
        /// <param name="navigationManager">Navigation manager.</param>
        /// <returns>Collection.</returns>
        public static NameValueCollection QueryString(this NavigationManager navigationManager)
        {
            return HttpUtility.ParseQueryString(new Uri(navigationManager.Uri).Query);
        }

        /// <summary>
        /// QueryString
        /// </summary>
        /// <param name="navigationManager">Navigation manager.</param>
        /// <param name="key">Key.</param>
        /// <returns>Collection.</returns>
        public static string QueryString(this NavigationManager navigationManager, string key)
        {
            return navigationManager.QueryString()[key];
        }
    }
}
