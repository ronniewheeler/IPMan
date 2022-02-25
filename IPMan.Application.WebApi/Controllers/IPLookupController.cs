using IPMan.Application.WebApi.Models;
using IPMan.Core.Entities.Geo;
using IPMan.Core.Entities.Ping;
using IPMan.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.NetworkInformation;

namespace IPMan.Application.WebApi.Controllers
{
    //Need to add authentication
    [ApiController]
    [Route("v1/iplookup")]
    public class IPLookupController : ControllerBase
    {
        private readonly IGeoIPService _geoIPService;
        private readonly IReverseDNSService _reverseDNSService;
        private readonly IHttpClientFactory _httpClientFactory;

        public IPLookupController(
            IHttpClientFactory httpClientFactory,
            IGeoIPService geoIPService,
            IReverseDNSService reverseDNSService
            )
        {
            _geoIPService = geoIPService;
            _reverseDNSService = reverseDNSService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{ip}", Name = "Get")]
        public async Task<IPLookupModel?> Get(string ip)
        {
            if (!IsValidIP(ip))
                throw new HttpRequestException("The IP Address is invalid.", null, HttpStatusCode.BadRequest);

            var geoIP = _geoIPService.GetLocationByIPAsync(ip);
            var ipDomain = _reverseDNSService.GetReverseDNSForIP(ip);
            var pingReply = GetPingResult(ip);

            await Task.WhenAll(geoIP, ipDomain, pingReply);

            var model = new IPLookupModel()
            {
                GeoIP = geoIP.Result ?? new GeoIP(),
                IPDomain = ipDomain.Result,
                PingReply = pingReply.Result
            };

            return model;
        }

        private static bool IsValidIP(string ip)
        {
            return IPAddress.TryParse(ip, out _);
        }

        private static async Task<PingResult?> GetPingResult(string ip)
        {
            var ping = await new Ping().SendPingAsync(ip);
            return new PingResult()
            {
                IPAddress = ip,
                RoundTripTime = ping.RoundtripTime,
                Success = ping.Status == IPStatus.Success
            };
        }
    }
}