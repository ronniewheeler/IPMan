using IPMan.Core.Entities.Geo;
using System.Threading.Tasks;

namespace IPMan.Core.Services
{
    public interface IGeoIPService
    {
        public Task<GeoIP?> GetLocationByIPAsync(string ip);
    }
}
