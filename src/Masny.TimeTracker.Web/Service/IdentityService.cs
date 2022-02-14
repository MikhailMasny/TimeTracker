using Masny.TimeTracker.Web.Interfaces;
using Masny.TimeTracker.WebApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Masny.TimeTracker.Web.Service
{
    /// <inheritdoc cref="IIdentityService"/>
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;

        public IdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<(string token, IList<string> roles)> LoginAsync(object value)
        {
            //using (var client = new HttpClient())
            //{
            //    //Passing service base url
            //    client.BaseAddress = new Uri(Baseurl);
            //    client.DefaultRequestHeaders.Clear();
            //    //Define request data format
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
            //    HttpResponseMessage Res = await client.GetAsync("api/user/login");
            //    //Checking the response is successful or not which is sent using HttpClient
            //    if (Res.IsSuccessStatusCode)
            //    {
            //        //Storing the response details recieved from web api
            //        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
            //        //Deserializing the response recieved from web api and storing into the Employee list
            //        EmpInfo = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse);
            //    }
            //    //returning the employee list to view
            //    return View(EmpInfo);
            //}

            var request = new HttpRequestMessage(HttpMethod.Post, "api/user/login");
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");

            using var response = await _httpClient.SendAsync(request);

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var record = await response.Content.ReadFromJsonAsync<UserAuthModel>();
            return (record.Token, record.Roles);
        }
    }
}
