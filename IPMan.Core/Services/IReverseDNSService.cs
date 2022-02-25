using IPMan.Core.Entities.ReverseDNS;
using System.Threading.Tasks;

namespace IPMan.Core.Services
{
    public interface IReverseDNSService
    {
        public Task<IPDomain?> GetReverseDNSForIP(string ip);
    }
}
