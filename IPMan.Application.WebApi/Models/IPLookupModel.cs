using IPMan.Core.Entities.Geo;
using IPMan.Core.Entities.Ping;
using IPMan.Core.Entities.ReverseDNS;

namespace IPMan.Application.WebApi.Models
{
    public class IPLookupModel
    {
        public IPLookupModel()
        { 
        }

        public GeoIP? GeoIP { get; set; }
        public IPDomain? IPDomain { get; set; }
        public PingResult? PingReply { get; set; }
    }
}
