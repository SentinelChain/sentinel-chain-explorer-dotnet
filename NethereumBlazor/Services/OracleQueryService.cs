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
using Microsoft.Extensions.Configuration;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using NethereumBlazor.Model;
using Newtonsoft.Json;
using SentinelChain;
using SentinelChain.Neth.FOSC.ContractDefinition;
using SentinelChain.Neth.SeniToken.ContractDefinition;
using SentinelChain.Neth.WhiteList.ContractDefinition;
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
        private readonly IFoscService foscService;
        private string senitokenContract;
        private string rpcUrl;

        public OracleQueryService(IFoscService foscService, IConfiguration configuration)
        {

            this.foscService = foscService;
            //_web3ProviderService = web3ProviderService;
            senitokenContract = configuration.GetValue<string>("SeniTokenContractAddress");
            rpcUrl = configuration.GetValue<string>("Url");
        }

        public async Task<TransferAndCallOutput> SubmitOracleQuery(OracleQueryDto query)
        {
            try
            {
                TransferAndCallDataInput transferAndCallDataInput;
                transferAndCallDataInput.serialNo = query.Parameters;
                transferAndCallDataInput.entryPointId = query.EntryPointId;

                var result = await foscService.CallAndTransferGetLivestockInfo(senitokenContract,
                    transferAndCallDataInput, BigInteger.Parse(query.Amount));
                var log = result.Logs[2];
                var callerId = log["topics"][1];
                var callId = BigInteger.Parse(log["topics"][2].ToString().Remove(0, 2), System.Globalization.NumberStyles.HexNumber);

                TransferAndCallOutput transferAndCallOutput = new TransferAndCallOutput
                {
                    TransactionHash = result.TransactionHash,
                    CallId = callId
                };

                return transferAndCallOutput;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
