using JolliTradersHope.Interfaces;
using Security;

namespace JolliTradersHope.Platforms.iOS
{
    class IosHttpMessageHandler : IPlatformHttpMessageHandler
    {
        public HttpMessageHandler GetHttpMessageHandler() =>
           new NSUrlSessionHandler
           {
               TrustOverrideForUrl = (NSUrlSessionHandler sender, string url, SecTrust trust) => url.StartsWith("https://localhost")
           };
    }
}
