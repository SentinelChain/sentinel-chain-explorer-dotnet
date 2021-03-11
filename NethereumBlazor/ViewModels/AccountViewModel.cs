using DynamicData;
using NethereumBlazor.Model;
using NethereumBlazor.Services;
using ReactiveUI;
using System;

namespace NethereumBlazor.ViewModels
{
    public class AccountsViewModel : ReactiveObject
    {
        private readonly IAccountsService _accountsService;
        private NewAccountPrivateKeyViewModel _newAccountPrivateKeyViewModel;

        public SourceCache<AccountInfo, string> Accounts => _accountsService.Accounts;

        public NewAccountPrivateKeyViewModel NewAccount
        {
            get => _newAccountPrivateKeyViewModel;
        }

        public AccountsViewModel(IAccountsService accountsService, NewAccountPrivateKeyViewModel newAccountPrivateKeyViewModel)
        {
            Console.WriteLine("point 1: " + newAccountPrivateKeyViewModel.PrivateKey);
            _accountsService = accountsService;
            _newAccountPrivateKeyViewModel = newAccountPrivateKeyViewModel;
            //InitNewAccount();
        }

        private void InitNewAccount()
        {
            NewAccount.Clear();
        }

        public void AddNewAccount()
        {
            if (NewAccount.ValidPrivateKey)
            {

                var newAccountInfo = new AccountInfo()
                {
                    Address = NewAccount.Address
                };

                _accountsService.AddAccount(newAccountInfo, NewAccount.PrivateKey);
                NewAccount.Clear();
            }

        }
    }
}
