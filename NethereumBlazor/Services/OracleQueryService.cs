//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
//using System.Runtime.InteropServices;
//using System.Threading.Tasks;
//using DynamicData;
//using Microsoft.Extensions.Primitives;
//using Microsoft.JSInterop;
//using Nethereum.ABI.FunctionEncoding.Attributes;
//using Nethereum.Contracts;
//using Nethereum.RPC.Eth.DTOs;
//using Nethereum.Web3;
//using Nethereum.Web3.Accounts;
//using NethereumBlazor.Messages;
//using FarmTrekv2.Common.Utils.Lib.Helpers;
using Nethereum.RPC.Eth.DTOs;
using NethereumBlazor.Model;
using Newtonsoft.Json;
using SentinelChain;
using System;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
//using ReactiveUI;

namespace NethereumBlazor.Services
{
    public class OracleQueryService : IOracleQueryService
    {
        private readonly IWeb3ProviderService _web3ProviderService;
        private readonly SeniTokenService seniTokenService;

        public OracleQueryService(IWeb3ProviderService web3ProviderService,SeniTokenService seniTokenService)
        {
            _web3ProviderService = web3ProviderService;
            this.seniTokenService = seniTokenService;
        }

        public async Task<TransactionReceipt> SubmitOracleQuery(OracleQueryDto query)
        {
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(query.Parameters);
                //var bytes = EncodeHelper.UTF82Bytes(query.Parameters);
                var result = await seniTokenService.TransferAndCallQuery(BigInteger.Parse(query.Amount), bytes);
                Console.WriteLine("Oracle Result: " + JsonConvert.SerializeObject(result));
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

    }

   
}
