﻿using System;
using SentinelChain.Explorer.Messages;
using SentinelChain.Explorer.Services;
using ReactiveUI;

namespace SentinelChain.Explorer.ViewModels
{
    public class LatestBlockTransactionsViewModel : BlockTransactionsViewModel
    {
        public LatestBlockTransactionsViewModel(IWeb3ProviderService web3ProviderService):base(web3ProviderService)
        {
            MessageBus.Current.Listen<NewBlock>().Subscribe(x =>
                {
                    if (x.BlockNumber != BlockNumber)
                    {
                        BlockNumber = x.BlockNumber;
                    }
                }
           );
        }
    }
}
