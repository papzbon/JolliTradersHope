using CommunityToolkit.Mvvm.ComponentModel;
using JolliTradersHope.Models;
using JolliTradersHope.Services;
using System.Collections.ObjectModel;

namespace JolliTradersHope.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        private readonly UserService _userService;

        public LoginPageViewModel(UserService userService)
        {
            _userService = userService;
        }
        public ObservableCollection<User> Users { get; set; }

        public async Task InitializeAsync()
        {

        }
    }
}
