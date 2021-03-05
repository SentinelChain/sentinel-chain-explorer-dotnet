# Sentinel Chain Explorer Dotnet

This is a fork of the Nethereum Blazor project extended to run on Sentinel Chain. Refer to the link for the original source
https://github.com/Nethereum/NethereumBlazor

## Usage notes

This blockchain explorer is intended for exploring new features for private Sentinel chain and is **NOT FOR PRODUCTION** use. 
As it does not have a dedicated database, all data will be retrieved on demand from a backend Parity node. We have currently developed 
the explorer using Kovan-[Orion](https://github.com/SentinelChain/orion-testnet) testnet bridge. The explorer is still under 
heavy development and experimentation, if you find any problems please create an issue or prepare a pull request.

## Install

Go to solution folder:
```
$ dotnet build
$ cd SentinelChain.Explorer
$ dotnet run

```
Browse to localhost:52915

## Testnode

Browse to http://52.163.206.199:52915/

