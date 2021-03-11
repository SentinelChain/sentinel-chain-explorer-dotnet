using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentinelChain.Neth.WhiteList.ContractDefinition
{
    [Function("list", "mapping(address => bool)")]
    public class ListStateVariable : FunctionMessage
    {
    }
}
