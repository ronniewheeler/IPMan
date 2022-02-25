using IPMan.Core.Entities.ReverseDNS;
using IPMan.Core.Services;
using System.Net;

namespace IPMan.Infrastructure.DomainTools
{
    public class DomainToolsService : IReverseDNSService
    {
        private readonly HttpClient _httpClient = new();
        private const string DomainToolsDomain = "https://api.domaintools.com/";

        public DomainToolsService()
        { 
            _httpClient.BaseAddress = new Uri(DomainToolsDomain);
        }

        public async Task<IPDomain?> GetReverseDNSForIP(string ip)
        {
            IPDomain? result = null;
            try
            {
                var tmp = await Dns.GetHostEntryAsync(ip);
                result = new IPDomain()
                {
                    IPAddress = ip,
                    DomainName = tmp.HostName,
                    DomainCount = 1
                };
            }
            catch (Exception)
            {
                //TODO: Error Logging
            }

            return result;

            /**************
             * Need to pay for API access for DomainTools
             *************
            IPDomain? ipDomain = new();
            var uri = $"v1/{ip}/host-domains";
            var requestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                uri);

            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var textReader = new StreamReader(responseStream);
                ipDomain = JsonConvert.DeserializeObject<IPDomain>(textReader.ReadToEnd());
            }
            ***********/
        }
    }
}