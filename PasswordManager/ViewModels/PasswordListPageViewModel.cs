using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using PasswordManager.Models;
using PasswordManager.Services;
using PasswordManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.ViewModels
{
    public partial class PasswordListPageViewModel : ObservableObject
    {
        public ObservableCollection<PasswordModel> Passwords { get; set; } = new ObservableCollection<PasswordModel>();

        private readonly IPasswordService _passwordService;
        public PasswordListPageViewModel(IPasswordService passwordService) {
            _passwordService = passwordService;
        }

        [ICommand]
        public async void GetPasswordList()
        {
            var passwordList = await _passwordService.GetPasswordList();
            if(passwordList?.Count > 0)
            {
                Passwords.Clear();
                foreach (var password in passwordList)
                {
                    Passwords.Add(password);
                }
            }
        }

        [ICommand]
        public async void AddUpdatePassword()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdatePasswordDetail));
        }


        [ICommand]
        public async void DisplayAction(PasswordModel passwordModel)
        {
           var response = await AppShell.Current.DisplayActionSheet("Choose an option", "OK",null,"EDIT", "DELETE");
            if(response == "EDIT")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("PasswordDetail", passwordModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdatePasswordDetail),navParam);
            } else if (response == "DELETE")
            {
              var delResponse =  await _passwordService.DeletePassword(passwordModel);
                if(delResponse > 0)
                {
                    GetPasswordList();
                }
            }
        }
    }
}
