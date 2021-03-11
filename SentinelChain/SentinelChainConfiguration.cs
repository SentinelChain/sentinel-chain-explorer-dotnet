using System;
using System.Collections.Generic;
using System.Text;

namespace SentinelChain
{
    public class SentinelChainConfiguration
    {
        public string Address { get; set; }
        public string PrivateKey { get; set; }
        public string Url { get; set; }
        public Dictionary<string, string> Contracts { get; set; }
        public SentinelChainConfiguration()
        {
            Contracts = new Dictionary<string, string>();
        }

    }
}
