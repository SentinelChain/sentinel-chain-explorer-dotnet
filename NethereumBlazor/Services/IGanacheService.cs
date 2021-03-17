using Microsoft.Extensions.Configuration;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using SentinelChain;
using SentinelChain.Neth.FOSC.ContractDefinition;
using SentinelChain.Neth.SeniToken.ContractDefinition;
using SentinelChain.Neth.WhiteList.ContractDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace NethereumBlazor.Services
{
    public interface IGanacheService
    {
        Task<string> DeployWhiteListContract(Account sender, string rpcUrl);
        Task<string> DeploySeniContract(Account sender, string rpcUrl, string whiteListContractAddress);
        Task<string> DeployFoscContract(Account sender, string rpcUrl, string seniContractAddress, string oracleAddress, BigInteger callValue);
        Task<SentinelChainConfiguration> InitializeProcess();
    }

    public class GanacheService
    {
        private string foscOwnerPrivateKey;
        private string foscContractAddress;
        private string rpcUrl;
        private string address;
        private string privateKey;
        SentinelChainConfiguration _scConfig, _foscOwnerConfig, _thirdPartyCallerConfig, _foscOracleConfig;

        private string foscInstanceAddress = "";
        private string seniTokenInstanceAddress = "";
        private string whiteListInstanceAddress = "";



        public GanacheService(IConfiguration config)
        {
            foscOwnerPrivateKey = config.GetValue<string>("FoscOwnerPrivateKey");
            foscContractAddress = config.GetValue<string>("FoscContractAddress");
            rpcUrl = config.GetValue<string>("Url");
            address = config.GetValue<string>("Address");
            privateKey = config.GetValue<string>("PrivateKey");

            _foscOwnerConfig = new SentinelChainConfiguration
            {
                Url = rpcUrl,
                Address = "0x2d43ecF77291D0278CF6Fce73219E9b35090abA3",
                PrivateKey = "a17c35f3347dcae461ff4017ce1849d095a75eabe2d8392dae3c44ca4801efc3",
                Contracts = new Dictionary<string, string>()
                {
                    ["fosc"] = "",
                    ["senitoken"] = "",
                    ["whitelist"] = ""
                }
            };

            _foscOracleConfig = new SentinelChainConfiguration
            {
                Url = rpcUrl,
                Address = "0x2d43ecF77291D0278CF6Fce73219E9b35090abA3",
                PrivateKey = "a17c35f3347dcae461ff4017ce1849d095a75eabe2d8392dae3c44ca4801efc3",
                Contracts = new Dictionary<string, string>()
                {
                    ["fosc"] = "",
                    ["senitoken"] = "",
                    ["whitelist"] = ""
                }
            };

            _thirdPartyCallerConfig = new SentinelChainConfiguration
            {
                Url = rpcUrl,
                Address = "0x82E0Df380Facc5Bb802C14e000DBf164962a07F0",
                PrivateKey = "52901b9501372fce2ad7127dcc3e471dc0a195a85db8e4e1a4f350ce87e5fd9c",
                Contracts = new Dictionary<string, string>()
                {
                    ["fosc"] = "",
                    ["senitoken"] = "",
                    ["whitelist"] = ""
                }
            };
            //_foscOwnerConfig = new SentinelChainConfiguration
            //{
            //    Url = rpcUrl,
            //    Address = "0x0096d6ea310a85A233af038736AF351FDf5ac0c8",
            //    PrivateKey = "18e5eeb1939b5b29e40c8046e1011de24511edd47af6e349283cae42f70e6bd0",
            //    Contracts = new Dictionary<string, string>()
            //    {
            //        ["fosc"] = "",
            //        ["senitoken"] = "",
            //        ["whitelist"] = ""
            //    }
            //};

            //_foscOracleConfig = new SentinelChainConfiguration
            //{
            //    Url = rpcUrl,
            //    Address = "0x0096d6ea310a85A233af038736AF351FDf5ac0c8",
            //    PrivateKey = "18e5eeb1939b5b29e40c8046e1011de24511edd47af6e349283cae42f70e6bd0",
            //    Contracts = new Dictionary<string, string>()
            //    {
            //        ["fosc"] = "",
            //        ["senitoken"] = "",
            //        ["whitelist"] = ""
            //    }
            //};

            //_thirdPartyCallerConfig = new SentinelChainConfiguration
            //{
            //    Url = rpcUrl,
            //    Address = "0x0e8F0ea834eE5Ea0dB5AE50E2a819A4dD2110655",
            //    PrivateKey = "8e776e6c214b80f5661520d049ef685a7f833b85688e577d918df1cfba5d7bff",
            //    Contracts = new Dictionary<string, string>()
            //    {
            //        ["fosc"] = "",
            //        ["senitoken"] = "",
            //        ["whitelist"] = ""
            //    }
            //};

        }

        public async Task<string> DeployWhiteListContract(Account sender, string rpcUrl)
        {
            var web3 = new Web3(sender, rpcUrl);
            var handler = web3.Eth.GetContractDeploymentHandler<WhiteListDeployment>();
            var receipt = await handler.SendRequestAndWaitForReceiptAsync(
                new WhiteListDeployment { Owner = sender.Address }
                );
            return receipt.ContractAddress;
        }

        public async Task<string> DeploySeniContract(Account sender, string rpcUrl, string whiteListContractAddress)
        {
            var web3 = new Web3(sender, rpcUrl);
            var handler = web3.Eth.GetContractDeploymentHandler<SeniTokenDeployment>();
            var receipt = await handler.SendRequestAndWaitForReceiptAsync(
                new SeniTokenDeployment { WhitelistContract = whiteListContractAddress }
                );
            return receipt.ContractAddress;
        }

        public async Task<string> DeployFoscContract(Account sender, string rpcUrl, string seniContractAddress, string oracleAddress, BigInteger callValue)
        {
            var web3 = new Web3(sender, rpcUrl);
            var handler = web3.Eth.GetContractDeploymentHandler<FOSCDeployment>();
            var receipt = await handler.SendRequestAndWaitForReceiptAsync(
                new FOSCDeployment { Token = seniContractAddress, NewOracle = oracleAddress, CallValue = callValue }
                );
            return receipt.ContractAddress;
        }

        public async Task<SentinelChainConfiguration> InitializeProcess()
        {
            try
            {

                var account = new Account(_foscOwnerConfig.PrivateKey);
                whiteListInstanceAddress = await DeployWhiteListContract(account, rpcUrl);
                seniTokenInstanceAddress = await DeploySeniContract(account, rpcUrl, whiteListInstanceAddress);
                foscInstanceAddress = await DeployFoscContract(account, rpcUrl, seniTokenInstanceAddress, _foscOracleConfig.Address, BigInteger.Parse("10000000000000000000"));

                _foscOwnerConfig.Contracts = new Dictionary<string, string>()
                {
                    ["fosc"] = foscInstanceAddress,
                    ["senitoken"] = seniTokenInstanceAddress,
                    ["whitelist"] = whiteListInstanceAddress
                };
                _foscOracleConfig.Contracts = new Dictionary<string, string>()
                {
                    ["fosc"] = foscInstanceAddress,
                    ["senitoken"] = seniTokenInstanceAddress,
                    ["whitelist"] = whiteListInstanceAddress
                };
                _thirdPartyCallerConfig.Contracts = new Dictionary<string, string>()
                {
                    ["fosc"] = foscInstanceAddress,
                    ["senitoken"] = seniTokenInstanceAddress,
                    ["whitelist"] = whiteListInstanceAddress
                };

                var whitelist = new WhiteListService(_foscOwnerConfig, _foscOwnerConfig.Contracts["whitelist"]);
                await whitelist.AddWhiteListAddress(_foscOwnerConfig.Contracts["fosc"]);
                await whitelist.AddWhiteListAddress(_foscOwnerConfig.Address);
                await whitelist.AddWhiteListAddress(_thirdPartyCallerConfig.Address);

                var isWhiteListed = await whitelist.CheckWhiteListAddress(_thirdPartyCallerConfig.Address);
                isWhiteListed = await whitelist.CheckWhiteListAddress(_foscOwnerConfig.Address);
                isWhiteListed = await whitelist.CheckWhiteListAddress(_foscOwnerConfig.Contracts["fosc"]);

                return _thirdPartyCallerConfig;

                //var account = new Account(foscOwnerPrivateKey);
                //var contractDetail = new ContractDto();

                //contractDetail.WhitelistAddress = await DeployWhiteListContract(account, rpcUrl);
                //contractDetail.SeniAddress = await DeploySeniContract(account, rpcUrl, contractDetail.WhitelistAddress);
                //contractDetail.FoscAddress = await DeployFoscContract(account, rpcUrl, contractDetail.SeniAddress, foscContractAddress, BigInteger.Parse("10000000000000000000"));

                //var seniConfig = new SentinelChainConfiguration()
                //{
                //    Contracts = new Dictionary<string, string>() {
                //    { "senitoken", contractDetail.SeniAddress },
                //    { "fosc",  contractDetail.FoscAddress },
                //    { "whitelist", contractDetail.WhitelistAddress },
                //},
                //    Address = address,
                //    PrivateKey = privateKey,
                //    Url = rpcUrl
                //};

                //return seniConfig;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
   

    public class ContractDto
    {
        public string WhitelistAddress { get; set; }
        public string SeniAddress { get; set; }
        public string FoscAddress { get; set; }
    }
}
