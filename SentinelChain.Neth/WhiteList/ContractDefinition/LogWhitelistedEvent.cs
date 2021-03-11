using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentinelChain.Neth.WhiteList.ContractDefinition
{
    [Event("LogWhitelisted")]
    public class LogWhiteListedEvent : IEventDTO
    {
        [Parameter("address", "addr", 1, true)]
        public virtual string Addr { get; set; }
    }
}
