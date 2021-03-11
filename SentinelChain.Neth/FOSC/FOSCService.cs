using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using SentinelChain.Neth.FOSC.ContractDefinition;

namespace SentinelChain.Neth.FOSC
{
    public partial class FOSCService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, FOSCDeployment fOSCDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<FOSCDeployment>().SendRequestAndWaitForReceiptAsync(fOSCDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, FOSCDeployment fOSCDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<FOSCDeployment>().SendRequestAsync(fOSCDeployment);
        }

        public static async Task<FOSCService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, FOSCDeployment fOSCDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, fOSCDeployment, cancellationTokenSource);
            return new FOSCService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public FOSCService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> CallValueQueryAsync(CallValueFunction callValueFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CallValueFunction, BigInteger>(callValueFunction, blockParameter);
        }

        
        public Task<BigInteger> CallValueQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CallValueFunction, BigInteger>(null, blockParameter);
        }

        public Task<CallsOutputDTO> CallsQueryAsync(CallsFunction callsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<CallsFunction, CallsOutputDTO>(callsFunction, blockParameter);
        }

        public Task<CallsOutputDTO> CallsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var callsFunction = new CallsFunction();
                callsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<CallsFunction, CallsOutputDTO>(callsFunction, blockParameter);
        }

        public Task<string> OnTokenTransferRequestAsync(OnTokenTransferFunction onTokenTransferFunction)
        {
             return ContractHandler.SendRequestAsync(onTokenTransferFunction);
        }

        public Task<TransactionReceipt> OnTokenTransferRequestAndWaitForReceiptAsync(OnTokenTransferFunction onTokenTransferFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onTokenTransferFunction, cancellationToken);
        }

        public Task<string> OnTokenTransferRequestAsync(string from, BigInteger value, byte[] data)
        {
            var onTokenTransferFunction = new OnTokenTransferFunction();
                onTokenTransferFunction.From = from;
                onTokenTransferFunction.Value = value;
                onTokenTransferFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(onTokenTransferFunction);
        }

        public Task<TransactionReceipt> OnTokenTransferRequestAndWaitForReceiptAsync(string from, BigInteger value, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var onTokenTransferFunction = new OnTokenTransferFunction();
                onTokenTransferFunction.From = from;
                onTokenTransferFunction.Value = value;
                onTokenTransferFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onTokenTransferFunction, cancellationToken);
        }

        public Task<string> OracleQueryAsync(OracleFunction oracleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OracleFunction, string>(oracleFunction, blockParameter);
        }

        
        public Task<string> OracleQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OracleFunction, string>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> SetCallValueRequestAsync(SetCallValueFunction setCallValueFunction)
        {
             return ContractHandler.SendRequestAsync(setCallValueFunction);
        }

        public Task<TransactionReceipt> SetCallValueRequestAndWaitForReceiptAsync(SetCallValueFunction setCallValueFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setCallValueFunction, cancellationToken);
        }

        public Task<string> SetCallValueRequestAsync(BigInteger callValue)
        {
            var setCallValueFunction = new SetCallValueFunction();
                setCallValueFunction.CallValue = callValue;
            
             return ContractHandler.SendRequestAsync(setCallValueFunction);
        }

        public Task<TransactionReceipt> SetCallValueRequestAndWaitForReceiptAsync(BigInteger callValue, CancellationTokenSource cancellationToken = null)
        {
            var setCallValueFunction = new SetCallValueFunction();
                setCallValueFunction.CallValue = callValue;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setCallValueFunction, cancellationToken);
        }

        public Task<string> SetOracleRequestAsync(SetOracleFunction setOracleFunction)
        {
             return ContractHandler.SendRequestAsync(setOracleFunction);
        }

        public Task<TransactionReceipt> SetOracleRequestAndWaitForReceiptAsync(SetOracleFunction setOracleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setOracleFunction, cancellationToken);
        }

        public Task<string> SetOracleRequestAsync(string newOracle)
        {
            var setOracleFunction = new SetOracleFunction();
                setOracleFunction.NewOracle = newOracle;
            
             return ContractHandler.SendRequestAsync(setOracleFunction);
        }

        public Task<TransactionReceipt> SetOracleRequestAndWaitForReceiptAsync(string newOracle, CancellationTokenSource cancellationToken = null)
        {
            var setOracleFunction = new SetOracleFunction();
                setOracleFunction.NewOracle = newOracle;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setOracleFunction, cancellationToken);
        }

        public Task<string> TokenQueryAsync(TokenFunction tokenFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenFunction, string>(tokenFunction, blockParameter);
        }

        
        public Task<string> TokenQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenFunction, string>(null, blockParameter);
        }

        public Task<string> UpdateCallStatusRequestAsync(UpdateCallStatusFunction updateCallStatusFunction)
        {
             return ContractHandler.SendRequestAsync(updateCallStatusFunction);
        }

        public Task<TransactionReceipt> UpdateCallStatusRequestAndWaitForReceiptAsync(UpdateCallStatusFunction updateCallStatusFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateCallStatusFunction, cancellationToken);
        }

        public Task<string> UpdateCallStatusRequestAsync(BigInteger callId, byte newStatus, byte[] result)
        {
            var updateCallStatusFunction = new UpdateCallStatusFunction();
                updateCallStatusFunction.CallId = callId;
                updateCallStatusFunction.NewStatus = newStatus;
                updateCallStatusFunction.Result = result;
            
             return ContractHandler.SendRequestAsync(updateCallStatusFunction);
        }

        public Task<TransactionReceipt> UpdateCallStatusRequestAndWaitForReceiptAsync(BigInteger callId, byte newStatus, byte[] result, CancellationTokenSource cancellationToken = null)
        {
            var updateCallStatusFunction = new UpdateCallStatusFunction();
                updateCallStatusFunction.CallId = callId;
                updateCallStatusFunction.NewStatus = newStatus;
                updateCallStatusFunction.Result = result;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateCallStatusFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(WithdrawFunction withdrawFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(BigInteger amount)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }
    }
}
