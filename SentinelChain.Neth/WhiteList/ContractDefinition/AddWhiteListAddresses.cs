using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentinelChain.Neth.WhiteList.ContractDefinition
{
    [Function("addAddresses")]
    public class AddWhiteListAddresses : FunctionMessage
    {
        [Parameter("address[]", "_addresses", 1)]
        public virtual string[] Addresses { get; set; }
    }
}
