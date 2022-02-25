using System.Collections.Generic;

namespace IPMan.Core.Entities.ReverseDNS
{
    public class IPDomain
    {
        public string? IPAddress { get; set; }
        public int? DomainCount { get; set; }
        public string? DomainName { get; set; }
    }
}
