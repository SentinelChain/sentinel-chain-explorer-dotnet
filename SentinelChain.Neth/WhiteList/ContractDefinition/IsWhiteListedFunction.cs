using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentinelChain.Neth.WhiteList.ContractDefinition
{
    [Function("isWhitelisted")]
    public class IsWhiteListedFunction : FunctionMessage
    {
        [Parameter("address", "addr", 1)]
        public virtual string Address { get; set; }

    }
}
