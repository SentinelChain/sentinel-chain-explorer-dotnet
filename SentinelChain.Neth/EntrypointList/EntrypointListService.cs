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
using SentinelChain.Neth.EntrypointList.ContractDefinition;

namespace SentinelChain.Neth.EntrypointList
{
    public partial class EntrypointListService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, EntrypointListDeployment entrypointListDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<EntrypointListDeployment>().SendRequestAndWaitForReceiptAsync(entrypointListDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, EntrypointListDeployment entrypointListDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<EntrypointListDeployment>().SendRequestAsync(entrypointListDeployment);
        }

        public static async Task<EntrypointListService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, EntrypointListDeployment entrypointListDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, entrypointListDeployment, cancellationTokenSource);
            return new EntrypointListService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public EntrypointListService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<bool> CheckRoleQueryAsync(CheckRoleFunction checkRoleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckRoleFunction, bool>(checkRoleFunction, blockParameter);
        }

        
        public Task<bool> CheckRoleQueryAsync(string operatorInput, string role, BlockParameter blockParameter = null)
        {
            var checkRoleFunction = new CheckRoleFunction();
                checkRoleFunction.Operator = operatorInput;
                checkRoleFunction.Role = role;
            
            return ContractHandler.QueryAsync<CheckRoleFunction, bool>(checkRoleFunction, blockParameter);
        }

        public Task<string> EntryPointRequestAsync(EntryPointFunction entryPointFunction)
        {
             return ContractHandler.SendRequestAsync(entryPointFunction);
        }

        public Task<TransactionReceipt> EntryPointRequestAndWaitForReceiptAsync(EntryPointFunction entryPointFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(entryPointFunction, cancellationToken);
        }

        public Task<string> EntryPointRequestAsync(BigInteger id)
        {
            var entryPointFunction = new EntryPointFunction();
                entryPointFunction.Id = id;
            
             return ContractHandler.SendRequestAsync(entryPointFunction);
        }

        public Task<TransactionReceipt> EntryPointRequestAndWaitForReceiptAsync(BigInteger id, CancellationTokenSource cancellationToken = null)
        {
            var entryPointFunction = new EntryPointFunction();
                entryPointFunction.Id = id;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(entryPointFunction, cancellationToken);
        }

        public Task<byte[]> EntrypointListQueryAsync(EntrypointListFunction entrypointListFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EntrypointListFunction, byte[]>(entrypointListFunction, blockParameter);
        }

        
        public Task<byte[]> EntrypointListQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var entrypointListFunction = new EntrypointListFunction();
                entrypointListFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<EntrypointListFunction, byte[]>(entrypointListFunction, blockParameter);
        }

        public Task<bool> HasRoleQueryAsync(HasRoleFunction hasRoleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasRoleFunction, bool>(hasRoleFunction, blockParameter);
        }

        
        public Task<bool> HasRoleQueryAsync(string operatorInput, string role, BlockParameter blockParameter = null)
        {
            var hasRoleFunction = new HasRoleFunction();
                hasRoleFunction.Operator = operatorInput;
                hasRoleFunction.Role = role;
            
            return ContractHandler.QueryAsync<HasRoleFunction, bool>(hasRoleFunction, blockParameter);
        }

        public Task<string> RenounceOwnershipRequestAsync(RenounceOwnershipFunction renounceOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(renounceOwnershipFunction);
        }

        public Task<string> RenounceOwnershipRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceOwnershipFunction>();
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(RenounceOwnershipFunction renounceOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceOwnershipFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceOwnershipFunction>(null, cancellationToken);
        }

        public Task<string> AddEntryPointRequestAsync(AddEntryPointFunction addEntryPointFunction)
        {
             return ContractHandler.SendRequestAsync(addEntryPointFunction);
        }

        public Task<TransactionReceipt> AddEntryPointRequestAndWaitForReceiptAsync(AddEntryPointFunction addEntryPointFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addEntryPointFunction, cancellationToken);
        }

        public Task<string> AddEntryPointRequestAsync(byte[] entryPoint)
        {
            var addEntryPointFunction = new AddEntryPointFunction();
                addEntryPointFunction.EntryPoint = entryPoint;
            
             return ContractHandler.SendRequestAsync(addEntryPointFunction);
        }

        public Task<TransactionReceipt> AddEntryPointRequestAndWaitForReceiptAsync(byte[] entryPoint, CancellationTokenSource cancellationToken = null)
        {
            var addEntryPointFunction = new AddEntryPointFunction();
                addEntryPointFunction.EntryPoint = entryPoint;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addEntryPointFunction, cancellationToken);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> AddOperatorRequestAsync(AddOperatorFunction addOperatorFunction)
        {
             return ContractHandler.SendRequestAsync(addOperatorFunction);
        }

        public Task<TransactionReceipt> AddOperatorRequestAndWaitForReceiptAsync(AddOperatorFunction addOperatorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addOperatorFunction, cancellationToken);
        }

        public Task<string> AddOperatorRequestAsync(string operatorInput)
        {
            var addOperatorFunction = new AddOperatorFunction();
                addOperatorFunction.Operator = operatorInput;
            
             return ContractHandler.SendRequestAsync(addOperatorFunction);
        }

        public Task<TransactionReceipt> AddOperatorRequestAndWaitForReceiptAsync(string operatorInput, CancellationTokenSource cancellationToken = null)
        {
            var addOperatorFunction = new AddOperatorFunction();
                addOperatorFunction.Operator = operatorInput;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addOperatorFunction, cancellationToken);
        }

        public Task<string> ROLE_OPERATORQueryAsync(ROLE_OPERATORFunction rOLE_OPERATORFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ROLE_OPERATORFunction, string>(rOLE_OPERATORFunction, blockParameter);
        }

        
        public Task<string> ROLE_OPERATORQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ROLE_OPERATORFunction, string>(null, blockParameter);
        }

        public Task<string> RemoveOperatorRequestAsync(RemoveOperatorFunction removeOperatorFunction)
        {
             return ContractHandler.SendRequestAsync(removeOperatorFunction);
        }

        public Task<TransactionReceipt> RemoveOperatorRequestAndWaitForReceiptAsync(RemoveOperatorFunction removeOperatorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeOperatorFunction, cancellationToken);
        }

        public Task<string> RemoveOperatorRequestAsync(string operatorInput)
        {
            var removeOperatorFunction = new RemoveOperatorFunction();
                removeOperatorFunction.Operator = operatorInput;
            
             return ContractHandler.SendRequestAsync(removeOperatorFunction);
        }

        public Task<TransactionReceipt> RemoveOperatorRequestAndWaitForReceiptAsync(string operatorInput, CancellationTokenSource cancellationToken = null)
        {
            var removeOperatorFunction = new RemoveOperatorFunction();
                removeOperatorFunction.Operator = operatorInput;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeOperatorFunction, cancellationToken);
        }

        public Task<BigInteger> NextIdQueryAsync(NextIdFunction nextIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NextIdFunction, BigInteger>(nextIdFunction, blockParameter);
        }

        
        public Task<BigInteger> NextIdQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NextIdFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }
    }
}
