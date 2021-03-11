using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SentinelChain.Neth.WhiteList.ContractDefinition
{
    [FunctionOutput]
    public class IsWhiteListedFunctionOutputDto : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }
}
