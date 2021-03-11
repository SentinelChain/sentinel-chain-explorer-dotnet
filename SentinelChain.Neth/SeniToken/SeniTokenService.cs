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
using SentinelChain.Neth.SeniToken.ContractDefinition;

namespace SentinelChain.Neth.SeniToken
{
    public partial class SeniTokenService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, SeniTokenDeployment seniTokenDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<SeniTokenDeployment>().SendRequestAndWaitForReceiptAsync(seniTokenDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, SeniTokenDeployment seniTokenDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<SeniTokenDeployment>().SendRequestAsync(seniTokenDeployment);
        }

        public static async Task<SeniTokenService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, SeniTokenDeployment seniTokenDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, seniTokenDeployment, cancellationTokenSource);
            return new SeniTokenService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public SeniTokenService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<bool> MintingFinishedQueryAsync(MintingFinishedFunction mintingFinishedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MintingFinishedFunction, bool>(mintingFinishedFunction, blockParameter);
        }

        
        public Task<bool> MintingFinishedQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MintingFinishedFunction, bool>(null, blockParameter);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string spender, BigInteger value)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string spender, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> SetBridgeContractRequestAsync(SetBridgeContractFunction setBridgeContractFunction)
        {
             return ContractHandler.SendRequestAsync(setBridgeContractFunction);
        }

        public Task<TransactionReceipt> SetBridgeContractRequestAndWaitForReceiptAsync(SetBridgeContractFunction setBridgeContractFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBridgeContractFunction, cancellationToken);
        }

        public Task<string> SetBridgeContractRequestAsync(string bridgeContract)
        {
            var setBridgeContractFunction = new SetBridgeContractFunction();
                setBridgeContractFunction.BridgeContract = bridgeContract;
            
             return ContractHandler.SendRequestAsync(setBridgeContractFunction);
        }

        public Task<TransactionReceipt> SetBridgeContractRequestAndWaitForReceiptAsync(string bridgeContract, CancellationTokenSource cancellationToken = null)
        {
            var setBridgeContractFunction = new SetBridgeContractFunction();
                setBridgeContractFunction.BridgeContract = bridgeContract;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBridgeContractFunction, cancellationToken);
        }

        public Task<string> SetWhitelistContractRequestAsync(SetWhitelistContractFunction setWhitelistContractFunction)
        {
             return ContractHandler.SendRequestAsync(setWhitelistContractFunction);
        }

        public Task<TransactionReceipt> SetWhitelistContractRequestAndWaitForReceiptAsync(SetWhitelistContractFunction setWhitelistContractFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setWhitelistContractFunction, cancellationToken);
        }

        public Task<string> SetWhitelistContractRequestAsync(string whitelistContract)
        {
            var setWhitelistContractFunction = new SetWhitelistContractFunction();
                setWhitelistContractFunction.WhitelistContract = whitelistContract;
            
             return ContractHandler.SendRequestAsync(setWhitelistContractFunction);
        }

        public Task<TransactionReceipt> SetWhitelistContractRequestAndWaitForReceiptAsync(string whitelistContract, CancellationTokenSource cancellationToken = null)
        {
            var setWhitelistContractFunction = new SetWhitelistContractFunction();
                setWhitelistContractFunction.WhitelistContract = whitelistContract;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setWhitelistContractFunction, cancellationToken);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string from, string to, BigInteger value)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<byte> DECIMALSQueryAsync(DECIMALSFunction dECIMALSFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DECIMALSFunction, byte>(dECIMALSFunction, blockParameter);
        }

        
        public Task<byte> DECIMALSQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DECIMALSFunction, byte>(null, blockParameter);
        }

        public Task<byte> DecimalsQueryAsync(DecimalsFunction decimalsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(decimalsFunction, blockParameter);
        }

        
        public Task<byte> DecimalsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(null, blockParameter);
        }

        public Task<string> TransferAndCallRequestAsync(TransferAndCallFunction transferAndCallFunction)
        {
             return ContractHandler.SendRequestAsync(transferAndCallFunction);
        }

        public Task<TransactionReceipt> TransferAndCallRequestAndWaitForReceiptAsync(TransferAndCallFunction transferAndCallFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferAndCallFunction, cancellationToken);
        }

        public Task<string> TransferAndCallRequestAsync(string to, BigInteger value, byte[] data)
        {
            var transferAndCallFunction = new TransferAndCallFunction();
                transferAndCallFunction.To = to;
                transferAndCallFunction.Value = value;
                transferAndCallFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(transferAndCallFunction);
        }

        public Task<TransactionReceipt> TransferAndCallRequestAndWaitForReceiptAsync(string to, BigInteger value, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var transferAndCallFunction = new TransferAndCallFunction();
                transferAndCallFunction.To = to;
                transferAndCallFunction.Value = value;
                transferAndCallFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferAndCallFunction, cancellationToken);
        }

        public Task<string> MintRequestAsync(MintFunction mintFunction)
        {
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(MintFunction mintFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public Task<string> MintRequestAsync(string to, BigInteger amount)
        {
            var mintFunction = new MintFunction();
                mintFunction.To = to;
                mintFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(string to, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var mintFunction = new MintFunction();
                mintFunction.To = to;
                mintFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public Task<string> BurnRequestAsync(BurnFunction burnFunction)
        {
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(BurnFunction burnFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> BurnRequestAsync(BigInteger value)
        {
            var burnFunction = new BurnFunction();
                burnFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var burnFunction = new BurnFunction();
                burnFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> DecreaseApprovalRequestAsync(DecreaseApprovalFunction decreaseApprovalFunction)
        {
             return ContractHandler.SendRequestAsync(decreaseApprovalFunction);
        }

        public Task<TransactionReceipt> DecreaseApprovalRequestAndWaitForReceiptAsync(DecreaseApprovalFunction decreaseApprovalFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(decreaseApprovalFunction, cancellationToken);
        }

        public Task<string> DecreaseApprovalRequestAsync(string spender, BigInteger subtractedValue)
        {
            var decreaseApprovalFunction = new DecreaseApprovalFunction();
                decreaseApprovalFunction.Spender = spender;
                decreaseApprovalFunction.SubtractedValue = subtractedValue;
            
             return ContractHandler.SendRequestAsync(decreaseApprovalFunction);
        }

        public Task<TransactionReceipt> DecreaseApprovalRequestAndWaitForReceiptAsync(string spender, BigInteger subtractedValue, CancellationTokenSource cancellationToken = null)
        {
            var decreaseApprovalFunction = new DecreaseApprovalFunction();
                decreaseApprovalFunction.Spender = spender;
                decreaseApprovalFunction.SubtractedValue = subtractedValue;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(decreaseApprovalFunction, cancellationToken);
        }

        public Task<string> ClaimTokensRequestAsync(ClaimTokensFunction claimTokensFunction)
        {
             return ContractHandler.SendRequestAsync(claimTokensFunction);
        }

        public Task<TransactionReceipt> ClaimTokensRequestAndWaitForReceiptAsync(ClaimTokensFunction claimTokensFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(claimTokensFunction, cancellationToken);
        }

        public Task<string> ClaimTokensRequestAsync(string token, string to)
        {
            var claimTokensFunction = new ClaimTokensFunction();
                claimTokensFunction.Token = token;
                claimTokensFunction.To = to;
            
             return ContractHandler.SendRequestAsync(claimTokensFunction);
        }

        public Task<TransactionReceipt> ClaimTokensRequestAndWaitForReceiptAsync(string token, string to, CancellationTokenSource cancellationToken = null)
        {
            var claimTokensFunction = new ClaimTokensFunction();
                claimTokensFunction.Token = token;
                claimTokensFunction.To = to;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(claimTokensFunction, cancellationToken);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string owner, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.Owner = owner;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
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

        public Task<string> FinishMintingRequestAsync(FinishMintingFunction finishMintingFunction)
        {
             return ContractHandler.SendRequestAsync(finishMintingFunction);
        }

        public Task<string> FinishMintingRequestAsync()
        {
             return ContractHandler.SendRequestAsync<FinishMintingFunction>();
        }

        public Task<TransactionReceipt> FinishMintingRequestAndWaitForReceiptAsync(FinishMintingFunction finishMintingFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(finishMintingFunction, cancellationToken);
        }

        public Task<TransactionReceipt> FinishMintingRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<FinishMintingFunction>(null, cancellationToken);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> WhitelistQueryAsync(WhitelistFunction whitelistFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WhitelistFunction, string>(whitelistFunction, blockParameter);
        }

        
        public Task<string> WhitelistQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WhitelistFunction, string>(null, blockParameter);
        }

        public Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(symbolFunction, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(null, blockParameter);
        }

        public Task<string> NAMEQueryAsync(NAMEFunction nAMEFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NAMEFunction, string>(nAMEFunction, blockParameter);
        }

        
        public Task<string> NAMEQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NAMEFunction, string>(null, blockParameter);
        }

        public Task<string> TransferRequestAsync(TransferFunction transferFunction)
        {
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(TransferFunction transferFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferRequestAsync(string to, BigInteger value)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(string to, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> BridgeContractQueryAsync(BridgeContractFunction bridgeContractFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BridgeContractFunction, string>(bridgeContractFunction, blockParameter);
        }

        
        public Task<string> BridgeContractQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BridgeContractFunction, string>(null, blockParameter);
        }

        public Task<string> IncreaseApprovalRequestAsync(IncreaseApprovalFunction increaseApprovalFunction)
        {
             return ContractHandler.SendRequestAsync(increaseApprovalFunction);
        }

        public Task<TransactionReceipt> IncreaseApprovalRequestAndWaitForReceiptAsync(IncreaseApprovalFunction increaseApprovalFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(increaseApprovalFunction, cancellationToken);
        }

        public Task<string> IncreaseApprovalRequestAsync(string spender, BigInteger addedValue)
        {
            var increaseApprovalFunction = new IncreaseApprovalFunction();
                increaseApprovalFunction.Spender = spender;
                increaseApprovalFunction.AddedValue = addedValue;
            
             return ContractHandler.SendRequestAsync(increaseApprovalFunction);
        }

        public Task<TransactionReceipt> IncreaseApprovalRequestAndWaitForReceiptAsync(string spender, BigInteger addedValue, CancellationTokenSource cancellationToken = null)
        {
            var increaseApprovalFunction = new IncreaseApprovalFunction();
                increaseApprovalFunction.Spender = spender;
                increaseApprovalFunction.AddedValue = addedValue;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(increaseApprovalFunction, cancellationToken);
        }

        public Task<BigInteger> AllowanceQueryAsync(AllowanceFunction allowanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        
        public Task<BigInteger> AllowanceQueryAsync(string owner, string spender, BlockParameter blockParameter = null)
        {
            var allowanceFunction = new AllowanceFunction();
                allowanceFunction.Owner = owner;
                allowanceFunction.Spender = spender;
            
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
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

        public Task<string> SYMBOLQueryAsync(SYMBOLFunction sYMBOLFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SYMBOLFunction, string>(sYMBOLFunction, blockParameter);
        }

        
        public Task<string> SYMBOLQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SYMBOLFunction, string>(null, blockParameter);
        }
    }
}
