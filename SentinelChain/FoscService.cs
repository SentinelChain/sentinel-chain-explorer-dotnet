using FarmTrekv2.Common.Utils.Lib.Helpers;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Newtonsoft.Json;
using Pastel;
using SentinelChain.Neth.FOSC.ContractDefinition;
using SentinelChain.Neth.SeniToken.ContractDefinition;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SentinelChain
{
    public class FoscService : IFoscService
    {
        SentinelChainConfiguration _config;
        Account _account;
        string _contract;
        private static readonly NLog.ILogger _nlogger = NLog.LogManager.GetCurrentClassLogger();

        public FoscService(SentinelChainConfiguration config, string contractAddress)
        {
            if (!config.Contracts.ContainsKey("fosc"))
                throw new Exception("FOSC contract address not configured.");
            _config = config;
            _account = new Account(config.PrivateKey);
            _contract = contractAddress;
        }

        public async Task<List<EventLog<LogNewAPICallEventDTO>>> ListAllLogNewAPICallEvents()
        {
            var web3 = new Web3(_config.Url);
            var eventhandler = web3.Eth.GetEvent<LogNewAPICallEventDTO>(_contract);
            var filter = eventhandler.CreateFilterInput();
            return await eventhandler.GetAllChanges(filter);
        }

        public async Task<HexBigInteger> GetLatestLogNewAPICallEventsFilter()
        {
            try
            {
                var web3 = new Web3(_config.Url);
                var eventhandler = web3.Eth.GetEvent<LogNewAPICallEventDTO>(_contract);
                var filter = eventhandler.CreateFilterInput();
                return await eventhandler.CreateFilterAsync(filter);
            }
            catch (Exception ex)
            {
                _nlogger.Error(ex.ToString());
                throw;
            }

        }

        public async Task<List<EventLog<LogNewAPICallEventDTO>>> ListLatestLogNewAPICallEvents(HexBigInteger filterId)
        {
            try
            {
                var web3 = new Web3(_config.Url);
                var eventhandler = web3.Eth.GetEvent<LogNewAPICallEventDTO>(_contract);
                var result = await eventhandler.GetFilterChanges(filterId);
                return result;
            }
            catch (Exception ex)
            {
                _nlogger.Error(ex.ToString());
                throw;
            }
        }

        public async Task<HexBigInteger> GetLatestLogCallFinishedEventsFilter()
        {
            try
            {
                var web3 = new Web3(_config.Url);
                var eventhandler = web3.Eth.GetEvent<LogCallFinishedEventDTO>(_contract);
                var filter = eventhandler.CreateFilterInput();
                return await eventhandler.CreateFilterAsync(filter);
            }
            catch (Exception ex)
            {
                _nlogger.Error(ex.ToString());
                throw;
            }
        }

        public async Task<List<EventLog<LogCallFinishedEventDTO>>> ListLatestLogCallFinishedEvents(HexBigInteger filterId)
        {
            try
            {
                var web3 = new Web3(_config.Url);
                var eventhandler = web3.Eth.GetEvent<LogCallFinishedEventDTO>(_contract);
                var result = await eventhandler.GetFilterChanges(filterId);
                return result;
            }
            catch (Exception ex)
            {
                _nlogger.Error(ex.ToString());
                throw;
            }
        }


        public async Task<List<EventLog<LogCallFinishedEventDTO>>> ListAllLogCallFinishedEvents()
        {
            var web3 = new Web3(_config.Url);
            var eventhandler = web3.Eth.GetEvent<LogCallFinishedEventDTO>(_contract);
            var filter = eventhandler.CreateFilterInput();
            return await eventhandler.GetAllChanges(filter);
        }

        public async Task<List<EventLog<LogCallStatusUpdatedEventDTO>>> ListAllLogCallStatusUpdatedEvents()
        {
            var web3 = new Web3(_config.Url);
            var eventhandler = web3.Eth.GetEvent<LogCallStatusUpdatedEventDTO>(_contract);
            var filter = eventhandler.CreateFilterInput();
            return await eventhandler.GetAllChanges(filter);
        }

        public async Task<TransactionReceipt> UpdateCallStatus(BigInteger CallId, string mcTxid, string secret, FoscApiStatus status)
        {
            var web3 = new Web3(_account, _config.Url);
            var handler = web3.Eth.GetContractTransactionHandler<UpdateCallStatusFunction>();
            var jsonResult = JsonConvert.SerializeObject(new { txid = mcTxid, secret = secret });
            var functionMsg = new UpdateCallStatusFunction
            {
                CallId = CallId,
                Result = EncodeHelper.UTF82Bytes(jsonResult),
                NewStatus = (byte)status
            };
            _nlogger.Debug($"UpdateCallStatus => SC:\n{JsonConvert.SerializeObject(functionMsg, Formatting.Indented)}");
            var receipt = await handler.SendRequestAndWaitForReceiptAsync(_contract, functionMsg);
            _nlogger.Debug($"SC txid <= SC:{receipt.TransactionHash}");
            return receipt;
        }

        public async Task<TransactionReceipt> UpdateCallStatus(BigInteger CallId, int status)
        {
            var web3 = new Web3(_account, _config.Url);
            var handler = web3.Eth.GetContractTransactionHandler<UpdateCallStatusFunction>();

            var functionMsg = new UpdateCallStatusFunction
            {
                CallId = CallId,
                Result = new byte[] { 0 },
                NewStatus = (byte)status
            };

            _nlogger.Debug($"UpdateCallStatus => SC:\n{JsonConvert.SerializeObject(functionMsg, Formatting.Indented)}");
            var receipt = await handler.SendRequestAndWaitForReceiptAsync(
                _contract, functionMsg);
            _nlogger.Debug($"SC txid <= SC:{receipt.TransactionHash}");

            return receipt;
        }

        public async Task<CallsOutputDTO> GetCall(BigInteger callId)
        {
            var web3 = new Web3(_account, _config.Url);
            var handler = web3.Eth.GetContractQueryHandler<CallsFunction>();
            var result = await handler.QueryDeserializingToObjectAsync<CallsOutputDTO>(new CallsFunction { ReturnValue1 = callId }, _contract);
            return result;
        }

        public async Task<TransactionReceipt> CallAndTransferGetLivestockInfo(string seniContractAddress,
            TransferAndCallDataInput data, BigInteger callValue)
        {
            var web3 = new Web3(_account, _config.Url);
            var handler = web3.Eth.GetContractTransactionHandler<TransferAndCallFunction>();

            var functionMsg = new TransferAndCallFunction
            {
                To = _contract,
                Data = data.GetBytes(data),
                Value = callValue
            };

            _nlogger.Debug($"CallAndTransfer => SC:\n{JsonConvert.SerializeObject(functionMsg, Formatting.Indented)}");
            var receipt = await handler.SendRequestAndWaitForReceiptAsync(
                seniContractAddress, functionMsg);
            _nlogger.Debug($"txid <= SC: {receipt.TransactionHash}");

            return receipt;
        }


    }
}
