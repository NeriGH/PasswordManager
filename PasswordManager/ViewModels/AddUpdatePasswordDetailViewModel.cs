using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using PasswordManager.Models;
using PasswordManager.Services;
using PasswordManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordManager.ViewModels
{
    [QueryProperty(nameof(PasswordDetail),"PasswordDetail")]
    public partial class AddUpdatePasswordDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private PasswordModel _passwordDetail = new PasswordModel();

        private readonly IPasswordService _passwordService;
        public AddUpdatePasswordDetailViewModel(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        [ICommand]
        public async void AddUpdatePassword()
        {
            int response = -1;
            if (PasswordDetail.PasswordID > 0)
            {
                response = await _passwordService.UpdatePassword(PasswordDetail);
            } else
            {
                response = await _passwordService.AddPassword(new Models.PasswordModel
                {
                    Title = PasswordDetail.Title,
                    Username = PasswordDetail.Username,
                    Password = PasswordDetail.Password
                });

            }



            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Password Info saved", "Record Saved", "OK");
                await Shell.Current.GoToAsync("//PasswordListPage");

            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }
    }
}
