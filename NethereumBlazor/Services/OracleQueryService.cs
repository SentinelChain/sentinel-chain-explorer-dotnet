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
        private GanacheService ganacheService;
        private string senitokenContract;
        private string rpcUrl;

        public OracleQueryService(IFoscService foscService,IConfiguration configuration,GanacheService ganacheService)
        {
           
            this.foscService = foscService;
            this.ganacheService = ganacheService;
            //_web3ProviderService = web3ProviderService;
            senitokenContract = configuration.GetValue<string>("SeniTokenContractAddress");
            rpcUrl = configuration.GetValue<string>("Url");
        }

        public async Task<TransactionReceipt> SubmitOracleQuery(OracleQueryDto query)
        {
            try
            {
                //byte[] bytes = Encoding.ASCII.GetBytes(query.Parameters);
                ////var bytes = EncodeHelper.UTF82Bytes(query.Parameters);
                //var result = await seniTokenService.TransferAndCallQuery(BigInteger.Parse(query.Amount), bytes);
                //Console.WriteLine("Oracle Result: " + JsonConvert.SerializeObject(result));

                var seniConfig = await ganacheService.InitializeProcess();
                var fosc = new FoscService(seniConfig, seniConfig.Contracts["fosc"]);

                var result = await fosc.CallAndTransferGetLivestockInfo(senitokenContract, query.Parameters, BigInteger.Parse(query.Amount));
                var addr = seniConfig.Contracts["senitoken"];
                var result_ = await fosc.CallAndTransferGetLivestockInfo(addr, query.Parameters, BigInteger.Parse(query.Amount));
                var log = result_.Logs[2];
                var callerId = log["topics"][1];
                var callId = BigInteger.Parse(log["topics"][2].ToString().Remove(0, 2), System.Globalization.NumberStyles.HexNumber);

                //var result = await foscService.CallAndTransferGetLivestockInfo(senitokenContract, query.Parameters, BigInteger.Parse(query.Amount));

                return result_;
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }


    }


}
