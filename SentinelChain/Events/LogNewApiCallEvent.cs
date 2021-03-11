using Nethereum.Hex.HexTypes;
using SentinelChain.Neth.FOSC.ContractDefinition;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentinelChain.Events
{
    public class LogNewApiCallEvent : LogNewAPICallEventDTOBase
    {
        public HexBigInteger BlockNo { get; set; }
        public string TxId { get; set; }
    }
}
