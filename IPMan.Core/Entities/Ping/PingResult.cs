using System;
using System.Collections.Generic;
using System.Text;

namespace IPMan.Core.Entities.Ping
{
    public class PingResult
    {
        public string? IPAddress { get; set; }
        public bool? Success { get; set; }
        public long? RoundTripTime { get; set; }
    }
}
