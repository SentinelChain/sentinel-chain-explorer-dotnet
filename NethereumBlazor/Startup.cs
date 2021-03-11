using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NethereumBlazor.Data;
using NethereumBlazor.Services;
using NethereumBlazor.ViewModels;
using SentinelChain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NethereumBlazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            var web3ServiceProvider = new Web3ProviderService();
            var accountsService = new AccountsService(web3ServiceProvider);
            services.AddSingleton<IWeb3ProviderService, Web3ProviderService>((x) => web3ServiceProvider);
            services.AddSingleton<IAccountsService, AccountsService>((x) => accountsService);
            var newAccountPrivateKeyViewModel = new NewAccountPrivateKeyViewModel();
            var accountsViewModel = new AccountsViewModel(accountsService, newAccountPrivateKeyViewModel);
           
            services.AddSingleton<AccountsViewModel>(accountsViewModel);
            services.AddSingleton<NewAccountPrivateKeyViewModel>(newAccountPrivateKeyViewModel);
            services.AddSingleton<SendSeniTransactionViewModel>();
            //var seniConfig = new SentinelChainConfiguration()
            //{
            //    Contracts = new Dictionary<string, string>() { { "senitoken", "0x6912165b70fe4fa191d95BC6888EF6A232f6c852" } },
            //    Address = "0xFaC084fbc44A56cc232dD5d109FC7E104e05A4f1",
            //    PrivateKey = "cf4bcfa844c37d913992cc9e019e4a1039eb0e343fb9e8829755d3b3a8101320",
            //    Url = "https://testnet-sc-rpc.sentinel-chain.org/"
            //};
            ////var senitokenService = new SeniTokenService(seniConfig, "0x65Cabf6b3B5C9960c5Fa33B2eDF380191355285b");
            //var senitokenService = new SeniTokenService(seniConfig, "0x6912165b70fe4fa191d95BC6888EF6A232f6c852");
            
            var seniConfig = new SentinelChainConfiguration()
            {
                Contracts = new Dictionary<string, string>() { { "senitoken", Configuration.GetValue<string>("ContractAddress") } },
                Address = Configuration.GetValue<string>("Address"),
                PrivateKey = Configuration.GetValue<string>("PrivateKey"),
                Url = Configuration.GetValue<string>("Url")
            };
            //var senitokenService = new SeniTokenService(seniConfig, "0x65Cabf6b3B5C9960c5Fa33B2eDF380191355285b");
            var senitokenService = new SeniTokenService(seniConfig, Configuration.GetValue<string>("ContractAddress"));
            services.AddSingleton<SeniTokenService>(senitokenService);

            var oracleQueryService = new OracleQueryService(web3ServiceProvider,senitokenService);
            var oracleQueryViewModel = new OracleQueryViewModel(oracleQueryService);
            services.AddSingleton<IOracleQueryService, OracleQueryService>((x) => oracleQueryService);
            services.AddSingleton<OracleQueryViewModel>(oracleQueryViewModel);

            var newBlockProcessingService = new NewBlockProcessingService(web3ServiceProvider);
            var blocksViewModel = new BlocksViewModel(newBlockProcessingService);
            var latestBlockTransactionsViewModel = new LatestBlockTransactionsViewModel(web3ServiceProvider);
            services.AddSingleton<BlocksViewModel>(blocksViewModel);
            services.AddSingleton<LatestBlockTransactionsViewModel>(latestBlockTransactionsViewModel);
            services.AddSingleton<NewBlockProcessingService>(newBlockProcessingService);

            services.AddSingleton<Web3UrlViewModel>();
            var toastsViewModel = new ToastsViewModel();
            services.AddSingleton<ToastsViewModel>(toastsViewModel);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //app.UsePathBase("/NethereumBlazor");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
