using Nethereum.RPC.Eth.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SentinelChain
{
    public interface IEntrypointList
    {
        Task<TransactionReceipt> AddEntryPointFunctionAsync(byte[] entryPoint);

        Task<TransactionReceipt> EntryPointFunctionAsync(int id);
    }
}
