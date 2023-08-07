using JolliTradersHope.Models;
using JolliTradersHope.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JolliTradersHope.Repositories
{
    public class UserRepository : IUserRepository
    {
        //public UserRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        //{
        //}
        //private IEnumerable<User> _users;
        //public async ValueTask<IEnumerable<User>>UserLogin(string email, string password)
        //{
        //    if(_users is null)
        //    {
        //        var response = await HttpClient.GetAsync($"/users/{email}/{password}");
        //        var users = await HandleApiResponseAsync<IEnumerable<User>>(response, null);

        //        if(users is null)
        //            return Enumerable.Empty<User>();

        //        _users = users;
        //    }
        //    return _users;
        //}
        public async Task<User> UserLogin(string email, string password)
        {
            var client = new HttpClient();
            string url = "https://10.0.2.2:12345/users/" + email + "/" + password;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                User user = JsonConvert.DeserializeObject<User>(content);
                return await Task.FromResult(user);
            }
            return null;
        }
    }
}
