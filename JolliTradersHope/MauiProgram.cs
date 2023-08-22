using CommunityToolkit.Maui;
using JolliTradersHope.Interfaces;
using JolliTradersHope.Pages;
using JolliTradersHope.Repositories;
using JolliTradersHope.Services;
using JolliTradersHope.ViewModels;
using Microsoft.Extensions.Logging;

namespace JolliTradersHope;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa_solid.ttf", "FontAwesome");
            });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
            if (view is BorderlessEntry)
            {
#if ANDROID
                handler.PlatformView.Background = null;
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
			handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
#endif
            }
        });


        builder.Services.AddSingleton<IPlatformHttpMessageHandler>(sp =>
        {
#if ANDROID
            return new Platforms.Android.AndroidHttpMessageHandler();
#elif IOS
			return new Platforms.iOS.IosHttpMessageHandler();
#endif
            return null;
        });

        builder.Services.AddHttpClient(Constants.AppConstants.HttpClientName, httpClient =>
        {
            var baseAddress = DeviceInfo.Platform == DevicePlatform.Android
                                ? "https://10.0.2.2:12345"
                                : "https://localhost:12345";
            httpClient.BaseAddress = new Uri(baseAddress);
        })
            .ConfigureHttpMessageHandlerBuilder(configBuilder =>
        {
            var platformHttpMessageHandler = configBuilder.Services.GetRequiredService<IPlatformHttpMessageHandler>();
            configBuilder.PrimaryHandler = platformHttpMessageHandler.GetHttpMessageHandler();
        });

        
        builder.Services.AddSingleton<CategoryService>();
        builder.Services.AddSingleton<IUserRepository, UserRepository>();
        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<ProductsService>();
        builder.Services.AddSingleton<ProductPageViewModel>();
        builder.Services.AddTransient<OffersService>();
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<ProductsPage>();

        builder.Services.AddSingleton<CartViewModel>();
        builder.Services.AddTransient<CartPage>();
        

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
