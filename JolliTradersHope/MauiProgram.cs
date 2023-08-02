using CommunityToolkit.Maui;
using JolliTradersHope.Interfaces;
using JolliTradersHope.Pages;
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
        builder.Services.AddSingleton<ProductsService>();
        builder.Services.AddTransient<OffersService>();
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<HomePage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
