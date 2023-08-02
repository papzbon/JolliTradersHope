using JolliTradersHope.Constants;
using JolliTradersHope.Models;
using JolliTradersHope.Shared.Dtos;
using System.Text.Json;

namespace JolliTradersHope.Services
{
    public class OffersService : BaseApiService
    {
        public OffersService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
        public async Task<IEnumerable<Offer>> GetActiveOffersAsync()
        {
            var response = await HttpClient.GetAsync("/masters/offers");
            return await HandleApiResponseAsync(response, Enumerable.Empty<Offer>());
        }
    }
}
