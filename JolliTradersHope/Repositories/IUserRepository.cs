using JolliTradersHope.Models;

namespace JolliTradersHope.Repositories
{
    public interface IUserRepository
    {
        Task<User> UserLogin(string email, string password);
    }
}
