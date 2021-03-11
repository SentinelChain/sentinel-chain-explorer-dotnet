using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using SentinelChain.Neth.FOSC.ContractDefinition;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace SentinelChain
{
    public interface IFoscService
    {
        Task<TransactionReceipt> CallAndTransferGetLivestockInfo(string seniContractAddress, string serialNo, BigInteger callValue);
        Task<CallsOutputDTO> GetCall(BigInteger callId);
        Task<HexBigInteger> GetLatestLogCallFinishedEventsFilter();
        Task<HexBigInteger> GetLatestLogNewAPICallEventsFilter();
        Task<List<EventLog<LogCallFinishedEventDTO>>> ListAllLogCallFinishedEvents();
        Task<List<EventLog<LogCallStatusUpdatedEventDTO>>> ListAllLogCallStatusUpdatedEvents();
        Task<List<EventLog<LogNewAPICallEventDTO>>> ListAllLogNewAPICallEvents();
        Task<List<EventLog<LogCallFinishedEventDTO>>> ListLatestLogCallFinishedEvents(HexBigInteger filterId);
        Task<List<EventLog<LogNewAPICallEventDTO>>> ListLatestLogNewAPICallEvents(HexBigInteger filterId);
        Task<TransactionReceipt> UpdateCallStatus(BigInteger CallId, string mcTxid, string secret, FoscApiStatus status);
        Task<TransactionReceipt> UpdateCallStatus(BigInteger CallId, int status);
    }
}