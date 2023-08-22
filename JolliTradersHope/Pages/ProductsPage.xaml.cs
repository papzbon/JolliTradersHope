using JolliTradersHope.ViewModels;

namespace JolliTradersHope.Pages;

public partial class ProductsPage : ContentPage
{
    private readonly ProductPageViewModel _viewModel;

    public ProductsPage(ProductPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }

    private void AllProductsControl_AddRemoveCartClicked(object sender, Controls.AllProductsCartItemChangeEventArgs e)
    {
        if (e.Count > 0)
        {
            _viewModel.AddToCartCommand.Execute(e.ProductId);
        }
        else
        {
            _viewModel.RemoveFromCartCommand.Execute(e.ProductId);
        }
    }
}