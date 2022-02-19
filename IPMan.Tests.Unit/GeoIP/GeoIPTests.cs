using IPMan.Core;
using NUnit.Framework;
using Moq;

namespace IPMan.Tests.Unit.GeoIP
{
    public class Tests
    {
        private readonly IGeoIPService _geoIPService;

        [SetUp]
        public void Setup()
        {
            SetupMockData();
        }

        [Test]
        public void GetLocationByIP_ReturnsGeoIP()
        {
            var geoIP = _geoIPService.GetLocationByIP("172.67.74.8");
            Assert.IsNotNull(geoIP);
            Assert.IsInstanceOf<GetIP>(geoIP);
        }

        private void SetupMockData()
        {
            _geoIPService = new Mock<IGeoIPService>();
            _geoIPService.Setup(x => x.GetLocationByIP())
                .Returns(MockGeoIP);
        }

        private const GeoIP MockGeoIP = new GeoIP
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
            Location = new GetLocation
            {
                Id = 1818209,
                Capital = "City of Victoria",
                Languages = new List<Language>(),
                CallingCode = "852"
            }
        };
    }
}