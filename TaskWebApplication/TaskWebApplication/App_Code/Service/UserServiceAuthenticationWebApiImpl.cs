using SharedLibraries.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace TaskWebApplication.Service
{
    public class UserServiceAuthenticationWebApiImpl : IAuthenticationService
    {
        public Boolean authenticateUser(User user)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9000/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync("api/Users", user).Result;  // Blocking call!
            Boolean authenticated;
            if (response.IsSuccessStatusCode)
            {
                authenticated = response.Content.ReadAsAsync<Boolean>().Result;
            }
            else
            {
                authenticated = false;
            }
            return authenticated;            
        }
    }
}