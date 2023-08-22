using JolliTradersHope.ViewModels;

namespace JolliTradersHope.Pages;

public partial class CartPage : ContentPage
{
    private readonly CartViewModel _cartViewModel;

    public CartPage(CartViewModel cartViewModel)
	{
		InitializeComponent();
        _cartViewModel = cartViewModel;

        BindingContext = _cartViewModel;
    }
}