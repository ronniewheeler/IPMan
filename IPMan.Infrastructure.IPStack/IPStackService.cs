using IPMan.Core.Entities.Geo;
using IPMan.Core.Services;
using Newtonsoft.Json;

namespace IPMan.Infrastructure.IPStack
{
    public class IPStackService : IGeoIPService
    {
        private readonly HttpClient _httpClient = new();
        private readonly Uri _baseUri;
        private readonly string _apiKey;

        public IPStackService(
            Uri baseUri,
            string apiKey)
        {
            _baseUri = baseUri;
            _apiKey = apiKey;
            _httpClient.BaseAddress = _baseUri;
        }

        public async Task<GeoIP?> GetLocationByIPAsync(string ip)
        {
            GeoIP? geoIP = null;
            try
            {
                var uri = $"/{ip}?access_key={_apiKey}";
                var requestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    uri);

                var response = await _httpClient.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var textReader = new StreamReader(responseStream);
                    geoIP = JsonConvert.DeserializeObject<GeoIP>(textReader.ReadToEnd());
                }
            }
            catch (Exception)
            {
                //TODO: Error logging
            }

            return geoIP;
        }
    }
}