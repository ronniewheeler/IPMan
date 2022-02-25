using NUnit.Framework;
using Moq;
using IPMan.Core.Services;

namespace IPMan.Tests.Unit.GeoIP
{
    public class Tests
    {
        private IGeoIPService? _geoIPService;

        [SetUp]
        public void Setup()
        {
            SetupMockData();
        }

        [Test]
        public void GetLocationByIP_ReturnsGeoIP()
        {
            var geoIP = _geoIPService?.GetLocationByIPAsync("172.67.74.8").Result;
            Assert.IsNotNull(geoIP);
            Assert.IsInstanceOf<Core.Entities.Geo.GeoIP>(geoIP);
        }

        private void SetupMockData()
        {
            var mockGeoServie = new Mock<IGeoIPService>();
            mockGeoServie.Setup(x => x.GetLocationByIPAsync("172.67.74.8").Result)
                .Returns(MockGeoIP);

            _geoIPService = mockGeoServie.Object;
        }

        private static Core.Entities.Geo.GeoIP MockGeoIP => new()
        {
            Latitude = (double)22.488548596764645,
            Longitude = (double)114.1368804129255,
            IP = "172.67.74.8",
            IPType = "ipv4",
            Continent = "Asia",
            Country = "Hong Kong SAR China",
            Region = "Central and Western",
            City = "Fanling",
            Zip = null,
            Location = new Core.Entities.Geo.GeoLocation
            {
                Id = 1818209,
                Capital = "City of Victoria",
                Languages = null,
                CallingCode = "852"
            }
        };
    }
}