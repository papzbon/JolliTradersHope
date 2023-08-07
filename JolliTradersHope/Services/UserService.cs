using JolliTradersHope.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JolliTradersHope.Services
{
    public class UserService : BaseApiService
    {
        public UserService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
        public async ValueTask<IEnumerable<User>> GetUsers()
        {
            var response = await HttpClient.GetAsync("/masters/users");
            return await HandleApiResponseAsync(response, Enumerable.Empty<User>());
        }

        public async ValueTask<IEnumerable<User>> GetUserLogin(string email, string password) =>
            (await GetUsers())
            .Where(u => u.Email == email && u.Password == password);
    }
}
