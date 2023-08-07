using JolliTradersHope.Models;
using JolliTradersHope.Repositories;
using JolliTradersHope.Services;

namespace JolliTradersHope.Pages;

public partial class LoginPage : ContentPage
{
    private readonly UserService _userService;

    public LoginPage()
    {
        InitializeComponent();
    }
    public LoginPage(UserService userService)
    {
        _userService = userService;
    }

    private async void Login_Btn_Clicked(object sender, EventArgs e)
    {
        //try
        //{
        //    string email = Entry_Email.Text;
        //    string password = Entry_Password.Text;
        //    if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        //    {
        //        await Shell.Current.DisplayAlert("Error", "All fields required", "Ok");
        //    }

        //    User user = await _userService.UserLogin(email, password);
        //    if (user == null)
        //    {
        //        await DisplayAlert("Error", "Credentials are incorrect", "Ok");
        //        return;
        //    }
        //    await Navigation.PushAsync(new MainPage());
        //    await DisplayAlert("Login", "Successfully logged in", "Ok");
        //}
        //catch (Exception ex)
        //{
        //    await DisplayAlert("Login", ex.Message, "Ok");
        //}
    }
}