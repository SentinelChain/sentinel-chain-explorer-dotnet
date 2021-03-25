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

namespace SentinelChain.Neth.EntrypointList.ContractDefinition
{


    public partial class EntrypointListDeployment : EntrypointListDeploymentBase
    {
        public EntrypointListDeployment() : base(BYTECODE) { }
        public EntrypointListDeployment(string byteCode) : base(byteCode) { }
    }

    public class EntrypointListDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6080604052600060025534801561001557600080fd5b506040516020806113368339810180604052810190808051906020019092919050505033600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff161415151561011e576040517f08c379a00000000000000000000000000000000000000000000000000000000081526004018080602001828103825260198152602001807f4f776e657220616464726573732069732072657175697265640000000000000081525060200191505060405180910390fd5b80600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550506111c78061016f6000396000f3006080604052600436106100ba576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff1680630988ca8c146100bf578063132308ca1461016057806320e1e30414610206578063217fe6c6146102ac578063715018a61461034d57806378e8c1a7146103645780638da5cb5b1461039f5780639870d7fe146103f657806398a1b39714610439578063ac8a584a146104c9578063f2f2fff51461050c578063f2fde38b14610537575b600080fd5b3480156100cb57600080fd5b50610146600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803590602001908201803590602001908080601f016020809104026020016040519081016040528093929190818152602001838380828437820191505050505050919291929050505061057a565b604051808215151515815260200191505060405180910390f35b34801561016c57600080fd5b5061018b600480360381019080803590602001909291905050506105ff565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156101cb5780820151818401526020810190506101b0565b50505050905090810190601f1680156101f85780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b34801561021257600080fd5b506102316004803603810190808035906020019092919050505061074c565b6040518080602001828103825283818151815260200191508051906020019080838360005b83811015610271578082015181840152602081019050610256565b50505050905090810190601f16801561029e5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b3480156102b857600080fd5b50610333600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803590602001908201803590602001908080601f01602080910402602001604051908101604052809392919081815260200183838082843782019150505050505091929192905050506107fc565b604051808215151515815260200191505060405180910390f35b34801561035957600080fd5b50610362610883565b005b34801561037057600080fd5b5061039d600480360381019080803590602001908201803590602001919091929391929390505050610988565b005b3480156103ab57600080fd5b506103b4610a5b565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561040257600080fd5b50610437600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610a81565b005b34801561044557600080fd5b5061044e610b1f565b6040518080602001828103825283818151815260200191508051906020019080838360005b8381101561048e578082015181840152602081019050610473565b50505050905090810190601f1680156104bb5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b3480156104d557600080fd5b5061050a600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610b58565b005b34801561051857600080fd5b50610521610bf6565b6040518082815260200191505060405180910390f35b34801561054357600080fd5b50610578600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610bfc565b005b60006105f9836000846040518082805190602001908083835b6020831015156105b85780518252602082019150602081019050602083039250610593565b6001836020036101000a0380198251168184511680821785525050505050509050019150509081526020016040518091039020610c6490919063ffffffff16565b92915050565b6060600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561069957610697336040805190810160405280600881526020017f6f70657261746f7200000000000000000000000000000000000000000000000081525061057a565b505b600360008381526020019081526020016000208054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156107405780601f1061071557610100808354040283529160200191610740565b820191906000526020600020905b81548152906001019060200180831161072357829003601f168201915b50505050509050919050565b60036020528060005260406000206000915090508054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156107f45780601f106107c9576101008083540402835291602001916107f4565b820191906000526020600020905b8154815290600101906020018083116107d757829003601f168201915b505050505081565b600061087b836000846040518082805190602001908083835b60208310151561083a5780518252602082019150602081019050602083039250610815565b6001836020036101000a0380198251168184511680821785525050505050509050019150509081526020016040518091039020610c7d90919063ffffffff16565b905092915050565b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156108df57600080fd5b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167ff8df31144d9c2f0f6b59d69b8b98abd5459d07f2742c4df920b25aae33c6482060405160405180910390a26000600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550565b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610a2057610a1e336040805190810160405280600881526020017f6f70657261746f7200000000000000000000000000000000000000000000000081525061057a565b505b81816003600060025481526020019081526020016000209190610a449291906110f6565b506002600081548092919060010191905055505050565b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610add57600080fd5b610b1c816040805190810160405280600881526020017f6f70657261746f72000000000000000000000000000000000000000000000000815250610cd6565b50565b6040805190810160405280600881526020017f6f70657261746f7200000000000000000000000000000000000000000000000081525081565b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610bb457600080fd5b610bf3816040805190810160405280600881526020017f6f70657261746f72000000000000000000000000000000000000000000000000815250610e0a565b50565b60025481565b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610c5857600080fd5b610c6181610f3e565b50565b610c6e8282610c7d565b1515610c7957600080fd5b5050565b60008260000160008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff16905092915050565b610d53826000836040518082805190602001908083835b602083101515610d125780518252602082019150602081019050602083039250610ced565b6001836020036101000a038019825116818451168082178552505050505050905001915050908152602001604051809103902061103a90919063ffffffff16565b8173ffffffffffffffffffffffffffffffffffffffff167fbfec83d64eaa953f2708271a023ab9ee82057f8f3578d548c1a4ba0b5b700489826040518080602001828103825283818151815260200191508051906020019080838360005b83811015610dcc578082015181840152602081019050610db1565b50505050905090810190601f168015610df95780820380516001836020036101000a031916815260200191505b509250505060405180910390a25050565b610e87826000836040518082805190602001908083835b602083101515610e465780518252602082019150602081019050602083039250610e21565b6001836020036101000a038019825116818451168082178552505050505050905001915050908152602001604051809103902061109890919063ffffffff16565b8173ffffffffffffffffffffffffffffffffffffffff167fd211483f91fc6eff862467f8de606587a30c8fc9981056f051b897a418df803a826040518080602001828103825283818151815260200191508051906020019080838360005b83811015610f00578082015181840152602081019050610ee5565b50505050905090810190601f168015610f2d5780820380516001836020036101000a031916815260200191505b509250505060405180910390a25050565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff1614151515610f7a57600080fd5b8073ffffffffffffffffffffffffffffffffffffffff16600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e060405160405180910390a380600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555050565b60018260000160008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548160ff0219169083151502179055505050565b60008260000160008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548160ff0219169083151502179055505050565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f1061113757803560ff1916838001178555611165565b82800160010185558215611165579182015b82811115611164578235825591602001919060010190611149565b5b5090506111729190611176565b5090565b61119891905b8082111561119457600081600090555060010161117c565b5090565b905600a165627a7a72305820803cf973cc4df92a67a6b436f4eb1516e07be78e4d1cf74454b057937d9a4efb0029";
        public EntrypointListDeploymentBase() : base(BYTECODE) { }
        public EntrypointListDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class CheckRoleFunction : CheckRoleFunctionBase { }

    [Function("checkRole", "bool")]
    public class CheckRoleFunctionBase : FunctionMessage
    {
        [Parameter("address", "_operator", 1)]
        public virtual string Operator { get; set; }
        [Parameter("string", "_role", 2)]
        public virtual string Role { get; set; }
    }

    public partial class EntryPointFunction : EntryPointFunctionBase { }

    [Function("EntryPoint", "bytes")]
    public class EntryPointFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
    }

    public partial class EntrypointListFunction : EntrypointListFunctionBase { }

    [Function("_entrypointList", "bytes")]
    public class EntrypointListFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class HasRoleFunction : HasRoleFunctionBase { }

    [Function("hasRole", "bool")]
    public class HasRoleFunctionBase : FunctionMessage
    {
        [Parameter("address", "_operator", 1)]
        public virtual string Operator { get; set; }
        [Parameter("string", "_role", 2)]
        public virtual string Role { get; set; }
    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class AddEntryPointFunction : AddEntryPointFunctionBase { }

    [Function("AddEntryPoint")]
    public class AddEntryPointFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "entryPoint", 1)]
        public virtual byte[] EntryPoint { get; set; }
    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class AddOperatorFunction : AddOperatorFunctionBase { }

    [Function("addOperator")]
    public class AddOperatorFunctionBase : FunctionMessage
    {
        [Parameter("address", "_operator", 1)]
        public virtual string Operator { get; set; }
    }

    public partial class ROLE_OPERATORFunction : ROLE_OPERATORFunctionBase { }

    [Function("ROLE_OPERATOR", "string")]
    public class ROLE_OPERATORFunctionBase : FunctionMessage
    {

    }

    public partial class RemoveOperatorFunction : RemoveOperatorFunctionBase { }

    [Function("removeOperator")]
    public class RemoveOperatorFunctionBase : FunctionMessage
    {
        [Parameter("address", "_operator", 1)]
        public virtual string Operator { get; set; }
    }

    public partial class NextIdFunction : NextIdFunctionBase { }

    [Function("_nextId", "uint256")]
    public class NextIdFunctionBase : FunctionMessage
    {

    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "_newOwner", 1)]
        public virtual string NewOwner { get; set; }
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

    public partial class RoleAddedEventDTO : RoleAddedEventDTOBase { }

    [Event("RoleAdded")]
    public class RoleAddedEventDTOBase : IEventDTO
    {
        [Parameter("address", "operator", 1, true )]
        public virtual string Operator { get; set; }
        [Parameter("string", "role", 2, false )]
        public virtual string Role { get; set; }
    }

    public partial class RoleRemovedEventDTO : RoleRemovedEventDTOBase { }

    [Event("RoleRemoved")]
    public class RoleRemovedEventDTOBase : IEventDTO
    {
        [Parameter("address", "operator", 1, true )]
        public virtual string Operator { get; set; }
        [Parameter("string", "role", 2, false )]
        public virtual string Role { get; set; }
    }

    public partial class CheckRoleOutputDTO : CheckRoleOutputDTOBase { }

    [FunctionOutput]
    public class CheckRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }



    public partial class EntrypointListOutputDTO : EntrypointListOutputDTOBase { }

    [FunctionOutput]
    public class EntrypointListOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class HasRoleOutputDTO : HasRoleOutputDTOBase { }

    [FunctionOutput]
    public class HasRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }





    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class ROLE_OPERATOROutputDTO : ROLE_OPERATOROutputDTOBase { }

    [FunctionOutput]
    public class ROLE_OPERATOROutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class NextIdOutputDTO : NextIdOutputDTOBase { }

    [FunctionOutput]
    public class NextIdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }


}
