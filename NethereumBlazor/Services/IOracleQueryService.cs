using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicData;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using NethereumBlazor.Model;

namespace NethereumBlazor.Services
{
    public interface IOracleQueryService
    {
        Task<TransactionReceipt> SubmitOracleQuery(OracleQueryDto query);


    }
}
