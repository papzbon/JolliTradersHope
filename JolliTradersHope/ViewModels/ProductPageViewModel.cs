using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JolliTradersHope.Models;
using JolliTradersHope.Services;
using JolliTradersHope.Shared.Dtos;
using System.Collections.ObjectModel;

namespace JolliTradersHope.ViewModels
{
    public partial class ProductPageViewModel : ObservableObject
    {
        private readonly CategoryService _categoryService;
        private readonly ProductsService _productsService;
        private readonly CartViewModel _cartViewModel;

        public ProductPageViewModel(CategoryService categoryService,
                                    ProductsService productsService,
                                    CartViewModel cartViewModel)
        {
            _categoryService = categoryService;
            _productsService = productsService;
            _cartViewModel = cartViewModel;
        }

        public ObservableCollection<Category> Categories { get; set; } = new();
        public ObservableCollection<ProductDto> PopularProducts { get; set; } = new();

        [ObservableProperty] private bool _isBusy = true;
        [ObservableProperty] private int _cartCount;

        public async Task InitializeAsync()
        {
            try
            {
                var popularProductsTask = _productsService.GetPopularProductsAsync();
                foreach (var category in await _categoryService.GetMainCategoriesAsync())
                {
                    Categories.Add(category);
                }
                foreach (var popularProduct in await popularProductsTask)
                {
                    PopularProducts.Add(popularProduct);
                }

            }
            finally
            {

            }
            IsBusy = false;
        }
        [RelayCommand] private void AddToCart(int productId) => UpdateCart(productId, 1);

        [RelayCommand] private void RemoveFromCart(int productId) => UpdateCart(productId, -1);
        private void UpdateCart(int productId, int count)
        {
            var product = PopularProducts.FirstOrDefault(p => p.Id == productId);
            if (product is not null)
            {
                product.CartQuantity += count;

                if (count == -1)
                {
                    //we are removing from cart
                    _cartViewModel.RemoveFromCartCommand.Execute(product.Id);
                }
                else
                {
                    _cartViewModel.AddToCartCommand.Execute(product);
                }
                CartCount = _cartViewModel.Count;
            }
        }
    }
}
