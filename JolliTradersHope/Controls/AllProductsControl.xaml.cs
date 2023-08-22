using CommunityToolkit.Mvvm.Input;
using JolliTradersHope.Shared.Dtos;

namespace JolliTradersHope.Controls;

public class AllProductsCartItemChangeEventArgs : EventArgs
{
    public int ProductId { get; set; }
    public int Count { get; set; }
    public AllProductsCartItemChangeEventArgs(int productId, int count)
    {
        ProductId = productId;
        Count = count;
    }
}

public partial class AllProductsControl : ContentView
{
    public static readonly BindableProperty AllProductsProperty = 
        BindableProperty.Create(nameof(AllProducts), typeof(IEnumerable<ProductDto>), typeof(AllProductsControl), Enumerable.Empty<ProductDto>());
	public AllProductsControl()
	{
		InitializeComponent();
	}
    public event EventHandler<AllProductsCartItemChangeEventArgs> AddRemoveCartClicked;
    public IEnumerable<ProductDto> AllProducts
    { 
        get => (IEnumerable<ProductDto>)GetValue(AllProductsProperty);
        set => SetValue(AllProductsProperty, value); 
    }
    [RelayCommand]
    private void AddToCart(int productId) =>
        AddRemoveCartClicked?.Invoke(this, new AllProductsCartItemChangeEventArgs(productId, 1));

    [RelayCommand]
    private void RemoveFromCart(int productId) =>
        AddRemoveCartClicked?.Invoke(this, new AllProductsCartItemChangeEventArgs((int)productId, -1));
}