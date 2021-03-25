using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Newtonsoft.Json;
using SentinelChain.Neth.EntrypointList.ContractDefinition;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SentinelChain
{
    public class EntrypointList : IEntrypointList
    {
        SentinelChainConfiguration _config;
        Account _account;
        string _contract;
        private static readonly NLog.ILogger _nlogger = NLog.LogManager.GetCurrentClassLogger();

        public EntrypointList(SentinelChainConfiguration config, string contractAddress)
        {
            if (!config.Contracts.ContainsKey("entrypointlist"))
                throw new Exception("EntrypointList contract address not configured.");
            _config = config;
            _account = new Account(config.PrivateKey);
            _contract = contractAddress;
        }

        public async Task<TransactionReceipt> AddEntryPointFunctionAsync(byte[] entryPoint)
        {
            var web3 = new Web3(_account, _config.Url);
            var handler = web3.Eth.GetContractTransactionHandler<AddEntryPointFunction>();

            var functionMsg = new AddEntryPointFunction
            {
                EntryPoint = entryPoint
            };

            _nlogger.Debug($"AddEntryPoint => SC:\n{JsonConvert.SerializeObject(functionMsg, Formatting.Indented)}");
            var receipt = await handler.SendRequestAndWaitForReceiptAsync(_contract, functionMsg);
            _nlogger.Debug($"txid <= SC: {receipt.TransactionHash}");

            return receipt;
        }

        public async Task<TransactionReceipt> EntryPointFunctionAsync(int id)
        {
            var web3 = new Web3(_account, _config.Url);
            var handler = web3.Eth.GetContractTransactionHandler<EntryPointFunction>();

            var functionMsg = new EntryPointFunction
            {
                Id = id
            };

            _nlogger.Debug($"EntryPoint => SC:\n{JsonConvert.SerializeObject(functionMsg, Formatting.Indented)}");
            var receipt = await handler.SendRequestAndWaitForReceiptAsync(_contract, functionMsg);
            _nlogger.Debug($"txid <= SC: {receipt.TransactionHash}");

            return receipt;
        }
    }
}
