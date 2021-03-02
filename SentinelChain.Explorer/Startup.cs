using Blazor.FlexGrid;
using Microsoft.Extensions.DependencyInjection;
using SentinelChain.Explorer.Services;
using SentinelChain.Explorer.ViewModels;

namespace SentinelChain.Explorer
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            var web3ServiceProvider = new Web3ProviderService();
            var accountsService = new AccountsService(web3ServiceProvider);
            var newBlockProcessingService = new NewBlockProcessingService(web3ServiceProvider);
            var toastsViewModel = new ToastsViewModel();
            var blocksViewModel = new BlocksViewModel(newBlockProcessingService);
            var latestBlockTransactionsViewModel = new LatestBlockTransactionsViewModel(web3ServiceProvider);
            var newAccountPrivateKeyViewModel = new NewAccountPrivateKeyViewModel();
            var accountsViewModel = new AccountsViewModel(accountsService, newAccountPrivateKeyViewModel);
            var accountsTransactionMonitoringService = new AccountsTransactionMonitoringService(accountsService, web3ServiceProvider);

            services.AddSingleton<IWeb3ProviderService, Web3ProviderService>((x) => web3ServiceProvider);
            services.AddSingleton<IAccountsService, AccountsService>((x) => accountsService);
            services.AddSingleton<NewBlockProcessingService>(newBlockProcessingService);
            services.AddSingleton<ToastsViewModel>(toastsViewModel);
            services.AddSingleton<BlocksViewModel>(blocksViewModel);
            services.AddSingleton<LatestBlockTransactionsViewModel>(latestBlockTransactionsViewModel);
            services.AddTransient<BlockTransactionsViewModel>();
            services.AddSingleton<AccountsViewModel>(accountsViewModel);
            services.AddSingleton<NewAccountPrivateKeyViewModel>(newAccountPrivateKeyViewModel);
            services.AddSingleton<SendTransactionViewModel>();
            services.AddSingleton<SendErc20TransactionViewModel>();
            services.AddSingleton<SendSeniTransactionViewModel>();
            services.AddSingleton(accountsTransactionMonitoringService);
            services.AddSingleton<TransactionWithReceiptViewModel>();

            services.AddFlexGrid(cfg =>
            {
                cfg.ApplyConfiguration(new TransactionsViewModelGridConfiguration());
            });

            services.AddSingleton<Web3UrlViewModel>();
        }
    }
}
