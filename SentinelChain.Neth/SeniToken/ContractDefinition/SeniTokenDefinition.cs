using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace SentinelChain.Neth.SeniToken.ContractDefinition
{


    public partial class SeniTokenDeployment : SeniTokenDeploymentBase
    {
        public SeniTokenDeployment() : base(BYTECODE) { }
        public SeniTokenDeployment(string byteCode) : base(byteCode) { }
    }

    public class SeniTokenDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040526006805460a060020a60ff02191690553480156200002157600080fd5b506040516020806200184d83398101604081815291518282018352601d82527f53656e74696e656c20436861696e20496e7465726e616c20546f6b656e00000060208084019182528451808601909552600485527f53454e4900000000000000000000000000000000000000000000000000000000908501528251919391601291620000b191600091906200012d565b508151620000c79060019060208501906200012d565b506002805460ff90921660ff19909216919091179055505060068054600160a060020a03191633179055600160a060020a03811615156200010757600080fd5b60088054600160a060020a031916600160a060020a0392909216919091179055620001d2565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106200017057805160ff1916838001178555620001a0565b82800160010185558215620001a0579182015b82811115620001a057825182559160200191906001019062000183565b50620001ae929150620001b2565b5090565b620001cf91905b80821115620001ae5760008155600101620001b9565b90565b61166b80620001e26000396000f30060806040526004361061015e5763ffffffff7c010000000000000000000000000000000000000000000000000000000060003504166305d2035b811461016357806306fdde031461018c578063095ea7b3146102165780630b26cf661461023a57806312f261401461025d57806318160ddd1461027e57806323b872dd146102a55780632e0f2625146102cf578063313ce567146102fa5780634000aea01461030f57806340c10f191461034057806342966c6814610364578063661884631461037c57806369ffa08a146103a057806370a08231146103c7578063715018a6146103e85780637d64bcb4146103fd5780638da5cb5b1461041257806393e59dc11461044357806395d89b4114610458578063a3f4df7e1461046d578063a9059cbb14610482578063cd596583146104a6578063d73dd623146104bb578063dd62ed3e146104df578063f2fde38b14610506578063f76f8d7814610527575b600080fd5b34801561016f57600080fd5b5061017861053c565b604080519115158252519081900360200190f35b34801561019857600080fd5b506101a161055d565b6040805160208082528351818301528351919283929083019185019080838360005b838110156101db5781810151838201526020016101c3565b50505050905090810190601f1680156102085780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b34801561022257600080fd5b50610178600160a060020a03600435166024356105eb565b34801561024657600080fd5b5061025b600160a060020a0360043516610651565b005b34801561026957600080fd5b5061025b600160a060020a03600435166106be565b34801561028a57600080fd5b5061029361072b565b60408051918252519081900360200190f35b3480156102b157600080fd5b50610178600160a060020a0360043581169060243516604435610731565b3480156102db57600080fd5b506102e46107e5565b6040805160ff9092168252519081900360200190f35b34801561030657600080fd5b506102e46107ea565b34801561031b57600080fd5b5061017860048035600160a060020a03169060248035916044359182019101356107f3565b34801561034c57600080fd5b50610178600160a060020a0360043516602435610902565b34801561037057600080fd5b5061025b6004356109b4565b34801561038857600080fd5b50610178600160a060020a03600435166024356109c1565b3480156103ac57600080fd5b5061025b600160a060020a0360043581169060243516610ab0565b3480156103d357600080fd5b50610293600160a060020a0360043516610c69565b3480156103f457600080fd5b5061025b610c84565b34801561040957600080fd5b50610178610c9b565b34801561041e57600080fd5b50610427610ca2565b60408051600160a060020a039092168252519081900360200190f35b34801561044f57600080fd5b50610427610cb1565b34801561046457600080fd5b506101a1610cc0565b34801561047957600080fd5b506101a1610d1a565b34801561048e57600080fd5b50610178600160a060020a0360043516602435610d51565b3480156104b257600080fd5b50610427610e08565b3480156104c757600080fd5b50610178600160a060020a0360043516602435610e17565b3480156104eb57600080fd5b50610293600160a060020a0360043581169060243516610eb0565b34801561051257600080fd5b5061025b600160a060020a0360043516610edb565b34801561053357600080fd5b506101a1610efb565b60065474010000000000000000000000000000000000000000900460ff1681565b6000805460408051602060026001851615610100026000190190941693909304601f810184900484028201840190925281815292918301828280156105e35780601f106105b8576101008083540402835291602001916105e3565b820191906000526020600020905b8154815290600101906020018083116105c657829003601f168201915b505050505081565b336000818152600560209081526040808320600160a060020a038716808552908352818420869055815186815291519394909390927f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925928290030190a350600192915050565b600654600160a060020a0316331461066857600080fd5b600160a060020a03811615801590610684575061068481610f32565b151561068f57600080fd5b6007805473ffffffffffffffffffffffffffffffffffffffff1916600160a060020a0392909216919091179055565b600654600160a060020a031633146106d557600080fd5b600160a060020a038116158015906106f157506106f181610f32565b15156106fc57600080fd5b6008805473ffffffffffffffffffffffffffffffffffffffff1916600160a060020a0392909216919091179055565b60045490565b600854604080517f3af32abf000000000000000000000000000000000000000000000000000000008152600160a060020a038086166004830152915160009386931691633af32abf91602480830192602092919082900301818887803b15801561079a57600080fd5b505af11580156107ae573d6000803e3d6000fd5b505050506040513d60208110156107c457600080fd5b505115156107d157600080fd5b6107dc858585610f3a565b50509392505050565b601281565b60025460ff1681565b600084600160a060020a038116151561080b57600080fd5b600160a060020a03811630141561082157600080fd5b61082b868661109f565b151561083657600080fd5b85600160a060020a031633600160a060020a03167fe19260aff97b920c7df27010903aeb9c8d2be5d310a2c67824cf3f15396e4c16878787604051808481526020018060200182810382528484828181526020019250808284376040519201829003965090945050505050a36108ab86610f32565b156108f6576108eb868686868080601f01602080910402602001604051908101604052809392919081815260200183838082843750611149945050505050565b15156108f657600080fd5b50600195945050505050565b600854604080517f3af32abf000000000000000000000000000000000000000000000000000000008152600160a060020a038086166004830152915160009386931691633af32abf91602480830192602092919082900301818887803b15801561096b57600080fd5b505af115801561097f573d6000803e3d6000fd5b505050506040513d602081101561099557600080fd5b505115156109a257600080fd5b6109ac84846112b3565b949350505050565b6109be33826113be565b50565b336000908152600560209081526040808320600160a060020a0386168452909152812054808310610a1557336000908152600560209081526040808320600160a060020a0388168452909152812055610a4a565b610a25818463ffffffff6114ad16565b336000908152600560209081526040808320600160a060020a03891684529091529020555b336000818152600560209081526040808320600160a060020a0389168085529083529281902054815190815290519293927f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925929181900390910190a35060019392505050565b6006546000908190600160a060020a03163314610acc57600080fd5b600160a060020a0383161515610ae157600080fd5b600160a060020a0384161515610b2d57604051600160a060020a03841690303180156108fc02916000818181858888f19350505050158015610b27573d6000803e3d6000fd5b50610c63565b604080517f70a082310000000000000000000000000000000000000000000000000000000081523060048201529051859350600160a060020a038416916370a082319160248083019260209291908290030181600087803b158015610b9157600080fd5b505af1158015610ba5573d6000803e3d6000fd5b505050506040513d6020811015610bbb57600080fd5b5051604080517fa9059cbb000000000000000000000000000000000000000000000000000000008152600160a060020a0386811660048301526024820184905291519293509084169163a9059cbb916044808201926020929091908290030181600087803b158015610c2c57600080fd5b505af1158015610c40573d6000803e3d6000fd5b505050506040513d6020811015610c5657600080fd5b50511515610c6357600080fd5b50505050565b600160a060020a031660009081526003602052604090205490565b600654600160a060020a0316331461015e57600080fd5b6000806000fd5b600654600160a060020a031681565b600854600160a060020a031681565b60018054604080516020600284861615610100026000190190941693909304601f810184900484028201840190925281815292918301828280156105e35780601f106105b8576101008083540402835291602001916105e3565b60408051808201909152601d81527f53656e74696e656c20436861696e20496e7465726e616c20546f6b656e000000602082015281565b6000610d5d838361109f565b1515610d6857600080fd5b610d7183610f32565b8015610d965750604080516000815260208101909152610d949084908490611149565b155b15610dff57600754600160a060020a0384811691161415610db657600080fd5b60408051338152600160a060020a038516602082015280820184905290517f11249f0fc79fc134a15a10d1da8291b79515bf987e036ced05b9ec119614070b9181900360600190a15b50600192915050565b600754600160a060020a031681565b336000908152600560209081526040808320600160a060020a0386168452909152812054610e4b908363ffffffff6114bf16565b336000818152600560209081526040808320600160a060020a0389168085529083529281902085905580519485525191937f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925929081900390910190a350600192915050565b600160a060020a03918216600090815260056020908152604080832093909416825291909152205490565b600654600160a060020a03163314610ef257600080fd5b6109be816114d2565b60408051808201909152600481527f53454e4900000000000000000000000000000000000000000000000000000000602082015281565b6000903b1190565b600160a060020a038316600090815260036020526040812054821115610f5f57600080fd5b600160a060020a0384166000908152600560209081526040808320338452909152902054821115610f8f57600080fd5b600160a060020a0383161515610fa457600080fd5b600160a060020a038416600090815260036020526040902054610fcd908363ffffffff6114ad16565b600160a060020a038086166000908152600360205260408082209390935590851681522054611002908363ffffffff6114bf16565b600160a060020a038085166000908152600360209081526040808320949094559187168152600582528281203382529091522054611046908363ffffffff6114ad16565b600160a060020a0380861660008181526005602090815260408083203384528252918290209490945580518681529051928716939192600080516020611620833981519152929181900390910190a35060019392505050565b600854604080517f3af32abf000000000000000000000000000000000000000000000000000000008152600160a060020a038086166004830152915160009386931691633af32abf91602480830192602092919082900301818887803b15801561110857600080fd5b505af115801561111c573d6000803e3d6000fd5b505050506040513d602081101561113257600080fd5b5051151561113f57600080fd5b6109ac8484611550565b600083600160a060020a03163384846040516024018084600160a060020a0316600160a060020a0316815260200183815260200180602001828103825283818151815260200191508051906020019080838360005b838110156111b657818101518382015260200161119e565b50505050905090810190601f1680156111e35780820380516001836020036101000a031916815260200191505b5060408051601f198184030181529181526020820180517bffffffffffffffffffffffffffffffffffffffffffffffffffffffff167fa4c0ed36000000000000000000000000000000000000000000000000000000001781529051825192975095508594509250905080838360005b8381101561126a578181015183820152602001611252565b50505050905090810190601f1680156112975780820380516001836020036101000a031916815260200191505b509150506000604051808303816000865af19695505050505050565b600654600090600160a060020a031633146112cd57600080fd5b60065474010000000000000000000000000000000000000000900460ff16156112f557600080fd5b600454611308908363ffffffff6114bf16565b600455600160a060020a038316600090815260036020526040902054611334908363ffffffff6114bf16565b600160a060020a038416600081815260036020908152604091829020939093558051858152905191927f0f6798a560793a54c3bcfe86a93cde1e73087d944c0ea20544137d412139688592918290030190a2604080518381529051600160a060020a038516916000916000805160206116208339815191529181900360200190a350600192915050565b600160a060020a0382166000908152600360205260409020548111156113e357600080fd5b600160a060020a03821660009081526003602052604090205461140c908263ffffffff6114ad16565b600160a060020a038316600090815260036020526040902055600454611438908263ffffffff6114ad16565b600455604080518281529051600160a060020a038416917fcc16f5dbb4873280815c1ee09dbd06736cffcc184412cf7a71a0fdb75d397ca5919081900360200190a2604080518281529051600091600160a060020a038516916000805160206116208339815191529181900360200190a35050565b6000828211156114b957fe5b50900390565b818101828110156114cc57fe5b92915050565b600160a060020a03811615156114e757600080fd5b600654604051600160a060020a038084169216907f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e090600090a36006805473ffffffffffffffffffffffffffffffffffffffff1916600160a060020a0392909216919091179055565b3360009081526003602052604081205482111561156c57600080fd5b600160a060020a038316151561158157600080fd5b336000908152600360205260409020546115a1908363ffffffff6114ad16565b3360009081526003602052604080822092909255600160a060020a038516815220546115d3908363ffffffff6114bf16565b600160a060020a0384166000818152600360209081526040918290209390935580518581529051919233926000805160206116208339815191529281900390910190a3506001929150505600ddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3efa165627a7a723058203388509967a7ac9951a3a947efe3befd430d9cf6568f39b1bc8c8668223aa6f00029";
        public SeniTokenDeploymentBase() : base(BYTECODE) { }
        public SeniTokenDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_whitelistContract", 1)]
        public virtual string WhitelistContract { get; set; }
    }

    public partial class MintingFinishedFunction : MintingFinishedFunctionBase { }

    [Function("mintingFinished", "bool")]
    public class MintingFinishedFunctionBase : FunctionMessage
    {

    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve", "bool")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "_spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "_value", 2)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class SetBridgeContractFunction : SetBridgeContractFunctionBase { }

    [Function("setBridgeContract")]
    public class SetBridgeContractFunctionBase : FunctionMessage
    {
        [Parameter("address", "_bridgeContract", 1)]
        public virtual string BridgeContract { get; set; }
    }

    public partial class SetWhitelistContractFunction : SetWhitelistContractFunctionBase { }

    [Function("setWhitelistContract")]
    public class SetWhitelistContractFunctionBase : FunctionMessage
    {
        [Parameter("address", "_whitelistContract", 1)]
        public virtual string WhitelistContract { get; set; }
    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom", "bool")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "_from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "_to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_value", 3)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class DECIMALSFunction : DECIMALSFunctionBase { }

    [Function("DECIMALS", "uint8")]
    public class DECIMALSFunctionBase : FunctionMessage
    {

    }

    public partial class DecimalsFunction : DecimalsFunctionBase { }

    [Function("decimals", "uint8")]
    public class DecimalsFunctionBase : FunctionMessage
    {

    }

    public partial class TransferAndCallFunction : TransferAndCallFunctionBase { }

    [Function("transferAndCall", "bool")]
    public class TransferAndCallFunctionBase : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_value", 2)]
        public virtual BigInteger Value { get; set; }
        [Parameter("bytes", "_data", 3)]
        public virtual byte[] Data { get; set; }
    }

    public partial class MintFunction : MintFunctionBase { }

    [Function("mint", "bool")]
    public class MintFunctionBase : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class BurnFunction : BurnFunctionBase { }

    [Function("burn")]
    public class BurnFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_value", 1)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class DecreaseApprovalFunction : DecreaseApprovalFunctionBase { }

    [Function("decreaseApproval", "bool")]
    public class DecreaseApprovalFunctionBase : FunctionMessage
    {
        [Parameter("address", "_spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "_subtractedValue", 2)]
        public virtual BigInteger SubtractedValue { get; set; }
    }

    public partial class ClaimTokensFunction : ClaimTokensFunctionBase { }

    [Function("claimTokens")]
    public class ClaimTokensFunctionBase : FunctionMessage
    {
        [Parameter("address", "_token", 1)]
        public virtual string Token { get; set; }
        [Parameter("address", "_to", 2)]
        public virtual string To { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class FinishMintingFunction : FinishMintingFunctionBase { }

    [Function("finishMinting", "bool")]
    public class FinishMintingFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class WhitelistFunction : WhitelistFunctionBase { }

    [Function("whitelist", "address")]
    public class WhitelistFunctionBase : FunctionMessage
    {

    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class NAMEFunction : NAMEFunctionBase { }

    [Function("NAME", "string")]
    public class NAMEFunctionBase : FunctionMessage
    {

    }

    public partial class TransferFunction : TransferFunctionBase { }

    [Function("transfer", "bool")]
    public class TransferFunctionBase : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_value", 2)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class BridgeContractFunction : BridgeContractFunctionBase { }

    [Function("bridgeContract", "address")]
    public class BridgeContractFunctionBase : FunctionMessage
    {

    }

    public partial class IncreaseApprovalFunction : IncreaseApprovalFunctionBase { }

    [Function("increaseApproval", "bool")]
    public class IncreaseApprovalFunctionBase : FunctionMessage
    {
        [Parameter("address", "_spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "_addedValue", 2)]
        public virtual BigInteger AddedValue { get; set; }
    }

    public partial class AllowanceFunction : AllowanceFunctionBase { }

    [Function("allowance", "uint256")]
    public class AllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "_spender", 2)]
        public virtual string Spender { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "_newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class SYMBOLFunction : SYMBOLFunctionBase { }

    [Function("SYMBOL", "string")]
    public class SYMBOLFunctionBase : FunctionMessage
    {

    }

    public partial class ContractFallbackCallFailedEventDTO : ContractFallbackCallFailedEventDTOBase { }

    [Event("ContractFallbackCallFailed")]
    public class ContractFallbackCallFailedEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, false )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, false )]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class MintEventDTO : MintEventDTOBase { }

    [Event("Mint")]
    public class MintEventDTOBase : IEventDTO
    {
        [Parameter("address", "to", 1, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "amount", 2, false )]
        public virtual BigInteger Amount { get; set; }
    }



    public partial class OwnershipRenouncedEventDTO : OwnershipRenouncedEventDTOBase { }

    [Event("OwnershipRenounced")]
    public class OwnershipRenouncedEventDTOBase : IEventDTO
    {
        [Parameter("address", "previousOwner", 1, true )]
        public virtual string PreviousOwner { get; set; }
    }

    public partial class OwnershipTransferredEventDTO : OwnershipTransferredEventDTOBase { }

    [Event("OwnershipTransferred")]
    public class OwnershipTransferredEventDTOBase : IEventDTO
    {
        [Parameter("address", "previousOwner", 1, true )]
        public virtual string PreviousOwner { get; set; }
        [Parameter("address", "newOwner", 2, true )]
        public virtual string NewOwner { get; set; }
    }

    public partial class BurnEventDTO : BurnEventDTOBase { }

    [Event("Burn")]
    public class BurnEventDTOBase : IEventDTO
    {
        [Parameter("address", "burner", 1, true )]
        public virtual string Burner { get; set; }
        [Parameter("uint256", "value", 2, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
        [Parameter("bytes", "data", 4, false )]
        public virtual byte[] Data { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2, true )]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class MintingFinishedOutputDTO : MintingFinishedOutputDTOBase { }

    [FunctionOutput]
    public class MintingFinishedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }







    public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class DECIMALSOutputDTO : DECIMALSOutputDTOBase { }

    [FunctionOutput]
    public class DECIMALSOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class DecimalsOutputDTO : DecimalsOutputDTOBase { }

    [FunctionOutput]
    public class DecimalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }











    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class WhitelistOutputDTO : WhitelistOutputDTOBase { }

    [FunctionOutput]
    public class WhitelistOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class NAMEOutputDTO : NAMEOutputDTOBase { }

    [FunctionOutput]
    public class NAMEOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class BridgeContractOutputDTO : BridgeContractOutputDTOBase { }

    [FunctionOutput]
    public class BridgeContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class AllowanceOutputDTO : AllowanceOutputDTOBase { }

    [FunctionOutput]
    public class AllowanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class SYMBOLOutputDTO : SYMBOLOutputDTOBase { }

    [FunctionOutput]
    public class SYMBOLOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
