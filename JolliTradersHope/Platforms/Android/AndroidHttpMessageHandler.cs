using JolliTradersHope.Interfaces;
using System.Net.Security;
using Xamarin.Android.Net;

namespace JolliTradersHope.Platforms.Android
{
    class AndroidHttpMessageHandler : IPlatformHttpMessageHandler
    {
        public HttpMessageHandler GetHttpMessageHandler() =>
            new AndroidMessageHandler
            {
                ServerCertificateCustomValidationCallback = (HttpRequestMessage, certificate, chain, sslPolicyErrors) =>
                    certificate?.Issuer == "CN=localhost" || sslPolicyErrors == SslPolicyErrors.None
            };
    }
}
