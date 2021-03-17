using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using SentinelChain.Neth.SeniToken.ContractDefinition;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SentinelChain
{
    public class SeniTokenService
    {
        SentinelChainConfiguration _config;
        Account _account;
        string _contract;
        private static readonly NLog.ILogger _nlogger = NLog.LogManager.GetCurrentClassLogger();

        public SeniTokenService(SentinelChainConfiguration config, string contractAddress)
        {
            if (!config.Contracts.ContainsKey("senitoken"))
                throw new Exception("SeniToken contract address not configured.");
            _config = config;
            _account = new Account(config.PrivateKey);
            _contract = contractAddress;
        }

        public async Task<TransactionReceipt> MintSeni(string to, BigInteger amt)
        {
            var web3 = new Web3(_account, _config.Url);
            var handler = web3.Eth.GetContractTransactionHandler<MintFunction>();
            var result = await handler.SendRequestAndWaitForReceiptAsync(
                _contract,
                new MintFunction { To = to, Amount = amt }
                );
            return result;
        }

        public async Task<TransactionReceipt> SendSeni(string to, BigInteger amt)
        {
            var web3 = new Web3(_account, _config.Url);
            var handler = web3.Eth.GetContractTransactionHandler<TransferFunction>();
            var result = await handler.SendRequestAndWaitForReceiptAsync(
                _contract,
                new TransferFunction { Value = amt, To = to }
                );
            return result;
        }

        public async Task<BigInteger> CheckSeniBalance(string address)
        {
            var web3 = new Web3(_account, _config.Url);
            var handler = web3.Eth.GetContractQueryHandler<BalanceOfFunction>();
            var result = await handler.QueryDeserializingToObjectAsync<BalanceOfOutputDTO>(new BalanceOfFunction { Owner = address }, _contract);
            return result.ReturnValue1;
        }
    }
}
