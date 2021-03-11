using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using SentinelChain.Neth.WhiteList.ContractDefinition;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SentinelChain
{
    public class WhiteListService
    {
        SentinelChainConfiguration _config;
        Account _account;
        string _contract;
        private static readonly NLog.ILogger _nlogger = NLog.LogManager.GetCurrentClassLogger();

        public WhiteListService(SentinelChainConfiguration config, string contractAddress)
        {
            if (!config.Contracts.ContainsKey("whitelist"))
                throw new Exception("Whitelist contract address not configured.");
            _config = config;
            _account = new Account(config.PrivateKey);
            _contract = contractAddress;
        }

        public async Task<bool> CheckWhiteListAddress(string address)
        {
            var web3 = new Web3(_account, _config.Url);
            var handler = web3.Eth.GetContractQueryHandler<IsWhiteListedFunction>();
            var result = await handler.QueryDeserializingToObjectAsync<IsWhiteListedFunctionOutputDto>(new IsWhiteListedFunction { Address = address }, _contract);
            return result.ReturnValue1;
        }

        public async Task<CountFunctionOutputDto> GetWhiteListedAddressesCount()
        {
            var web3 = new Web3(_account, _config.Url);
            var handler = web3.Eth.GetContractQueryHandler<CountFunction>();
            var result = await handler.QueryDeserializingToObjectAsync<CountFunctionOutputDto>(new CountFunction(), _contract);
            return result;
        }


        public async Task<TransactionReceipt> AddWhiteListAddress(string address)
        {
            var web3 = new Web3(_account, _config.Url);
            var handler = web3.Eth.GetContractTransactionHandler<AddWhiteListAddresses>();
            var receipt = await handler.SendRequestAndWaitForReceiptAsync(_contract, new AddWhiteListAddresses { Addresses = new string[] { address } });
            return receipt;
        }
    }
}
